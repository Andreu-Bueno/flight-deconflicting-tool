namespace FormsMenu
{
    partial class SimDisplay
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
            this.AutomaticMove_btn = new System.Windows.Forms.Button();
            this.Move_btn = new System.Windows.Forms.Button();
            this.position_lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.miPanel = new System.Windows.Forms.Panel();
            this.Timer_ATM_move = new System.Windows.Forms.Timer(this.components);
            this.Reset_btn = new System.Windows.Forms.Button();
            this.infoFlights_btn = new System.Windows.Forms.Button();
            this.SDistance_lbl = new System.Windows.Forms.Label();
            this.InfoFlights_lbl = new System.Windows.Forms.Label();
            this.conflictInfo_Btn = new System.Windows.Forms.Button();
            this.GoBackwards_btn = new System.Windows.Forms.Button();
            this.close_btn = new System.Windows.Forms.Button();
            this.saveToTxt_btn = new FontAwesome.Sharp.IconButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.icon_btn_SavePdf = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // AutomaticMove_btn
            // 
            this.AutomaticMove_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.AutomaticMove_btn.Location = new System.Drawing.Point(99, 41);
            this.AutomaticMove_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AutomaticMove_btn.Name = "AutomaticMove_btn";
            this.AutomaticMove_btn.Size = new System.Drawing.Size(96, 45);
            this.AutomaticMove_btn.TabIndex = 16;
            this.AutomaticMove_btn.Text = "Automatic move";
            this.AutomaticMove_btn.UseVisualStyleBackColor = true;
            this.AutomaticMove_btn.Click += new System.EventHandler(this.AutomaticMove_btn_Click_1);
            // 
            // Move_btn
            // 
            this.Move_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Move_btn.Location = new System.Drawing.Point(12, 41);
            this.Move_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Move_btn.Name = "Move_btn";
            this.Move_btn.Size = new System.Drawing.Size(81, 45);
            this.Move_btn.TabIndex = 15;
            this.Move_btn.Text = "Move";
            this.Move_btn.UseVisualStyleBackColor = true;
            this.Move_btn.Click += new System.EventHandler(this.Move_btn_Click_1);
            // 
            // position_lbl
            // 
            this.position_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.position_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.position_lbl.Location = new System.Drawing.Point(494, 31);
            this.position_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.position_lbl.Name = "position_lbl";
            this.position_lbl.Size = new System.Drawing.Size(363, 25);
            this.position_lbl.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1021, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "800";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 735);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "700";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(243, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "0";
            // 
            // miPanel
            // 
            this.miPanel.BackColor = System.Drawing.Color.Transparent;
            this.miPanel.BackgroundImage = global::FormsMenu.Properties.Resources.Sector;
            this.miPanel.Location = new System.Drawing.Point(269, 61);
            this.miPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.miPanel.Name = "miPanel";
            this.miPanel.Size = new System.Drawing.Size(800, 700);
            this.miPanel.TabIndex = 9;
            this.miPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.miPanel_MouseClick);
            this.miPanel.MouseLeave += new System.EventHandler(this.miPanel_MouseLeave);
            this.miPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.miPanel_MouseMove);
            // 
            // Timer_ATM_move
            // 
            this.Timer_ATM_move.Tick += new System.EventHandler(this.Timer_ATM_move_Tick);
            // 
            // Reset_btn
            // 
            this.Reset_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Reset_btn.Location = new System.Drawing.Point(12, 93);
            this.Reset_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Reset_btn.Name = "Reset_btn";
            this.Reset_btn.Size = new System.Drawing.Size(81, 45);
            this.Reset_btn.TabIndex = 17;
            this.Reset_btn.Text = "Reset simulation";
            this.Reset_btn.UseVisualStyleBackColor = true;
            this.Reset_btn.Click += new System.EventHandler(this.Reset_btn_Click);
            // 
            // infoFlights_btn
            // 
            this.infoFlights_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.infoFlights_btn.Location = new System.Drawing.Point(12, 199);
            this.infoFlights_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.infoFlights_btn.Name = "infoFlights_btn";
            this.infoFlights_btn.Size = new System.Drawing.Size(90, 51);
            this.infoFlights_btn.TabIndex = 18;
            this.infoFlights_btn.Text = "Flights Information";
            this.infoFlights_btn.UseVisualStyleBackColor = true;
            this.infoFlights_btn.Click += new System.EventHandler(this.infoFlights_btn_Click);
            // 
            // SDistance_lbl
            // 
            this.SDistance_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.SDistance_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SDistance_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SDistance_lbl.Location = new System.Drawing.Point(12, 9);
            this.SDistance_lbl.Name = "SDistance_lbl";
            this.SDistance_lbl.Size = new System.Drawing.Size(183, 23);
            this.SDistance_lbl.TabIndex = 20;
            this.SDistance_lbl.Text = "Simulation movement";
            this.SDistance_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoFlights_lbl
            // 
            this.InfoFlights_lbl.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.InfoFlights_lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoFlights_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoFlights_lbl.Location = new System.Drawing.Point(12, 163);
            this.InfoFlights_lbl.Name = "InfoFlights_lbl";
            this.InfoFlights_lbl.Size = new System.Drawing.Size(183, 23);
            this.InfoFlights_lbl.TabIndex = 21;
            this.InfoFlights_lbl.Text = "Simulation information";
            this.InfoFlights_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conflictInfo_Btn
            // 
            this.conflictInfo_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.conflictInfo_Btn.Location = new System.Drawing.Point(109, 199);
            this.conflictInfo_Btn.Name = "conflictInfo_Btn";
            this.conflictInfo_Btn.Size = new System.Drawing.Size(86, 51);
            this.conflictInfo_Btn.TabIndex = 23;
            this.conflictInfo_Btn.Text = "Conflict information";
            this.conflictInfo_Btn.UseVisualStyleBackColor = true;
            this.conflictInfo_Btn.Click += new System.EventHandler(this.conflictInfo_Btn_Click);
            // 
            // GoBackwards_btn
            // 
            this.GoBackwards_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GoBackwards_btn.Location = new System.Drawing.Point(99, 93);
            this.GoBackwards_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GoBackwards_btn.Name = "GoBackwards_btn";
            this.GoBackwards_btn.Size = new System.Drawing.Size(96, 45);
            this.GoBackwards_btn.TabIndex = 24;
            this.GoBackwards_btn.Text = "Go backwards";
            this.GoBackwards_btn.UseVisualStyleBackColor = true;
            this.GoBackwards_btn.Click += new System.EventHandler(this.GoBackwards_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.close_btn.Location = new System.Drawing.Point(61, 701);
            this.close_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(80, 54);
            this.close_btn.TabIndex = 25;
            this.close_btn.Text = "Close";
            this.close_btn.UseVisualStyleBackColor = true;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // saveToTxt_btn
            // 
            this.saveToTxt_btn.IconChar = FontAwesome.Sharp.IconChar.None;
            this.saveToTxt_btn.IconColor = System.Drawing.Color.Black;
            this.saveToTxt_btn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.saveToTxt_btn.Location = new System.Drawing.Point(61, 299);
            this.saveToTxt_btn.Name = "saveToTxt_btn";
            this.saveToTxt_btn.Size = new System.Drawing.Size(80, 80);
            this.saveToTxt_btn.TabIndex = 26;
            this.saveToTxt_btn.UseVisualStyleBackColor = true;
            this.saveToTxt_btn.Click += new System.EventHandler(this.saveToTxt_btn_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 273);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 23);
            this.label5.TabIndex = 27;
            this.label5.Text = "Save  to a .txt file";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 23);
            this.label6.TabIndex = 28;
            this.label6.Text = "Save  to a .pdf file";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // icon_btn_SavePdf
            // 
            this.icon_btn_SavePdf.IconChar = FontAwesome.Sharp.IconChar.None;
            this.icon_btn_SavePdf.IconColor = System.Drawing.Color.Black;
            this.icon_btn_SavePdf.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icon_btn_SavePdf.Location = new System.Drawing.Point(61, 428);
            this.icon_btn_SavePdf.Name = "icon_btn_SavePdf";
            this.icon_btn_SavePdf.Size = new System.Drawing.Size(80, 80);
            this.icon_btn_SavePdf.TabIndex = 29;
            this.icon_btn_SavePdf.UseVisualStyleBackColor = true;
            this.icon_btn_SavePdf.Click += new System.EventHandler(this.icon_btn_SavePdf_Click);
            // 
            // SimDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1081, 769);
            this.Controls.Add(this.icon_btn_SavePdf);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveToTxt_btn);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.GoBackwards_btn);
            this.Controls.Add(this.conflictInfo_Btn);
            this.Controls.Add(this.InfoFlights_lbl);
            this.Controls.Add(this.SDistance_lbl);
            this.Controls.Add(this.infoFlights_btn);
            this.Controls.Add(this.Reset_btn);
            this.Controls.Add(this.AutomaticMove_btn);
            this.Controls.Add(this.Move_btn);
            this.Controls.Add(this.position_lbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.miPanel);
            this.Name = "SimDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SimDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AutomaticMove_btn;
        private System.Windows.Forms.Button Move_btn;
        private System.Windows.Forms.Label position_lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel miPanel;
        private System.Windows.Forms.Timer Timer_ATM_move;
        private System.Windows.Forms.Button Reset_btn;
        private System.Windows.Forms.Button infoFlights_btn;
        private System.Windows.Forms.Label SDistance_lbl;
        private System.Windows.Forms.Label InfoFlights_lbl;
        private System.Windows.Forms.Button conflictInfo_Btn;
        private System.Windows.Forms.Button GoBackwards_btn;
        private System.Windows.Forms.Button close_btn;
        private FontAwesome.Sharp.IconButton saveToTxt_btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton icon_btn_SavePdf;
    }
}