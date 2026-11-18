using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Net.Mail;
using System.Net;

namespace FlightLib.IO
{
    public class FlightDBManager
    {
        private SQLiteConnection cnx;
        private readonly string dbPath;

        public FlightDBManager()
        {
            dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Database\SimDatabase.db"); // Ruta relativa de la base de datos
        }
        //Abre la base de datos y informa por consola
        public void StartConnection()
        {
            try
            {
                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException($"La base de datos no existe en la ruta: {dbPath}. \n La base de datos no existe, comprueba el nombre.");
                }

                string dataSource = $"Data Source={dbPath};Version=3";
                cnx = new SQLiteConnection(dataSource);
                cnx.Open();

                if (!TablaExiste("Users"))
                {
                    throw new Exception("La tabla 'Users' no existe en la base de datos.");
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw; // Opcional: relanzar para que el flujo de control lo maneje quien llama
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la conexión a la base de datos: " + ex.Message);
                throw;
            }

        }
        //Cierra la base de datos y informa por consola
        public void CloseConnection()
        {
            if (this.cnx != null && this.cnx.State == ConnectionState.Open)
            {
                Console.WriteLine("Connection to the database is being closed...");
                cnx.Close();
            }
            else
            {
                Console.WriteLine("Connection was not open or is null.");
            }
        }
        //Se obtiene la connexión para usarla más fácilmente
        public SQLiteConnection GetConnection()
        {
            return this.cnx;
        }


        private bool TablaExiste(string tableName)
        {
            string sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}';";
            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                return cmd.ExecuteScalar() != null;
            }
        }

        // Users table ____________________________________________________________


        //Función para insertar un nuevo usuario a la base de datos
        public bool InsertarUsuario(string username, string name, string email, string password, string birthday, string gender)
        {
            string hashedPassword = ComputeSha256Hash(password.Trim());
            Console.WriteLine("Contraseña original: " + password);
            Console.WriteLine("Hash que se guardará: " + hashedPassword);

            string sql = @"INSERT INTO Users (username, name, email, password, birthday, gender)
                   VALUES (@username, @name, @email, @password, @birthday, @gender)";

            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                cmd.Parameters.AddWithValue("@gender", gender);

                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar usuario: " + ex.Message);
                    return false;
                }
            }
        }
        //Función para dar de baja alguna cuenta de la base de datos 
        public bool DeleteAccount(string username, string password)
        {
            string hashedPassword = ComputeSha256Hash(password.Trim());

            string sql = @"DELETE FROM Users WHERE username = @username AND password = @password";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    Console.WriteLine("Deleting user ...");
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error when deleteing account: " + ex.Message);
                    return false;
                }
            }
        }
        //Función para cambiar cualquier dato del perfil
        public bool UpdateUser(string username, string name, string email, string password, string birthday, string gender)
        {
            string sql = @"UPDATE Users SET name = @name, email = @email, 
                         password = @password, birthday = @birthday, 
                         gender = @gender WHERE username = @username";

            string hashedPassword = ComputeSha256Hash(password.Trim());

            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@birthday", birthday);
                cmd.Parameters.AddWithValue("@gender", gender);

                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error on when updating user's changes: " + ex.Message);
                    return false;
                }
            }
        }
        //Comprueba si el usuario está en la base de datos
        public bool IsUserInDB(string username)
        {
            string sql = "SELECT COUNT(*) FROM Users WHERE username=@username";

            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@username", username);
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0; // retorna true o false 
            }
        }
        //Valida el inicio de sesión
        public bool ValidateLogin(string username, string password)
        {
            string sql = @"SELECT COUNT(*) FROM Users WHERE username = @username AND password = @password";

            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                string hash = ComputeSha256Hash(password.Trim());
                Console.WriteLine(hash);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hash);

                var result = Convert.ToInt32(cmd.ExecuteScalar());
                return result == 1;
            }
        }
        //Prueba a hacer el incio de sesión, en el caso de que se haga correctamente se actualiza el momento de la última conexión
        public bool TryLogin(string username, string password, out string errorMessage)
        {
            errorMessage = "";
            StartConnection();

            try
            {
                if (!ValidateLogin(username, password))
                {
                    errorMessage = "Incorrect Login Information! Try again.";
                    return false;
                }

                // Si el login es válido, actualiza la hora de último login
                string updateQuery = @"UPDATE Users SET LastLogin = @lastLogin WHERE username = @username";

                using (var cmd = new SQLiteCommand(updateQuery, GetConnection()))
                {
                    cmd.Parameters.AddWithValue("@lastLogin", DateTime.Now);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "Database error: " + ex.Message;
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }


        public DataTable GetUser(string username)
        // Getter of the specified user's information
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM Users WHERE username = @username";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.SelectCommand.Parameters.AddWithValue("@username", username);
            adp.Fill(dt);
            return dt;
        }

        //Codifica la contraseña, la hace más segura ya que es muy difícil de desencriptar.
        public string ComputeSha256Hash(string rawData)
        {
            rawData = rawData.Trim();
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }

        // Users Table ~~ Forgot Password --------------------------------------------
        //Se cambia la contraseña con el correo, dentro de las funciones del proceso de recuperar la contraseña
        public bool UpdatePasswordwithEmail(string email, string password)
        {
            string sql = @"UPDATE Users SET password = @password WHERE email = @email";

            string hashedPassword = ComputeSha256Hash(password.Trim());

            using (var cmd = new SQLiteCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error on when updating user's changes: " + ex.Message);
                    return false;
                }
            }
        }
        //Se extrae el correo del usuario a partir de su username.
        public string GetEmailwithUsername(string username)
        {
            string sql = "SELECT email FROM Users WHERE username = @username";
            using (var cmd = new SQLiteCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@username", username);
                var email = Convert.ToString(cmd.ExecuteScalar());
                return email;
            }
        }
        //Se obtiene la contraseña a partir del correo.
        public string GetPasswordwithEmail(string email)
        {
            string sql = "SELECT password FROM Users WHERE email = @email";
            using (var cmd = new SQLiteCommand(sql, cnx))
            {
                cmd.Parameters.AddWithValue("@email", email);
                var password = Convert.ToString(cmd.ExecuteScalar());
                return password;
            }
        }
        //Se comprueba que exista ese correo para ver si se puede introducir en la base de datos o ya existe una cuenta que lo usa.
        public bool EmailExists(string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE email = @email";

            using (var cmd = new SQLiteCommand(query, this.cnx))
            {
                cmd.Parameters.AddWithValue("@email", email);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        //Se envía el correo con el código de recuperación para recuperar la contraseña.
        public void EnviarEmail(string from, string to, string subject, string body)
        {
            try
            {
                // Configuración del mensaje de correo
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from); // Correo del remitente
                mail.To.Add(new MailAddress(to));    // Correo del destinatario
                mail.Subject = subject;              // Asunto del correo
                mail.Body = body;                    // Cuerpo del mensaje
                mail.IsBodyHtml = false;             // Cambiar a 'true' si se envía HTML

                // Configuración del cliente SMTP (ejemplo con Gmail)
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,               // Habilita SSL
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(from, Environment.GetEnvironmentVariable("DECONFLICTING_SMTP_PASSWORD"))
                };

                // Enviar el correo
                client.Send(mail);
                Console.WriteLine("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar correo: " + ex.Message);
            }
        }

        // ---------------------------------------------------------------------------

        // Airlines table ____________________________________________________________

        //Insertar la aerolínea en la base de datos a partir de sus datos.
        public bool InsertAirline(string name, string telephone, string email)
        {

            string sql = @"INSERT INTO Airlines (CompanyName, Telephone, Email)
                   VALUES (@companyName, @telephone, @email)";

            using (var cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@companyName", name);
                cmd.Parameters.AddWithValue("@telephone", telephone);
                cmd.Parameters.AddWithValue("@email", email);

                try
                {
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error inserting airline information: " + ex.Message);
                    return false;
                }
            }
        }
        //Elimina la aerolínea de la base de datos a partir de su nombre, no es necesario introducir el resto de sus datos.
        public bool DeleteAirline(string name)
        {
            string sql = @"DELETE FROM Airlines WHERE CompanyName = @companyName";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@companyName", name);

                try
                {
                    Console.WriteLine("Deleting airline information...");
                    return cmd.ExecuteNonQuery() == 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleteing airline information: " + ex.Message);
                    return false;
                }
            }
        }
        //Se obtiene la información de las aerolíneas en la base de datos, función clave para hacer el datagridview
        //en el forms en el que se muestran las aerolíneas.
        public (DataTable, bool) GetAirlinesInformationForAirlinesForm()
        {
            string query = @"SELECT CompanyName AS Airline, Telephone AS Telephone, Email AS Email FROM Airlines";
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteDataAdapter adp = new SQLiteDataAdapter(query, this.cnx))
                {
                    adp.Fill(dt);
                }

                bool found = dt.Rows.Count > 0;
                return (dt, found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving airlines information: " + ex.Message);
                return (new DataTable(), false);
            }
        }
        //Una función análoga, en algunos casos es más útil pero finalmente no se ha usado.
        public (DataTable, bool) GetAirlinesInformation()
        {
            string query = @"SELECT * FROM Airlines";
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteDataAdapter adp = new SQLiteDataAdapter(query, this.cnx))
                {
                    adp.Fill(dt);
                }

                bool found = dt.Rows.Count > 0;
                return (dt, found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving airlines information: " + ex.Message);
                return (new DataTable(), false);
            }
        }

        public (DataTable, bool) GetAirlineInformation(string name)
        {
            string query = @"SELECT * FROM Airlines WHERE CompanyName = @companyName";
            DataTable dt = new DataTable();
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(query, this.cnx))
                {
                    cmd.Parameters.AddWithValue("@companyName", name);

                    using (SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                    }
                }

                bool found = dt.Rows.Count > 0;
                return (dt, found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error retrieving airline information: " + ex.Message);
                return (new DataTable(), false);
            }
        }
        //Se crea una lista de aerolíneas con sus nombres.
        public List<string> GetAirlineNames()
        {
            List<string> list = new List<string>();

            var (dt, hasInfo) = GetAirlinesInformation();

            if (hasInfo)
            {
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(row["CompanyName"].ToString());
                }
            }
            return list.Distinct().ToList();
        }
        //Se comprueba si la aerolínea esta en la base de datos en el caso que se quiera añadir una.
        public bool IsAirlineInDb(string airline)
        {
            string sql = "SELECT COUNT(*) FROM Airlines WHERE CompanyName = @companyName COLLATE NOCASE";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, this.cnx))
            {
                cmd.Parameters.AddWithValue("@companyName", airline);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return (count > 0);
            }
        }
    }
}
