namespace FormsMenu
{
    partial class ResetPasswordForm
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
            this.btnApply = new System.Windows.Forms.Button();
            this.txtRPassword = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.showCnfPassword_Btn = new FontAwesome.Sharp.IconPictureBox();
            this.showPassword_Btn = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCnfPassword_Btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_Btn)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(137, 143);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(79, 36);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // txtRPassword
            // 
            this.txtRPassword.Location = new System.Drawing.Point(144, 101);
            this.txtRPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtRPassword.Name = "txtRPassword";
            this.txtRPassword.Size = new System.Drawing.Size(97, 20);
            this.txtRPassword.TabIndex = 8;
            this.txtRPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(144, 38);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(97, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Confirm Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "New Password:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // showCnfPassword_Btn
            // 
            this.showCnfPassword_Btn.BackColor = System.Drawing.SystemColors.Control;
            this.showCnfPassword_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showCnfPassword_Btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showCnfPassword_Btn.IconColor = System.Drawing.SystemColors.ControlText;
            this.showCnfPassword_Btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showCnfPassword_Btn.IconSize = 18;
            this.showCnfPassword_Btn.Location = new System.Drawing.Point(246, 103);
            this.showCnfPassword_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.showCnfPassword_Btn.Name = "showCnfPassword_Btn";
            this.showCnfPassword_Btn.Size = new System.Drawing.Size(18, 18);
            this.showCnfPassword_Btn.TabIndex = 11;
            this.showCnfPassword_Btn.TabStop = false;
            this.showCnfPassword_Btn.Click += new System.EventHandler(this.showCnfPassword_Btn_Click);
            // 
            // showPassword_Btn
            // 
            this.showPassword_Btn.BackColor = System.Drawing.SystemColors.Control;
            this.showPassword_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_Btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.showPassword_Btn.IconColor = System.Drawing.SystemColors.ControlText;
            this.showPassword_Btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showPassword_Btn.IconSize = 18;
            this.showPassword_Btn.Location = new System.Drawing.Point(246, 38);
            this.showPassword_Btn.Margin = new System.Windows.Forms.Padding(2);
            this.showPassword_Btn.Name = "showPassword_Btn";
            this.showPassword_Btn.Size = new System.Drawing.Size(18, 18);
            this.showPassword_Btn.TabIndex = 10;
            this.showPassword_Btn.TabStop = false;
            this.showPassword_Btn.Click += new System.EventHandler(this.showPassword_Btn_Click);
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 217);
            this.Controls.Add(this.showCnfPassword_Btn);
            this.Controls.Add(this.showPassword_Btn);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtRPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ResetPasswordForm";
            this.Text = "ResetPasswordForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showCnfPassword_Btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.showPassword_Btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtRPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private FontAwesome.Sharp.IconPictureBox showCnfPassword_Btn;
        private FontAwesome.Sharp.IconPictureBox showPassword_Btn;
    }
}