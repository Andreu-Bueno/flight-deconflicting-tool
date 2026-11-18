using FlightLib.IO;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsMenu
{
    public partial class EditUserForm : Form
    {
        string username;
        string password;
        FlightDBManager dBManager = new FlightDBManager();

        public EditUserForm(string Username, string Password)
        {
            InitializeComponent();

            username = Username;
            password = Password;
            txtPassword.UseSystemPasswordChar = true;
            txtCPassword.UseSystemPasswordChar = true;

            showPassword_btn.IconChar = IconChar.Eye;
            //Sets default icons for password visibility toggles
            showPassword_btn.IconFont = IconFont.Solid;

            showPasswordConf_btn.IconChar = IconChar.Eye;
            showPasswordConf_btn.IconFont = IconFont.Solid;

            modifyAccount_btn_Style();

        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Others");

            dBManager.StartConnection();
            DataTable dt = dBManager.GetUser(username);
            string Username = dt.Rows[0]["username"].ToString();
            string Name = dt.Rows[0]["Name"].ToString();
            string[] NameSurname = Name.Split(' ');
            string FirstName = NameSurname[0];
            string LastName = NameSurname[1];
            if (NameSurname.Length > 2)
            {
                for (int i = 1; i < NameSurname.Length; i++)
                    LastName = LastName + ' ' + NameSurname[i];
            }
            string email = dt.Rows[0]["email"].ToString();
            string hash = dt.Rows[0]["password"].ToString();
            string birthday = dt.Rows[0]["birthday"].ToString();
            DateTime date = DateTime.Parse(birthday);
            string gender = dt.Rows[0]["gender"].ToString();
            txtUsername.Text = Username;
            txtFName.Text = FirstName;
            txtLName.Text = LastName;
            txtEmail.Text = email;
            string checkhash = dBManager.ComputeSha256Hash(password);
            if (checkhash == hash)
            {
                txtPassword.Text = password;
            }
            else
            {
                errorProvider1.SetError(txtPassword, "Error: Passwords doesn't seem to match");
            }
            dateTimePicker1.Value = date;
            cboGender.SelectedItem = gender;
        }


        private void modifyAccount_btn_Style()
        // To put the style an icons to the button
        {
            modifyAccount_btn.Image = Properties.Resources.arrow_btn_access;
            modifyAccount_btn.ImageAlign = ContentAlignment.MiddleCenter;
            modifyAccount_btn.Size = new Size(53, 53); // Ajusta según el tamaño de tu imagen


            modifyAccount_btn.Image = Properties.Resources.arrow_right_grey; // Imagen inicial
            modifyAccount_btn.BackColor = Color.Transparent;

            // Eventos hover
            modifyAccount_btn.MouseEnter += (sender, e) =>
            {
                modifyAccount_btn.Image = Properties.Resources.arrow_btn_access;
                modifyAccount_btn.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            modifyAccount_btn.MouseLeave += (sender, e) =>
            {
                modifyAccount_btn.Image = Properties.Resources.arrow_right_grey;
                modifyAccount_btn.BackColor = Color.Transparent;
            };

            // Eventos hover
            modifyAccount_btn.Enter += (sender, e) =>
            {
                modifyAccount_btn.Image = Properties.Resources.arrow_btn_access;
                modifyAccount_btn.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            modifyAccount_btn.Leave += (sender, e) =>
            {
                modifyAccount_btn.Image = Properties.Resources.arrow_right_grey;
                modifyAccount_btn.BackColor = Color.Transparent;
            };
        }


        private void modifyAccount_btn_Click(object sender, EventArgs e)
        {
            //Creates the account of the user and provides error messages if needed (e.g in case of an empty field)
            {
                errorProvider1.Clear();

                if (string.IsNullOrEmpty(txtFName.Text) ||
                    string.IsNullOrEmpty(txtLName.Text) ||
                    string.IsNullOrEmpty(cboGender.Text) ||
                    string.IsNullOrEmpty(txtEmail.Text) ||
                    string.IsNullOrEmpty(txtUsername.Text) ||
                    string.IsNullOrEmpty(txtPassword.Text) ||
                    string.IsNullOrEmpty(txtCPassword.Text))
                {
                    MessageBox.Show("Please fill out all information!", "Error");
                    return;
                }
                if (txtPassword.Text.Contains(' '))
                {
                    errorProvider1.SetError(txtPassword, "Error: Don't introduce spaces");
                    return;
                }

                if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
                {
                    errorProvider1.SetError(txtEmail, "Error: Invalid email. Please enter a valid email");
                    //MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!this.txtEmail.Text.Contains("@gmail") && !this.txtEmail.Text.Contains("@hotmail") && !this.txtEmail.Text.Contains("@estudiantat.upc.edu") && !this.txtEmail.Text.Contains("@outlook"))
                {
                    errorProvider1.SetError(txtEmail, "Error: Invalid email service. Please enter a valid service (gmail, hotmail, outlook, estudiantat.upc.edu)");
                    return;
                }
                if ((this.txtEmail.Text.Contains("@gmail") || this.txtEmail.Text.Contains("@hotmail") || this.txtEmail.Text.Contains("@outlook")) && (!this.txtEmail.Text.EndsWith("cat") && !this.txtEmail.Text.EndsWith("com") && !this.txtEmail.Text.EndsWith("es") && !this.txtEmail.Text.EndsWith("net")))
                {
                    errorProvider1.SetError(txtEmail, "Error: Invalid email domain. Please enter a valid domain (.cat, .com, .es, .net)");
                    return;
                }

                if (txtPassword.Text.Length < 8)
                {
                    errorProvider1.SetError(txtPassword, "The password must contain at least 8 characters");
                    return;
                }

                bool contieneLetra = txtPassword.Text.Any(char.IsLetter);
                bool contieneNumero = txtPassword.Text.Any(char.IsDigit);
                if (!contieneLetra || !contieneNumero)
                {
                    errorProvider1.SetError(txtPassword, "The password must contain letters and numbers");
                    return;
                }


                if (txtPassword.Text != txtCPassword.Text)
                {
                    errorProvider1.SetError(txtCPassword, "Passwords don't match!");
                    return;
                }


                try
                {

                    bool success = dBManager.UpdateUser(
                        txtUsername.Text,
                        txtFName.Text + " " + txtLName.Text,
                        txtEmail.Text,
                        txtPassword.Text,
                        dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                        cboGender.Text
                        );

                    if (success)
                    {
                        MessageBox.Show("Account successfully modyfied.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account modification failed.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    dBManager.CloseConnection();
                }
            }
        }

        private void showPassword_btn_Click(object sender, EventArgs e)
        //Shows the password to the user
        {
            // Cambiar la visibilidad de la contraseña
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.IconChar = IconChar.EyeSlash; // Cambiar a "Ojo Cerrado"
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                showPassword_btn.IconChar = IconChar.Eye; // Cambiar a "Ojo Abierto"
            }
        }

        private void showPasswordConf_btn_Click(object sender, EventArgs e)
        {
            // Cambiar la visibilidad de la contraseña
            if (txtCPassword.UseSystemPasswordChar)
            {
                txtCPassword.UseSystemPasswordChar = false;
                showPasswordConf_btn.IconChar = IconChar.EyeSlash; // Cambiar a "Ojo Cerrado"
            }
            else
            {
                txtCPassword.UseSystemPasswordChar = true;
                showPasswordConf_btn.IconChar = IconChar.Eye; // Cambiar a "Ojo Abierto"
            }
        }
    }
}
