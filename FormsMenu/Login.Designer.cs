namespace FormsMenu
{
    partial class LoginForm
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
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.showPassword_btn = new FontAwesome.Sharp.IconPictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.createAccount_link = new System.Windows.Forms.LinkLabel();
            this.forgotPasword_link = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Menu;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtUsername.Location = new System.Drawing.Point(48, 61);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtUsername.MaxLength = 25;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(285, 22);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Text = "Username";
            this.txtUsername.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUsername_MouseClick);
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPassword.Location = new System.Drawing.Point(48, 127);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(285, 22);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.Text = "Password";
            this.txtPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtPassword_MouseClick);
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(165, 163);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(53, 53);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // showPassword_btn
            // 
            this.showPassword_btn.BackColor = System.Drawing.SystemColors.Menu;
            this.showPassword_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showPassword_btn.IconColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showPassword_btn.IconSize = 22;
            this.showPassword_btn.ImageLocation = "";
            this.showPassword_btn.Location = new System.Drawing.Point(311, 127);
            this.showPassword_btn.Name = "showPassword_btn";
            this.showPassword_btn.Size = new System.Drawing.Size(22, 22);
            this.showPassword_btn.TabIndex = 6;
            this.showPassword_btn.TabStop = false;
            this.showPassword_btn.Click += new System.EventHandler(this.showPassword_btn_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(113, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 38);
            this.label3.TabIndex = 7;
            this.label3.Text = "Login";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // createAccount_link
            // 
            this.createAccount_link.AutoSize = true;
            this.createAccount_link.BackColor = System.Drawing.Color.Transparent;
            this.createAccount_link.DisabledLinkColor = System.Drawing.Color.White;
            this.createAccount_link.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.createAccount_link.LinkColor = System.Drawing.Color.White;
            this.createAccount_link.Location = new System.Drawing.Point(151, 301);
            this.createAccount_link.Name = "createAccount_link";
            this.createAccount_link.Size = new System.Drawing.Size(80, 13);
            this.createAccount_link.TabIndex = 8;
            this.createAccount_link.TabStop = true;
            this.createAccount_link.Text = "Create account";
            this.createAccount_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createAccount_link_LinkClicked);
            this.createAccount_link.MouseEnter += new System.EventHandler(this.linkLabel1_MouseEnter);
            this.createAccount_link.MouseLeave += new System.EventHandler(this.createAccount_link_MouseLeave);
            // 
            // forgotPasword_link
            // 
            this.forgotPasword_link.AutoSize = true;
            this.forgotPasword_link.BackColor = System.Drawing.Color.Transparent;
            this.forgotPasword_link.LinkColor = System.Drawing.Color.White;
            this.forgotPasword_link.Location = new System.Drawing.Point(136, 281);
            this.forgotPasword_link.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.forgotPasword_link.Name = "forgotPasword_link";
            this.forgotPasword_link.Size = new System.Drawing.Size(114, 13);
            this.forgotPasword_link.TabIndex = 10;
            this.forgotPasword_link.TabStop = true;
            this.forgotPasword_link.Text = "Forgot your password?";
            this.forgotPasword_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.forgotPasword_link_LinkClicked);
            this.forgotPasword_link.MouseEnter += new System.EventHandler(this.forgotPasword_link_MouseEnter);
            this.forgotPasword_link.MouseLeave += new System.EventHandler(this.forgotPasword_link_MouseLeave);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::FormsMenu.Properties.Resources.foto_avion;
            this.ClientSize = new System.Drawing.Size(385, 335);
            this.Controls.Add(this.forgotPasword_link);
            this.Controls.Add(this.createAccount_link);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.showPassword_btn);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Click += new System.EventHandler(this.LoginForm_Click);
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private FontAwesome.Sharp.IconPictureBox showPassword_btn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel createAccount_link;
        private System.Windows.Forms.LinkLabel forgotPasword_link;
    }
}