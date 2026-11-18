namespace FormsMenu
{
    partial class Distance
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
            this.DataGridView_distances = new System.Windows.Forms.DataGridView();
            this.distdefault = new System.Windows.Forms.Label();
            this.textBoxVariable = new System.Windows.Forms.TextBox();
            this.close_btn = new System.Windows.Forms.Button();
            this.AlertMessage_lbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_distances)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridView_distances
            // 
            this.DataGridView_distances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_distances.Location = new System.Drawing.Point(100, 83);
            this.DataGridView_distances.Name = "DataGridView_distances";
            this.DataGridView_distances.RowHeadersWidth = 82;
            this.DataGridView_distances.RowTemplate.Height = 33;
            this.DataGridView_distances.Size = new System.Drawing.Size(248, 171);
            this.DataGridView_distances.TabIndex = 0;
            // 
            // distdefault
            // 
            this.distdefault.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.distdefault.Font = new System.Drawing.Font("Cooper Black", 8.25F);
            this.distdefault.Location = new System.Drawing.Point(29, 17);
            this.distdefault.Name = "distdefault";
            this.distdefault.Size = new System.Drawing.Size(389, 13);
            this.distdefault.TabIndex = 2;
            this.distdefault.Text = "DISTANCE OF ALL THE OTHER FLIGHTS OF THE SECTOR, WITH:";
            // 
            // textBoxVariable
            // 
            this.textBoxVariable.Location = new System.Drawing.Point(189, 41);
            this.textBoxVariable.Name = "textBoxVariable";
            this.textBoxVariable.ReadOnly = true;
            this.textBoxVariable.Size = new System.Drawing.Size(76, 20);
            this.textBoxVariable.TabIndex = 3;
            // 
            // close_btn
            // 
            this.close_btn.Location = new System.Drawing.Point(165, 267);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(116, 33);
            this.close_btn.TabIndex = 5;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // AlertMessage_lbl
            // 
            this.AlertMessage_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.AlertMessage_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertMessage_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlertMessage_lbl.Location = new System.Drawing.Point(16, 9);
            this.AlertMessage_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.AlertMessage_lbl.Name = "AlertMessage_lbl";
            this.AlertMessage_lbl.Size = new System.Drawing.Size(418, 62);
            this.AlertMessage_lbl.TabIndex = 6;
            this.AlertMessage_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Distance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 312);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.textBoxVariable);
            this.Controls.Add(this.distdefault);
            this.Controls.Add(this.DataGridView_distances);
            this.Controls.Add(this.AlertMessage_lbl);
            this.Name = "Distance";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Distance_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_distances)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridView_distances;
        private System.Windows.Forms.Label distdefault;
        private System.Windows.Forms.TextBox textBoxVariable;
        private System.Windows.Forms.Button close_btn;
        private System.Windows.Forms.Label AlertMessage_lbl;
    }
}