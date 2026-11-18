using FlightLib.IO;
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
    public partial class AirlinesForm : Form
    {
        // Atributtes

        FlightDBManager dBManager = new FlightDBManager();
        DataTable dt;
        bool hasTxtAirlineBeenClicked = false;
        bool hasTxtTelephoneBeenClicked = false;
        bool hasTxtEmailBeenClicked = false;


        //Muestra en un datagridview todos los datos de las aerolíneas que se encuentran en la base de datos.
        public AirlinesForm()
        {
            InitializeComponent();

            dBManager.StartConnection();
            LoadAirlinesData();
            airlinesGridView.RowHeadersVisible = false;
            airlinesGridView.Columns["Airline"].Width = 120;
            airlinesGridView.Columns["Telephone"].Width = 135;
            airlinesGridView.Columns["Email"].Width = 260; //Columna más ancha para que se vea el correo al completo.
            airlinesGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSeaGreen;
            airlinesGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Color del texto
            airlinesGridView.EnableHeadersVisualStyles = false; // Importante para que funcione
        }
        //Carga las aerolíneas de la base de datos para ponerlas en el datagridview.
        private void LoadAirlinesData()
        {
            var (dt, hasBeenImported) = dBManager.GetAirlinesInformationForAirlinesForm();
            if (hasBeenImported)
            {
                airlinesGridView.DataSource = dt;
                lblLoadingData.Text = "Information loaded successfully";
            }
            else
            {
                lblLoadingData.Text = "Error retrieving airlanes information";
            }

        }
        //Elimina una aerolínea de la base de datos usando únicamente su nombre.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = Convert.ToString(txtAirline.Text);
            bool done = dBManager.DeleteAirline(name);
            if (txtAirline.Text == "Airline")
            {
                errorProvider1.SetError(txtAirline, "Introduce the airline");
            }
            if (string.IsNullOrWhiteSpace(name))
            {

                txtAirline.Focus();
                errorProvider1.SetError(txtAirline, "Please introduce an airline name.");
                return;
            }
            if (done)
            {
                lblLoadingData.Text = "Delete done successfully";
                LoadAirlinesData();
            }
            else
            {
                lblLoadingData.Text = "This airline is not on the database";
            }
        }
        //Inserta una aerolínea en la base de datos con sus datos que son introducidos en un BoxTxt.
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener valores de los controles del formulario (ajusta según tus controles)
                string name = txtAirline.Text.Trim();
                string telephone = txtTelephone.Text.Trim();
                string email = txtEmail.Text.Trim();
                if (txtAirline.Text == "Airline")
                {
                    errorProvider1.SetError(txtAirline, "Introduce the airline");
                }
                if (txtTelephone.Text == "Telephone")
                {
                    errorProvider1.SetError(txtTelephone, "Introduce the telephone");
                }
                if (txtEmail.Text == "Email")
                {
                    errorProvider1.SetError(txtEmail, "Introduce the email");
                }

                // Validaciones básicas en el UI
                if (string.IsNullOrWhiteSpace(name))
                {
                    errorProvider1.SetError(txtAirline, "Please introduce an airline name.");
                    txtAirline.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(telephone))
                {
                    errorProvider1.SetError(txtTelephone, "Please introduce the airline telephone.");
                    txtTelephone.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(email))
                {
                    errorProvider1.SetError(txtEmail, "Please introduce the email of the airline.");
                    txtEmail.Focus();
                    return;
                }

                // Intentar insertar
                bool success = dBManager.InsertAirline(name, telephone, email);

                if (success)
                {
                    lblLoadingData.Text = "Airline added successfully!";

                    // Limpiar campos
                    txtAirline.Clear();
                    txtTelephone.Clear();
                    txtEmail.Clear();

                    // Actualizar el DataGridView
                    LoadAirlinesData();
                }
                else
                {
                    lblLoadingData.Text = "The airline could not be added. It may already exist.";
                }
            }
            catch (Exception ex)
            {
                lblLoadingData.Text = $"Error: {ex.Message}, Database Error";

            }
        }
        //Se pone la palabra Airline cuando clicamos en otra celda siempre que no hayamos añadido nada.
        private void txtAirline_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasTxtAirlineBeenClicked)
            {
                txtAirline.Text = string.Empty;
            }
            else if (txtAirline.Text == "Airline")
            {
                txtAirline.Text = string.Empty;
            }
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "Telephone";
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
            hasTxtAirlineBeenClicked = true;
        }
        //Se pone Telephone en su respectivo BoxText cuando abandonamos dicha celda y no hemos realizado ningún cambio.
        private void txtTelephone_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasTxtTelephoneBeenClicked)
            {
                txtTelephone.Text = string.Empty;
            }
            else if (txtTelephone.Text == "Telephone")
            {
                txtTelephone.Text = string.Empty;
            }
            if (txtAirline.Text == "")
            {
                txtAirline.Text = "Airline";
            }
            if (txtEmail.Text == "")
            {
                txtEmail.Text = "Email";
            }
            hasTxtAirlineBeenClicked = true;
        }
        //Se pone Email en su respectivo BoxText cuando abandonamos dicha celda y no hemos realizado ningún cambio.
        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasTxtEmailBeenClicked)
            {
                txtEmail.Text = string.Empty;
            }
            else if (txtEmail.Text == "Email")
            {
                txtEmail.Text = string.Empty;
            }
            if (txtAirline.Text == "")
            {
                txtAirline.Text = "Airline";
            }
            if (txtTelephone.Text == "")
            {
                txtTelephone.Text = "Telephone";
            }
            hasTxtAirlineBeenClicked = true;
        }
    }
}
