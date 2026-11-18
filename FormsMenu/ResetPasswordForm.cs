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
    public partial class ResetPasswordForm : Form
    {
        string email;
        FlightDBManager dBManager = new FlightDBManager();
        public ResetPasswordForm(string To)
        {
            InitializeComponent();
            email = To;

            showPassword_Btn.IconChar = IconChar.Eye;
            //Sets default icons for password visibility toggles
            showPassword_Btn.IconFont = IconFont.Solid;

            showCnfPassword_Btn.IconChar = IconChar.Eye;
            showCnfPassword_Btn.IconFont = IconFont.Solid;

            txtPassword.UseSystemPasswordChar = true;
            txtRPassword.UseSystemPasswordChar = true;

        }

        //Crea una nueva contraseña comprobando que cumpla
        //con los requisitos de seguridad (mix de letras y números, sin espacios y mínimo 8 carácteres).
        private void btnApply_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Please input the new password");
                return;
            }
            if (string.IsNullOrEmpty(txtRPassword.Text))
            {
                errorProvider1.SetError(txtRPassword, "Please input the password again");
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
            if (txtPassword.Text != txtRPassword.Text)
            {
                errorProvider1.SetError(txtRPassword, "Passwords don't match");
                return;
            }
            else
            {
                dBManager.StartConnection();
                string hash = dBManager.ComputeSha256Hash(txtPassword.Text);
                if (hash == dBManager.GetPasswordwithEmail(email))
                {
                    errorProvider1.SetError(txtPassword, "Password can't be the same as the previous one");
                    return;
                }
                else
                {
                    dBManager.UpdatePasswordwithEmail(email, txtPassword.Text);
                    MessageBox.Show("Password changed with success");
                    this.Close();
                }
                dBManager.CloseConnection();
            }
        }

        private void showPassword_Btn_Click(object sender, EventArgs e)
        //Shows the password to the user
        {
            // Cambiar la visibilidad de la contraseña
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                showPassword_Btn.IconChar = IconChar.EyeSlash; // Cambiar a "Ojo Cerrado"
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                showPassword_Btn.IconChar = IconChar.Eye; // Cambiar a "Ojo Abierto"
            }
        }

        private void showCnfPassword_Btn_Click(object sender, EventArgs e)
        {
            // Cambiar la visibilidad de la contraseña
            if (txtRPassword.UseSystemPasswordChar)
            {
                txtRPassword.UseSystemPasswordChar = false;
                showCnfPassword_Btn.IconChar = IconChar.EyeSlash; // Cambiar a "Ojo Cerrado"
            }
            else
            {
                txtRPassword.UseSystemPasswordChar = true;
                showCnfPassword_Btn.IconChar = IconChar.Eye; // Cambiar a "Ojo Abierto"
            }
        }
    }
}
