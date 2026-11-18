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
    //Form para recuperar la contraseña mediante el correo
    public partial class ForgotPasswordForm : Form
    {
        FlightDBManager dBManager = new FlightDBManager();
        int code = new Random().Next(100000, 1000000);
        string body = "Hi user, the password reset code is: ";
        string subject = "Password reset";
        int clickcount;
        string To;

        public ForgotPasswordForm()
        {
            InitializeComponent();
            clickcount = 0;
        }

        //Mediante el click se envía un correo con un código al azar
        private void BtnSend_Click_1(object sender, EventArgs e)
        {
            if (clickcount == 0)
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtEmailorUsername_Code.Text))
                {
                    errorProvider1.SetError(txtEmailorUsername_Code, "Please input email address or username");
                    return;
                }
                else
                {
                    dBManager.StartConnection();
                    if (txtEmailorUsername_Code.Text.Contains("@gmail") || txtEmailorUsername_Code.Text.Contains("@hotmail") || txtEmailorUsername_Code.Text.Contains("@outlook") || txtEmailorUsername_Code.Text.Contains("@estudiantat.upc.edu"))
                    {
                        To = txtEmailorUsername_Code.Text;
                        if (dBManager.EmailExists(To))
                        {
                            dBManager.EnviarEmail("deconflictingtool.g01@gmail.com", To, subject, body + ' ' + code);
                            txtEmailorUsername_Code.Clear();
                            AdaptativeLbl.Text = "Insert the given code:";
                            clickcount++;
                        }
                        else
                        {
                            errorProvider1.SetError(txtEmailorUsername_Code, "The email is not found in the database");
                        }

                    }
                    else
                    {
                        if (dBManager.IsUserInDB(txtEmailorUsername_Code.Text))
                        {
                            To = dBManager.GetEmailwithUsername(txtEmailorUsername_Code.Text);
                            dBManager.EnviarEmail("deconflictingtool.g01@gmail.com", To, subject, body + ' ' + code);
                            txtEmailorUsername_Code.Clear();
                            AdaptativeLbl.Text = "Insert the given code:";
                            clickcount++;
                        }
                        else
                        {
                            errorProvider1.SetError(txtEmailorUsername_Code, "The username is not found in the database");
                        }
                    }
                    dBManager.CloseConnection();
                }
            }
            else
            {
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(txtEmailorUsername_Code.Text))
                {
                    errorProvider1.SetError(txtEmailorUsername_Code, "Please input the code");
                    return;
                }
                else
                {
                    if (txtEmailorUsername_Code.Text == Convert.ToString(code))
                    {
                        this.Hide();
                        ResetPasswordForm frm5 = new ResetPasswordForm(To);
                        frm5.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        errorProvider1.SetError(txtEmailorUsername_Code, "Error: Wrong code");
                        return;
                    }
                }
            }
        }

        private void SendEmailAgainlbl_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clickcount = 0;
            AdaptativeLbl.Text = "Insert email address or username again:";
        }
    }
}
