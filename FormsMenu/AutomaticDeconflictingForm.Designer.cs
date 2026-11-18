namespace FormsMenu
{
    partial class AutomaticDeconflictingForm
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
            this.flightInfoGridView = new System.Windows.Forms.DataGridView();
            this.Accept_btn = new System.Windows.Forms.Button();
            this.Decline_btn = new System.Windows.Forms.Button();
            this.AlertMessage_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flightInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flightInfoGridView
            // 
            this.flightInfoGridView.AllowUserToAddRows = false;
            this.flightInfoGridView.AllowUserToDeleteRows = false;
            this.flightInfoGridView.AllowUserToResizeColumns = false;
            this.flightInfoGridView.AllowUserToResizeRows = false;
            this.flightInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightInfoGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flightInfoGridView.Location = new System.Drawing.Point(11, 59);
            this.flightInfoGridView.Name = "flightInfoGridView";
            this.flightInfoGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.flightInfoGridView.RowTemplate.Height = 28;
            this.flightInfoGridView.Size = new System.Drawing.Size(515, 191);
            this.flightInfoGridView.TabIndex = 1;
            // 
            // Accept_btn
            // 
            this.Accept_btn.Location = new System.Drawing.Point(116, 269);
            this.Accept_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Accept_btn.Name = "Accept_btn";
            this.Accept_btn.Size = new System.Drawing.Size(149, 45);
            this.Accept_btn.TabIndex = 2;
            this.Accept_btn.Text = "Accept";
            this.Accept_btn.UseVisualStyleBackColor = true;
            this.Accept_btn.Click += new System.EventHandler(this.Accept_btn_Click);
            // 
            // Decline_btn
            // 
            this.Decline_btn.Location = new System.Drawing.Point(271, 269);
            this.Decline_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Decline_btn.Name = "Decline_btn";
            this.Decline_btn.Size = new System.Drawing.Size(149, 45);
            this.Decline_btn.TabIndex = 3;
            this.Decline_btn.Text = "Reject";
            this.Decline_btn.UseVisualStyleBackColor = true;
            this.Decline_btn.Click += new System.EventHandler(this.Decline_btn_Click);
            // 
            // AlertMessage_lbl
            // 
            this.AlertMessage_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AlertMessage_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertMessage_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlertMessage_lbl.Location = new System.Drawing.Point(74, 9);
            this.AlertMessage_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlertMessage_lbl.Name = "AlertMessage_lbl";
            this.AlertMessage_lbl.Size = new System.Drawing.Size(379, 45);
            this.AlertMessage_lbl.TabIndex = 4;
            this.AlertMessage_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutomaticDeconflictingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(538, 330);
            this.Controls.Add(this.AlertMessage_lbl);
            this.Controls.Add(this.Decline_btn);
            this.Controls.Add(this.Accept_btn);
            this.Controls.Add(this.flightInfoGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AutomaticDeconflictingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutomaticDeconflictingForm";
            this.Load += new System.EventHandler(this.AutomaticDeconflictingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightInfoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightInfoGridView;
        private System.Windows.Forms.Button Accept_btn;
        private System.Windows.Forms.Button Decline_btn;
        private System.Windows.Forms.Label AlertMessage_lbl;
    }
}