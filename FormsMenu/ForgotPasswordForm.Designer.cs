namespace FormsMenu
{
    partial class ForgotPasswordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SendEmailAgainlbl = new System.Windows.Forms.LinkLabel();
            this.BtnSend = new System.Windows.Forms.Button();
            this.txtEmailorUsername_Code = new System.Windows.Forms.TextBox();
            this.AdaptativeLbl = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SendEmailAgainlbl
            // 
            this.SendEmailAgainlbl.AutoSize = true;
            this.SendEmailAgainlbl.Location = new System.Drawing.Point(99, 157);
            this.SendEmailAgainlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SendEmailAgainlbl.Name = "SendEmailAgainlbl";
            this.SendEmailAgainlbl.Size = new System.Drawing.Size(157, 13);
            this.SendEmailAgainlbl.TabIndex = 7;
            this.SendEmailAgainlbl.TabStop = true;
            this.SendEmailAgainlbl.Text = "Email Has Not Been Recieved?";
            this.SendEmailAgainlbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SendEmailAgainlbl_LinkClicked_1);
            // 
            // BtnSend
            // 
            this.BtnSend.Location = new System.Drawing.Point(142, 115);
            this.BtnSend.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSend.Name = "BtnSend";
            this.BtnSend.Size = new System.Drawing.Size(67, 25);
            this.BtnSend.TabIndex = 6;
            this.BtnSend.Text = "Send";
            this.BtnSend.UseVisualStyleBackColor = true;
            this.BtnSend.Click += new System.EventHandler(this.BtnSend_Click_1);
            // 
            // txtEmailorUsername_Code
            // 
            this.txtEmailorUsername_Code.Location = new System.Drawing.Point(85, 85);
            this.txtEmailorUsername_Code.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailorUsername_Code.Name = "txtEmailorUsername_Code";
            this.txtEmailorUsername_Code.Size = new System.Drawing.Size(182, 20);
            this.txtEmailorUsername_Code.TabIndex = 5;
            // 
            // AdaptativeLbl
            // 
            this.AdaptativeLbl.AutoSize = true;
            this.AdaptativeLbl.Location = new System.Drawing.Point(94, 61);
            this.AdaptativeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AdaptativeLbl.Name = "AdaptativeLbl";
            this.AdaptativeLbl.Size = new System.Drawing.Size(164, 13);
            this.AdaptativeLbl.TabIndex = 4;
            this.AdaptativeLbl.Text = "Insert email address or username:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 226);
            this.Controls.Add(this.SendEmailAgainlbl);
            this.Controls.Add(this.BtnSend);
            this.Controls.Add(this.txtEmailorUsername_Code);
            this.Controls.Add(this.AdaptativeLbl);
            this.Name = "ForgotPasswordForm";
            this.Text = "ForgotPasswordForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel SendEmailAgainlbl;
        private System.Windows.Forms.Button BtnSend;
        private System.Windows.Forms.TextBox txtEmailorUsername_Code;
        private System.Windows.Forms.Label AdaptativeLbl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}