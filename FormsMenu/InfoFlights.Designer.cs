namespace FormsMenu
{
    partial class InfoFlights
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
            this.flightsInfoGridView = new System.Windows.Forms.DataGridView();
            this.Close_btn = new System.Windows.Forms.Button();
            this.showDistance_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.flightsInfoGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // flightsInfoGridView
            // 
            this.flightsInfoGridView.AllowUserToAddRows = false;
            this.flightsInfoGridView.AllowUserToDeleteRows = false;
            this.flightsInfoGridView.AllowUserToResizeColumns = false;
            this.flightsInfoGridView.AllowUserToResizeRows = false;
            this.flightsInfoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.flightsInfoGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flightsInfoGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.flightsInfoGridView.Location = new System.Drawing.Point(0, 0);
            this.flightsInfoGridView.Name = "flightsInfoGridView";
            this.flightsInfoGridView.ReadOnly = true;
            this.flightsInfoGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.flightsInfoGridView.RowTemplate.Height = 28;
            this.flightsInfoGridView.Size = new System.Drawing.Size(543, 270);
            this.flightsInfoGridView.TabIndex = 1;
            this.flightsInfoGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.flightsInfoGridView_CellClick);
            this.flightsInfoGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.flightsInfoGridView_CellFormatting);
            // 
            // Close_btn
            // 
            this.Close_btn.Location = new System.Drawing.Point(12, 300);
            this.Close_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Close_btn.Name = "Close_btn";
            this.Close_btn.Size = new System.Drawing.Size(187, 42);
            this.Close_btn.TabIndex = 4;
            this.Close_btn.Text = "Close";
            this.Close_btn.UseVisualStyleBackColor = true;
            this.Close_btn.Click += new System.EventHandler(this.Close_btn_Click);
            // 
            // showDistance_btn
            // 
            this.showDistance_btn.Location = new System.Drawing.Point(344, 300);
            this.showDistance_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.showDistance_btn.Name = "showDistance_btn";
            this.showDistance_btn.Size = new System.Drawing.Size(187, 42);
            this.showDistance_btn.TabIndex = 5;
            this.showDistance_btn.Text = "View proximity to other flights";
            this.showDistance_btn.UseVisualStyleBackColor = true;
            this.showDistance_btn.Click += new System.EventHandler(this.showDistance_btn_Click);
            // 
            // InfoFlights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 354);
            this.Controls.Add(this.showDistance_btn);
            this.Controls.Add(this.Close_btn);
            this.Controls.Add(this.flightsInfoGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "InfoFlights";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InfoFlights";
            this.Load += new System.EventHandler(this.InfoFlights_Load);
            ((System.ComponentModel.ISupportInitialize)(this.flightsInfoGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView flightsInfoGridView;
        private System.Windows.Forms.Button Close_btn;
        private System.Windows.Forms.Button showDistance_btn;
    }
}