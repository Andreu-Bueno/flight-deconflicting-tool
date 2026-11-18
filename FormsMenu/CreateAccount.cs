using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib.IO;
using FontAwesome.Sharp;
using MySql.Data.MySqlClient;

namespace FormsMenu
{
    public partial class CreateAccountForm : Form
    {
        LoginForm loginForm;
        public CreateAccountForm(LoginForm form)
        // Initializes UI components and configures password textboxes
        {
            InitializeComponent();
            loginForm = form;

            txtPassword.UseSystemPasswordChar = true;
            txtCPassword.UseSystemPasswordChar = true;

            showPassword_btn.IconChar = IconChar.Eye;
            //Sets default icons for password visibility toggles
            showPassword_btn.IconFont = IconFont.Solid;

            showPasswordConf_btn.IconChar = IconChar.Eye;
            showPasswordConf_btn.IconFont = IconFont.Solid;

            login_link.LinkColor = Color.LightGray;

            createAccount_btn_Style();
        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        //Populates the gender dropdown with Male and Female options
        {
            cboGender.Items.Add("Female");
            cboGender.Items.Add("Male");
            cboGender.Items.Add("Others");

        }
        private void createAccount_btn_Style()
        // To put the style an icons to the button
        {
            createAccount_btn.Image = Properties.Resources.arrow_btn_access;
            createAccount_btn.ImageAlign = ContentAlignment.MiddleCenter;
            createAccount_btn.Size = new Size(53, 53); // Ajusta según el tamaño de tu imagen


            createAccount_btn.Image = Properties.Resources.arrow_right_grey; // Imagen inicial
            createAccount_btn.BackColor = Color.Transparent;

            // Eventos hover
            createAccount_btn.MouseEnter += (sender, e) =>
            {
                createAccount_btn.Image = Properties.Resources.arrow_btn_access;
                createAccount_btn.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            createAccount_btn.MouseLeave += (sender, e) =>
            {
                createAccount_btn.Image = Properties.Resources.arrow_right_grey;
                createAccount_btn.BackColor = Color.Transparent;
            };

            // Eventos hover
            createAccount_btn.Enter += (sender, e) =>
            {
                createAccount_btn.Image = Properties.Resources.arrow_btn_access;
                createAccount_btn.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            createAccount_btn.Leave += (sender, e) =>
            {
                createAccount_btn.Image = Properties.Resources.arrow_right_grey;
                createAccount_btn.BackColor = Color.Transparent;
            };
        }

        private void createAccount_btn_Click(object sender, EventArgs e)
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
                errorProvider1.SetError(noDataInserted_lbl, "Please fill out all information!");
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




            FlightDBManager dBManager = new FlightDBManager();

            try
            {

                dBManager.StartConnection();


                if (dBManager.IsUserInDB(txtUsername.Text))
                {

                    MessageBox.Show("Username not available. Try again.");
                    return;
                }

                if (dBManager.EmailExists(txtEmail.Text))
                {
                    MessageBox.Show("Email not available. Try again.");
                    return;
                }

                bool success = dBManager.InsertarUsuario(
                    txtUsername.Text,
                    txtFName.Text + " " + txtLName.Text,
                    txtEmail.Text,
                    txtPassword.Text,
                    dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                    cboGender.Text
                    );

                if (success)
                {
                    MessageBox.Show("Account successfully created.");
                    loginForm.Visible = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Account creation failed.");
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //Returns to the login form
        {
            loginForm.Visible = true;
            this.Close();
        }

        private void login_link_MouseEnter(object sender, EventArgs e)
        // When the mouse enters the link area it turns the link text to light red
        {
            login_link.LinkColor = Color.LightCoral;
        }

        private void login_link_MouseLeave(object sender, EventArgs e)
        // When the mouse leaves the link area it turns the link text to gray 
        {
            login_link.LinkColor = Color.LightGray;
        }
    }
}
