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
using FlightLib.IO;
using FlightLib.Text_File_Manager;

namespace FormsMenu
{
    public partial class AñadirFlightplans : Form
    //Constructor
    {
        FlightDBManager dBManager = new FlightDBManager();
        FlightPlanList miLista = new FlightPlanList();
        private double safetyDistance;
        private int loopTime;
        int i = 0;
        int j = 0;


        public AñadirFlightplans()
        {
            InitializeComponent();
            dBManager.StartConnection();
        }

        public void SetFlightPlansList(FlightPlanList lista)
        // Sets the current list of flight plans.
        {
            this.miLista = lista;
        }

        public void SetOpened(int j)
        //Sets a flag that determines if the form should load with predefined values.
        {
            this.j = j;
        }

        private void button1_Click(object sender, EventArgs e)
        //Handles the main button click event: validates inputs, creates a FlightPlan, adds it to the list, and optionally pre-fills fields with defaults for demo/testing.
        {
            errorProvider1.Clear();
            bool camposValidados = true;

            try
            {
                if (string.IsNullOrWhiteSpace(id_txtbx.Text))
                { throw new ArgumentException("The ID field is missing."); }
                if (string.IsNullOrWhiteSpace(airline_txtb.Text))
                {throw new ArgumentException("The aircraft operator is missing");}
                if (!dBManager.IsAirlineInDb(airline_txtb.Text)) 
                { throw new ArgumentException("The airline inserted does not exist in the database.");}

                

                double cpx = DataValidation.ValidateNum<double>(cpx_txtbx.Text, 0, 1000, "coordinate X of entry to sector");
                double cpy = DataValidation.ValidateNum<double>(cpy_txtbx.Text, 0, 1000, "coordinate Y of entry to sector");
                double fpx = DataValidation.ValidateNum<double>(fpx_txtbx.Text, -100, 1000, "coordinate X of exit from sector");
                double fpy = DataValidation.ValidateNum<double>(fpy_txtbx.Text, -100, 1000, "coordenada Y salida del sector");
                double speed = DataValidation.ValidateNum<double>(speed_txtbx.Text, 15, 150, "Speed");

                FlightPlan fp = new FlightPlan(airline_txtb.Text.ToUpper() ,id_txtbx.Text,Convert.ToDouble(cpx_txtbx.Text),
                                    Convert.ToDouble(cpy_txtbx.Text), Convert.ToDouble(fpx_txtbx.Text),
                                    Convert.ToDouble(fpy_txtbx.Text), Convert.ToDouble(speed_txtbx.Text));
                if (j == 1)
                {
                    airline_txtb.Text = "EasyJet";
                    id_txtbx.Text = "EZY246";
                    cpx_txtbx.Text = "0";
                    cpy_txtbx.Text = "600";
                    fpx_txtbx.Text = "900";
                    fpy_txtbx.Text = "200";
                    speed_txtbx.Text = "60";
                }

                else
                {
                    airline_txtb.Text = "British Airways";
                    id_txtbx.Text = "BAW734";
                    cpx_txtbx.Text = "800";
                    cpy_txtbx.Text = "700";
                    fpx_txtbx.Text = "0";
                    fpy_txtbx.Text = "20";
                    speed_txtbx.Text = "50";
                }
                miLista.AddFlightPlan(fp);
                i++;

            }
            catch (FormatException ex)
            {
                MostrarError(ex.Message);
                camposValidados = false;
                return;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MostrarError(ex.Message);
                camposValidados = false;
                return;
            }
            catch (OverflowException ex)
            {
                MostrarError(ex.Message);
                camposValidados = false;
                return;
            }
            catch (ArgumentException ex)
            {
                MostrarError(ex.Message);
                camposValidados = false;
                return;
            }
            if (i == 2 && camposValidados)
            { 
                j = 1;
                Close();
            }
        }

        public (FlightPlanList, double, int) DameListaYDatos()
        //Returns the current flights list and some extra data as the safety distance and the looptime
        {
            return (this.miLista, this.safetyDistance, this.loopTime);
        }
        public int GetOpened()
        //Returns the current opened state flag
        {
            return this.j;
        }

        private void AñadirFlightplans_Load(object sender, EventArgs e)
        //Initializes the form fields when the form loads, optionally with predefined data.
        {
            if (j == 1)
            {
                airline_txtb.Text = "Lufthansa";
                id_txtbx.Text = "DHL356";
                cpx_txtbx.Text = "200";
                cpy_txtbx.Text = "0";
                fpx_txtbx.Text = "600";
                fpy_txtbx.Text = "900";
                speed_txtbx.Text = "50";
            }
            else
            { 
                this.ActiveControl = button1; // Poner foco en otro control (ejemplo: un botón)
                airline_txtb.Text = "Iberia";
                id_txtbx.Text = "IBE526";
                cpx_txtbx.Text = "0";
                cpy_txtbx.Text = "0";
                fpx_txtbx.Text = "600";
                fpy_txtbx.Text = "800";
                speed_txtbx.Text = "34";
            }
        }

        private void MostrarError(string mensaje)
        //Informs if an error occurs
        {
            if (mensaje.Contains("coordinate X of entry to sector"))
                errorProvider1.SetError(cpx_txtbx, mensaje);
            else if (mensaje.Contains("coordinate Y of entry to sector"))
                errorProvider1.SetError(cpy_txtbx, mensaje);
            else if (mensaje.Contains("coordinate X of exit from sector"))
                errorProvider1.SetError(fpx_txtbx, mensaje);
            else if (mensaje.Contains("coordinate Y of exit from sector"))
                errorProvider1.SetError(fpy_txtbx, mensaje);
            else if (mensaje.Contains("Speed"))
                errorProvider1.SetError(speed_txtbx, mensaje);
            else if (mensaje.Contains("ID"))
                errorProvider1.SetError(id_txtbx, mensaje);
            else if (mensaje.Contains("airline"))
                errorProvider1.SetError(airline_txtb, mensaje);
            else if (mensaje.Contains("aircraft"))
                errorProvider1.SetError(airline_txtb, mensaje);
        }

        private void Close_btn_Click(object sender, EventArgs e)
        //Close the 'AñadirFlightplans' Form
        {
            dBManager.CloseConnection();
            this.Close();
        }

        private void btnCargartxt_Click(object sender, EventArgs e)
        {
            miLista.ClearList();
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            openFileDialog.Title = "Seleccionar archivo de vuelos";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                TextFileManager txtManager = new TextFileManager();
                
                var (flights, errors, safetyDistance, loopTime) = txtManager.ReadFile(filePath);

                // Procesar los vuelos cargados (ej: mostrar en DataGridView)
                flights.EscribeConsola();

                foreach (var error in errors)
                {
                    Console.WriteLine(error);
                }
                for (int i = 0; i < flights.GetNumber(); i++)
                {
                    FlightPlan flight = flights.GetFlightPlan(i);
                    miLista.AddFlightPlan(flight);
                }
                this.safetyDistance = safetyDistance;
                this.loopTime = loopTime;
            }

            this.Close();
        }
    }
}
