using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace FormsMenu
{
    public partial class SimulationSettings : Form
    {
        double safetyDistance;
        int loopTime;
        private static bool hasLoaded = false;

        public SimulationSettings()
        {
            InitializeComponent();
            this.AcceptButton = Accept_btn; // Establece Accept_btn como botón por defecto para Enter
        }

        private void Accept_btn_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            bool camposValidos = true;

            // Validación de safetyDistance
            try
            {
                safetyDistance = DataValidation.ValidateNum<double>(SDistance_txtb.Text, 30, 105, "safety distance");
            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(SDistance_txtb, ex.Message);
                SDistance_txtb.Text = "60";
                camposValidos = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errorProvider1.SetError(SDistance_txtb, ex.Message);
                SDistance_txtb.Text = "60";
                camposValidos = false;
            }
            catch (OverflowException ex)
            {
                errorProvider1.SetError(SDistance_txtb, ex.Message);
                SDistance_txtb.Text = "60";
                camposValidos = false;
            }

            // Validación de loopTime
            try
            {
                loopTime = DataValidation.ValidateNum<int>(LoopTime_txtb.Text, 10, 100, "step time");
            }
            catch (FormatException ex)
            {
                errorProvider1.SetError(LoopTime_txtb, ex.Message);
                LoopTime_txtb.Text = "10";
                camposValidos = false;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errorProvider1.SetError(LoopTime_txtb, ex.Message);
                LoopTime_txtb.Text = "10";
                camposValidos = false;
            }
            catch (OverflowException ex)
            {
                errorProvider1.SetError(LoopTime_txtb, ex.Message);
                LoopTime_txtb.Text = "10";
                camposValidos = false;
            }


            if (camposValidos)
            {
                Close(); // Solo cierra si todo es válido
            }
        }

        public double GetSafetyDistance()
        {
            return this.safetyDistance;
        }

        public int GetLoopTime()
        {
            return this.loopTime;
        }

        private void SimulationSettings_Load(object sender, EventArgs e)
        {
            if (!hasLoaded)
            {
                this.ActiveControl = Accept_btn; // Poner foco en otro control (ejemplo: un botón)
                LoopTime_txtb.Text = "10";
                hasLoaded = true;
            }
            this.ActiveControl = Accept_btn; // Poner foco en otro control (ejemplo: un botón)
            SDistance_txtb.Text = "60";
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
