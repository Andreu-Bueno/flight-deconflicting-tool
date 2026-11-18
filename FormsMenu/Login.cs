using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    public partial class LoginForm : Form
    {
        //Atributos
        FlightDBManager dBManager = new FlightDBManager();
        bool hasTxtPasswordBeenClicked = false;
        bool hasTxtUsernameBeenClicked = false;


        public LoginForm()
        {
            InitializeComponent();
            showPassword_btn.IconChar = IconChar.EyeSlash;
            showPassword_btn.IconFont = IconFont.Solid;

            btnLogin_Style();
            createAccount_link.LinkColor = Color.WhiteSmoke;
            forgotPasword_link.LinkColor = Color.WhiteSmoke;

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.Visible = false;
            }
        }

        private void btnLogin_Style()
        {
            btnLogin.Image = Properties.Resources.arrow_btn_access;
            btnLogin.ImageAlign = ContentAlignment.MiddleCenter;
            btnLogin.Size = new Size(53, 53); // Ajusta según el tamaño de tu imagen


            btnLogin.Image = Properties.Resources.arrow_right_grey; // Imagen inicial
            btnLogin.BackColor = Color.Transparent;

            // Eventos hover
            btnLogin.MouseEnter += (sender, e) =>
            {
                btnLogin.Image = Properties.Resources.arrow_btn_access;
                btnLogin.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            btnLogin.MouseLeave += (sender, e) =>
            {
                btnLogin.Image = Properties.Resources.arrow_right_grey;
                btnLogin.BackColor = Color.Transparent;
            };

            // Eventos hover
            btnLogin.Enter += (sender, e) =>
            {
                btnLogin.Image = Properties.Resources.arrow_btn_access;
                btnLogin.BackColor = Color.FromArgb(150, 255, 70, 85); // Rojo Riot
            };

            btnLogin.Leave += (sender, e) =>
            {
                btnLogin.Image = Properties.Resources.arrow_right_grey;
                btnLogin.BackColor = Color.Transparent;
            };
        }
        //Intenta hacer el incio de sesión comprobando que el usuario y la contraseña coincidan con los de la base de datos.
        private void btnLogin_Click(object sender, EventArgs e)
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

                    if (dBManager.TryLogin(txtUsername.Text, txtPassword.Text, out string errorMsg))
                    {
                        this.Hide();
                        FormsMenu frm2 = new FormsMenu(dBManager.GetConnection(), this, txtUsername.Text, txtPassword.Text);
                        frm2.ShowDialog();
                    }
                    else
                    {
                        txtPassword.BackColor = Color.LightCoral;
                        txtUsername.BackColor = Color.LightCoral;
                        showPassword_btn.BackColor = Color.LightCoral;
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
        //Abre el forms para crear una cuenta nueva.
        private void btnCreate_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateAccountForm frm3 = new CreateAccountForm(this);
            frm3.ShowDialog();

        }
        //Muestra la contraseña que hemos escrito mediante el ojo.
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
        //Funciones para que sea más legible la información dentro del TextBox
        private void LoginForm_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
            }
            if (txtPassword.Text == "")
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_btn.Visible = false;
                txtPassword.Text = "Password";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                showPassword_btn.Visible = true;
            }
        }

        // Evento para escritura de Username y Password en los textBox
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

        // Evento para escritura de Username y Password en los textBox
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

        // Evento para escritura de Username y Password en los textBox
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

        //Abre el forms para recuperar la contraseña.
        private void createAccount_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            CreateAccountForm frm3 = new CreateAccountForm(this);
            frm3.ShowDialog();
            this.Show();
        }

        private void linkLabel1_MouseEnter(object sender, EventArgs e)
        {
            createAccount_link.LinkColor = Color.DarkRed;
        }

        private void createAccount_link_MouseLeave(object sender, EventArgs e)
        {
            createAccount_link.LinkColor = Color.WhiteSmoke;
        }
        //Abre el forms para recuperar la contraseña.
        private void forgotPasword_link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPasswordForm frm4 = new ForgotPasswordForm();
            frm4.ShowDialog();
            this.Show();
        }

        private void forgotPasword_link_MouseEnter(object sender, EventArgs e)
        {
            forgotPasword_link.LinkColor = Color.DarkRed;
        }

        private void forgotPasword_link_MouseLeave(object sender, EventArgs e)
        {
            forgotPasword_link.LinkColor = Color.WhiteSmoke;
        }
    }
}
