namespace FormsMenu
{
    partial class Tutorial_FunctionalitiesForm
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
            this.text_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // text_lbl
            // 
            this.text_lbl.AutoSize = true;
            this.text_lbl.Font = new System.Drawing.Font("Cooper Black", 15F);
            this.text_lbl.Location = new System.Drawing.Point(2, 9);
            this.text_lbl.Name = "text_lbl";
            this.text_lbl.Size = new System.Drawing.Size(0, 23);
            this.text_lbl.TabIndex = 0;
            // 
            // Tutorial_FunctionalitiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.text_lbl);
            this.Name = "Tutorial_FunctionalitiesForm";
            this.Text = "Tutorial_FunctionalitiesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label text_lbl;
    }
}