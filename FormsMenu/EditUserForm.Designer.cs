namespace FormsMenu
{
    partial class EditUserForm
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
            this.modifyAccount_btn = new System.Windows.Forms.Button();
            this.showPasswordConf_btn = new FontAwesome.Sharp.IconPictureBox();
            this.showPassword_btn = new FontAwesome.Sharp.IconPictureBox();
            this.txtCPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.showPasswordConf_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // modifyAccount_btn
            // 
            this.modifyAccount_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyAccount_btn.Location = new System.Drawing.Point(228, 395);
            this.modifyAccount_btn.Margin = new System.Windows.Forms.Padding(2);
            this.modifyAccount_btn.Name = "modifyAccount_btn";
            this.modifyAccount_btn.Size = new System.Drawing.Size(53, 53);
            this.modifyAccount_btn.TabIndex = 49;
            this.modifyAccount_btn.UseVisualStyleBackColor = true;
            this.modifyAccount_btn.Click += new System.EventHandler(this.modifyAccount_btn_Click);
            // 
            // showPasswordConf_btn
            // 
            this.showPasswordConf_btn.BackColor = System.Drawing.SystemColors.Menu;
            this.showPasswordConf_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showPasswordConf_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showPasswordConf_btn.IconColor = System.Drawing.SystemColors.ControlText;
            this.showPasswordConf_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showPasswordConf_btn.IconSize = 22;
            this.showPasswordConf_btn.Location = new System.Drawing.Point(455, 346);
            this.showPasswordConf_btn.Name = "showPasswordConf_btn";
            this.showPasswordConf_btn.Size = new System.Drawing.Size(22, 22);
            this.showPasswordConf_btn.TabIndex = 48;
            this.showPasswordConf_btn.TabStop = false;
            this.showPasswordConf_btn.Click += new System.EventHandler(this.showPasswordConf_btn_Click);
            // 
            // showPassword_btn
            // 
            this.showPassword_btn.BackColor = System.Drawing.SystemColors.Menu;
            this.showPassword_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showPassword_btn.IconColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showPassword_btn.IconSize = 22;
            this.showPassword_btn.Location = new System.Drawing.Point(455, 303);
            this.showPassword_btn.Name = "showPassword_btn";
            this.showPassword_btn.Size = new System.Drawing.Size(22, 22);
            this.showPassword_btn.TabIndex = 47;
            this.showPassword_btn.TabStop = false;
            this.showPassword_btn.Click += new System.EventHandler(this.showPassword_btn_Click);
            // 
            // txtCPassword
            // 
            this.txtCPassword.BackColor = System.Drawing.SystemColors.Menu;
            this.txtCPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCPassword.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.txtCPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCPassword.Location = new System.Drawing.Point(256, 346);
            this.txtCPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtCPassword.MaxLength = 50;
            this.txtCPassword.Name = "txtCPassword";
            this.txtCPassword.Size = new System.Drawing.Size(221, 22);
            this.txtCPassword.TabIndex = 45;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.SystemColors.Menu;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.txtPassword.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtPassword.Location = new System.Drawing.Point(256, 303);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(221, 22);
            this.txtPassword.TabIndex = 44;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.SystemColors.Menu;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.txtUsername.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtUsername.Location = new System.Drawing.Point(256, 257);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(221, 22);
            this.txtUsername.TabIndex = 41;
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.Menu;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtEmail.Location = new System.Drawing.Point(255, 214);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(222, 22);
            this.txtEmail.TabIndex = 39;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Cooper Black", 14.25F);
            this.dateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.WindowFrame;
            this.dateTimePicker1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(255, 168);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(222, 29);
            this.dateTimePicker1.TabIndex = 37;
            // 
            // cboGender
            // 
            this.cboGender.BackColor = System.Drawing.SystemColors.Menu;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.cboGender.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(256, 123);
            this.cboGender.Margin = new System.Windows.Forms.Padding(2);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(149, 29);
            this.cboGender.TabIndex = 35;
            // 
            // txtLName
            // 
            this.txtLName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtLName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLName.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.txtLName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtLName.Location = new System.Drawing.Point(255, 82);
            this.txtLName.Margin = new System.Windows.Forms.Padding(2);
            this.txtLName.MaxLength = 30;
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(222, 22);
            this.txtLName.TabIndex = 34;
            // 
            // txtFName
            // 
            this.txtFName.BackColor = System.Drawing.SystemColors.Menu;
            this.txtFName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFName.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFName.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtFName.Location = new System.Drawing.Point(256, 36);
            this.txtFName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFName.MaxLength = 30;
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(222, 22);
            this.txtFName.TabIndex = 32;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(58, 348);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 21);
            this.label8.TabIndex = 46;
            this.label8.Text = "Confirm Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label7.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label7.Location = new System.Drawing.Point(97, 305);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 21);
            this.label7.TabIndex = 43;
            this.label7.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(96, 257);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 21);
            this.label6.TabIndex = 42;
            this.label6.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(116, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 21);
            this.label5.TabIndex = 40;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(100, 175);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 38;
            this.label4.Text = "Birthday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(112, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 36;
            this.label3.Text = "Gender";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(94, 82);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 33;
            this.label2.Text = "Last Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(94, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 21);
            this.label1.TabIndex = 31;
            this.label1.Text = "First Name";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(537, 484);
            this.Controls.Add(this.modifyAccount_btn);
            this.Controls.Add(this.showPasswordConf_btn);
            this.Controls.Add(this.showPassword_btn);
            this.Controls.Add(this.txtCPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditUserForm";
            this.Text = "EditUserForm";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPasswordConf_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button modifyAccount_btn;
        private FontAwesome.Sharp.IconPictureBox showPasswordConf_btn;
        private FontAwesome.Sharp.IconPictureBox showPassword_btn;
        private System.Windows.Forms.TextBox txtCPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}