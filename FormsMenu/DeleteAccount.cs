using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib.IO;
using FontAwesome.Sharp;

namespace FormsMenu
{
    //Form para eliminar alguna cuenta de la base de datos, en caso de que elimines tu cuenta te hace el log out.
    public partial class DeleteAccount : Form
    {
        //Atributos de la clase
        FlightDBManager dBManager = new FlightDBManager();
        LoginForm loginForm;
        FormsMenu menu;
        bool hasTxtUsernameBeenClicked = false;
        bool hasTxtPasswordBeenClicked = false;

        public DeleteAccount(LoginForm form, FormsMenu form2)
        {
            InitializeComponent();
            loginForm = form;
            menu = form2;


            showPassword_btn.IconChar = IconChar.EyeSlash;
            showPassword_btn.IconFont = IconFont.Solid;

            btnDelete_Style();
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.Visible = false;
            }
        }
        //Confirmas que quieres eliminar tu cuenta, con su respectiva comprobación de errores.
        private void btnDelete_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }

            else
            {
                try
                {
                    dBManager.StartConnection();

                    bool validLogin = dBManager.ValidateLogin(txtUsername.Text, txtPassword.Text);

                    if (validLogin)
                    {
                        dBManager.DeleteAccount(txtUsername.Text, txtPassword.Text);
                        MessageBox.Show("The account has been successfully deleted.");
                        this.Hide();
                        loginForm.Visible = true;
                        menu.Close();
                        this.Close();
                    }
                    else
                    {
                        txtPassword.BackColor = Color.LightCoral;
                        txtUsername.BackColor = Color.LightCoral;

                        errorProvider1.SetError(txtPassword, "Incorrect Login Information! Try again.");
                        errorProvider1.SetError(txtUsername, "Incorrect Login Information! Try again.");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error ocurred: " + ex.Message);
                }
                finally
                {
                    dBManager.CloseConnection();
                }
            }
        }
        //Funciones para mejorar la estética y legibilidad
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                showPassword_btn.Visible = true;
            }
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasTxtUsernameBeenClicked)
            {
                txtUsername.Text = string.Empty;
            }
            else if (txtUsername.Text == "Username")
            {
                txtUsername.Text = string.Empty;
            }
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.Visible = false;
                txtPassword.Text = "Password";
            }
            hasTxtUsernameBeenClicked = true;
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (!hasTxtPasswordBeenClicked)
            {
                txtPassword.Text = string.Empty;
                txtPassword.UseSystemPasswordChar = true;
            }
            else if (txtPassword.Text == "Password")
            {
                txtPassword.Text = string.Empty;
                txtPassword.UseSystemPasswordChar = false;
            }
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
            hasTxtPasswordBeenClicked = true;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (!hasTxtPasswordBeenClicked)
            {
                txtPassword.Text = string.Empty;
                txtPassword.UseSystemPasswordChar = true;
            }
            else if (txtPassword.Text == "Password")
            {
                txtPassword.Text = string.Empty;
                txtPassword.UseSystemPasswordChar = true;
            }
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
            hasTxtPasswordBeenClicked = true;
        }

        private void showPassword_btn_Click(object sender, EventArgs e)
        {
            // Cambiar la visibilidad de la contraseña
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.IconChar = FontAwesome.Sharp.IconChar.EyeSlash; // Cambiar a "Ojo Cerrado"
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                showPassword_btn.IconChar = FontAwesome.Sharp.IconChar.Eye; // Cambiar a "Ojo Abierto"
            }
        }

        private void btnDelete_Style()
        {
            btnDelete.Image = Properties.Resources.arrow_btn_access;
            btnDelete.ImageAlign = ContentAlignment.MiddleCenter;
            btnDelete.Size = new Size(53, 53); // Ajusta según el tamaño de tu imagen


            btnDelete.Image = Properties.Resources.arrow_right_grey; // Imagen inicial
            btnDelete.BackColor = Color.Transparent;

            // Eventos hover
            btnDelete.MouseEnter += (sender, e) =>
            {
                btnDelete.Image = Properties.Resources.arrow_btn_access;
                btnDelete.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            btnDelete.MouseLeave += (sender, e) =>
            {
                btnDelete.Image = Properties.Resources.arrow_right_grey;
                btnDelete.BackColor = Color.Transparent;
            };

            // Eventos hover
            btnDelete.Enter += (sender, e) =>
            {
                btnDelete.Image = Properties.Resources.arrow_btn_access;
                btnDelete.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            btnDelete.Leave += (sender, e) =>
            {
                btnDelete.Image = Properties.Resources.arrow_right_grey;
                btnDelete.BackColor = Color.Transparent;
            };
        }
    }
}
