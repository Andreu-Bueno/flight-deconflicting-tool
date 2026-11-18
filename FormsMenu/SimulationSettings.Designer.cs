namespace FormsMenu
{
    partial class SimulationSettings
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
            this.SDistance_txtb = new System.Windows.Forms.TextBox();
            this.LoopTime_txtb = new System.Windows.Forms.TextBox();
            this.Accept_btn = new System.Windows.Forms.Button();
            this.SDistance_lbl = new System.Windows.Forms.Label();
            this.LoopTime_lbl = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.close_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // SDistance_txtb
            // 
            this.SDistance_txtb.Location = new System.Drawing.Point(34, 45);
            this.SDistance_txtb.Name = "SDistance_txtb";
            this.SDistance_txtb.Size = new System.Drawing.Size(284, 26);
            this.SDistance_txtb.TabIndex = 2;
            // 
            // LoopTime_txtb
            // 
            this.LoopTime_txtb.Location = new System.Drawing.Point(364, 45);
            this.LoopTime_txtb.Name = "LoopTime_txtb";
            this.LoopTime_txtb.Size = new System.Drawing.Size(284, 26);
            this.LoopTime_txtb.TabIndex = 3;
            // 
            // Accept_btn
            // 
            this.Accept_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept_btn.Location = new System.Drawing.Point(400, 89);
            this.Accept_btn.Name = "Accept_btn";
            this.Accept_btn.Size = new System.Drawing.Size(250, 68);
            this.Accept_btn.TabIndex = 4;
            this.Accept_btn.Text = "Accept";
            this.Accept_btn.UseVisualStyleBackColor = true;
            this.Accept_btn.Click += new System.EventHandler(this.Accept_btn_Click);
            // 
            // SDistance_lbl
            // 
            this.SDistance_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SDistance_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SDistance_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDistance_lbl.Location = new System.Drawing.Point(34, 9);
            this.SDistance_lbl.Name = "SDistance_lbl";
            this.SDistance_lbl.Size = new System.Drawing.Size(286, 33);
            this.SDistance_lbl.TabIndex = 14;
            this.SDistance_lbl.Text = "SAFETY DISTANCE";
            this.SDistance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoopTime_lbl
            // 
            this.LoopTime_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LoopTime_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoopTime_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoopTime_lbl.Location = new System.Drawing.Point(364, 9);
            this.LoopTime_lbl.Name = "LoopTime_lbl";
            this.LoopTime_lbl.Size = new System.Drawing.Size(286, 33);
            this.LoopTime_lbl.TabIndex = 15;
            this.LoopTime_lbl.Text = "LOOP TIME";
            this.LoopTime_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close_btn.Location = new System.Drawing.Point(34, 89);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(250, 68);
            this.close_btn.TabIndex = 17;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // SimulationSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 174);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.LoopTime_lbl);
            this.Controls.Add(this.SDistance_lbl);
            this.Controls.Add(this.Accept_btn);
            this.Controls.Add(this.LoopTime_txtb);
            this.Controls.Add(this.SDistance_txtb);
            this.Name = "SimulationSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulation_Security";
            this.Load += new System.EventHandler(this.SimulationSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox SDistance_txtb;
        private System.Windows.Forms.TextBox LoopTime_txtb;
        private System.Windows.Forms.Button Accept_btn;
        private System.Windows.Forms.Label SDistance_lbl;
        private System.Windows.Forms.Label LoopTime_lbl;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button close_btn;
    }
}