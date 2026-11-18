namespace FormsMenu
{
    partial class FormsMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iconMenuItem = new FontAwesome.Sharp.IconMenuItem();
            this.addFlightplanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulationDisplayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.darToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPicture_btn = new FontAwesome.Sharp.IconButton();
            this.instructions_functionalities_btn = new FontAwesome.Sharp.IconButton();
            this.airlinesDb_btn = new FontAwesome.Sharp.IconButton();
            this.editUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(533, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem
            // 
            this.iconMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFlightplanToolStripMenuItem,
            this.simulationSettingsToolStripMenuItem,
            this.simulationDisplayToolStripMenuItem1,
            this.editUserToolStripMenuItem,
            this.darToolStripMenuItem,
            this.closeToolStripMenuItem1});
            this.iconMenuItem.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconMenuItem.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem.Name = "iconMenuItem";
            this.iconMenuItem.Size = new System.Drawing.Size(36, 28);
            // 
            // addFlightplanToolStripMenuItem
            // 
            this.addFlightplanToolStripMenuItem.Name = "addFlightplanToolStripMenuItem";
            this.addFlightplanToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addFlightplanToolStripMenuItem.Text = "Add flightplan";
            this.addFlightplanToolStripMenuItem.Click += new System.EventHandler(this.addFlightplanToolStripMenuItem_Click);
            // 
            // simulationSettingsToolStripMenuItem
            // 
            this.simulationSettingsToolStripMenuItem.Name = "simulationSettingsToolStripMenuItem";
            this.simulationSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.simulationSettingsToolStripMenuItem.Text = "Simulation settings";
            this.simulationSettingsToolStripMenuItem.Click += new System.EventHandler(this.simulationSettingsToolStripMenuItem_Click_1);
            // 
            // simulationDisplayToolStripMenuItem1
            // 
            this.simulationDisplayToolStripMenuItem1.Name = "simulationDisplayToolStripMenuItem1";
            this.simulationDisplayToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.simulationDisplayToolStripMenuItem1.Text = "Simulation Display";
            this.simulationDisplayToolStripMenuItem1.Click += new System.EventHandler(this.simulationDisplayToolStripMenuItem1_Click);
            // 
            // darToolStripMenuItem
            // 
            this.darToolStripMenuItem.Name = "darToolStripMenuItem";
            this.darToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.darToolStripMenuItem.Text = "Delete Account";
            this.darToolStripMenuItem.Click += new System.EventHandler(this.darToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem1
            // 
            this.closeToolStripMenuItem1.Name = "closeToolStripMenuItem1";
            this.closeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem1.Text = "Close";
            this.closeToolStripMenuItem1.Click += new System.EventHandler(this.closeToolStripMenuItem1_Click);
            // 
            // groupPicture_btn
            // 
            this.groupPicture_btn.Font = new System.Drawing.Font("Cooper Black", 10F);
            this.groupPicture_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.groupPicture_btn.IconColor = System.Drawing.Color.Black;
            this.groupPicture_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.groupPicture_btn.Location = new System.Drawing.Point(393, 171);
            this.groupPicture_btn.Name = "groupPicture_btn";
            this.groupPicture_btn.Size = new System.Drawing.Size(128, 109);
            this.groupPicture_btn.TabIndex = 2;
            this.groupPicture_btn.Text = "Group picture";
            this.groupPicture_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.groupPicture_btn.UseVisualStyleBackColor = true;
            this.groupPicture_btn.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // instructions_functionalities_btn
            // 
            this.instructions_functionalities_btn.Font = new System.Drawing.Font("Cooper Black", 8.25F);
            this.instructions_functionalities_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.instructions_functionalities_btn.IconColor = System.Drawing.Color.Black;
            this.instructions_functionalities_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.instructions_functionalities_btn.Location = new System.Drawing.Point(127, 171);
            this.instructions_functionalities_btn.Name = "instructions_functionalities_btn";
            this.instructions_functionalities_btn.Size = new System.Drawing.Size(128, 109);
            this.instructions_functionalities_btn.TabIndex = 5;
            this.instructions_functionalities_btn.Text = "Instrctions + Added functionalities ";
            this.instructions_functionalities_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.instructions_functionalities_btn.UseVisualStyleBackColor = true;
            this.instructions_functionalities_btn.Click += new System.EventHandler(this.instructions_functionalities_btn_Click);
            // 
            // airlinesDb_btn
            // 
            this.airlinesDb_btn.Font = new System.Drawing.Font("Cooper Black", 12F);
            this.airlinesDb_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.airlinesDb_btn.IconColor = System.Drawing.Color.Black;
            this.airlinesDb_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.airlinesDb_btn.Location = new System.Drawing.Point(261, 171);
            this.airlinesDb_btn.Name = "airlinesDb_btn";
            this.airlinesDb_btn.Size = new System.Drawing.Size(128, 109);
            this.airlinesDb_btn.TabIndex = 6;
            this.airlinesDb_btn.Text = "Airlines";
            this.airlinesDb_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.airlinesDb_btn.UseVisualStyleBackColor = true;
            this.airlinesDb_btn.Click += new System.EventHandler(this.airlinesDb_btn_Click_1);
            // 
            // editUserToolStripMenuItem
            // 
            this.editUserToolStripMenuItem.Name = "editUserToolStripMenuItem";
            this.editUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editUserToolStripMenuItem.Text = "Edit Account";
            this.editUserToolStripMenuItem.Click += new System.EventHandler(this.editUserToolStripMenuItem_Click);
            // 
            // FormsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.airlinesDb_btn);
            this.Controls.Add(this.instructions_functionalities_btn);
            this.Controls.Add(this.groupPicture_btn);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormsMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormsMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFlightplanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulationDisplayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem darToolStripMenuItem;
        private FontAwesome.Sharp.IconButton groupPicture_btn;
        private FontAwesome.Sharp.IconButton instructions_functionalities_btn;
        private FontAwesome.Sharp.IconButton airlinesDb_btn;
        private System.Windows.Forms.ToolStripMenuItem editUserToolStripMenuItem;
    }
}

