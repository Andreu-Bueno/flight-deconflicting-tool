namespace FormsMenu
{
    partial class FlightInfoForm
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
            this.close_btn = new System.Windows.Forms.Button();
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
            this.flightInfoGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.flightInfoGridView.Location = new System.Drawing.Point(0, 0);
            this.flightInfoGridView.Name = "flightInfoGridView";
            this.flightInfoGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.flightInfoGridView.RowTemplate.Height = 28;
            this.flightInfoGridView.Size = new System.Drawing.Size(533, 240);
            this.flightInfoGridView.TabIndex = 0;
            //
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(196, 248);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(131, 41);
            this.close_btn.TabIndex = 2;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // FlightInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 301);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.flightInfoGridView);
            this.Name = "FlightInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FlightInfoForm";
            this.Load += new System.EventHandler(this.FlightInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightInfoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightInfoGridView;
        private System.Windows.Forms.Button close_btn;
    }
}