namespace FormsMenu
{
    partial class AirlinesForm
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtAirline = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblLoadingData = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.airlinesGridView = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.airlinesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Cooper Black", 12F);
            this.txtEmail.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtEmail.Location = new System.Drawing.Point(541, 238);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(216, 26);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.Text = "Email";
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmail.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtEmail_MouseClick);
            // 
            // btnInsert
            // 
            this.btnInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsert.Location = new System.Drawing.Point(541, 306);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(103, 43);
            this.btnInsert.TabIndex = 15;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Font = new System.Drawing.Font("Cooper Black", 12F);
            this.txtTelephone.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtTelephone.Location = new System.Drawing.Point(541, 197);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(216, 26);
            this.txtTelephone.TabIndex = 14;
            this.txtTelephone.Text = "Telephone";
            this.txtTelephone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTelephone.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtTelephone_MouseClick);
            // 
            // txtAirline
            // 
            this.txtAirline.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAirline.Font = new System.Drawing.Font("Cooper Black", 12F);
            this.txtAirline.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtAirline.Location = new System.Drawing.Point(541, 151);
            this.txtAirline.Margin = new System.Windows.Forms.Padding(2);
            this.txtAirline.Name = "txtAirline";
            this.txtAirline.Size = new System.Drawing.Size(217, 26);
            this.txtAirline.TabIndex = 13;
            this.txtAirline.Text = "Airline";
            this.txtAirline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAirline.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtAirline_MouseClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(648, 306);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(109, 43);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblLoadingData
            // 
            this.lblLoadingData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLoadingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingData.Location = new System.Drawing.Point(33, 20);
            this.lblLoadingData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoadingData.Name = "lblLoadingData";
            this.lblLoadingData.Size = new System.Drawing.Size(472, 24);
            this.lblLoadingData.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // airlinesGridView
            // 
            this.airlinesGridView.AllowUserToAddRows = false;
            this.airlinesGridView.AllowUserToDeleteRows = false;
            this.airlinesGridView.AllowUserToResizeColumns = false;
            this.airlinesGridView.AllowUserToResizeRows = false;
            this.airlinesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.airlinesGridView.Location = new System.Drawing.Point(33, 59);
            this.airlinesGridView.Margin = new System.Windows.Forms.Padding(2);
            this.airlinesGridView.Name = "airlinesGridView";
            this.airlinesGridView.ReadOnly = true;
            this.airlinesGridView.RowHeadersWidth = 51;
            this.airlinesGridView.Size = new System.Drawing.Size(472, 433);
            this.airlinesGridView.TabIndex = 9;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AirlinesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 513);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.txtAirline);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblLoadingData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.airlinesGridView);
            this.Name = "AirlinesForm";
            this.Text = "AirlinesForm";
            ((System.ComponentModel.ISupportInitialize)(this.airlinesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtAirline;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblLoadingData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView airlinesGridView;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}