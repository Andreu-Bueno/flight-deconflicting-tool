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
    public partial class FlightInfoForm : Form
    //constructor
    {
        FlightPlan currentFlight; // Guardamos la referencia
        private FlightPlanList flightPlanList;
        bool thereIsAChange = false;
        List<FlightPlan> initialData = new List<FlightPlan>();

        public FlightInfoForm(FlightPlan flight, FlightPlanList flightsList)
        //Loads all the data from each airplane and organizes it on a Data Table
        {
            InitializeComponent();
            currentFlight = flight;
            flightPlanList = flightsList;
            initialData.Add(flight);
            LoadFlightData(flight);

            this.Resize += FlightInfoForm_Resize;
            this.flightInfoGridView.CellEndEdit += FlightInfoGridView_CellEndEdit;
            this.flightInfoGridView.CellBeginEdit += FlightInfoGridView_CellBeginEdit;
            //prevents the user from being able to edit other cells than Speed
            flightInfoGridView.CellFormatting += FlightInfoGridView_CellFormatting;
            //Changes colors to the cells for a better understanding for the user
        }

        private void LoadFlightData(FlightPlan flight)
        {
            // Crear un DataTable para organizar los datos
            DataTable table = new DataTable();
            table.Columns.Add("Data");
            table.Columns.Add("Data values");

            // Agregar la información
            table.Rows.Add("Airline", flight.GetAirlineName());
            table.Rows.Add("ID", flight.GetId());
            table.Rows.Add("Origin", $"(X: {Math.Round(flight.GetOrigin().GetX(), 2)}, Y: {Math.Round(flight.GetOrigin().GetY(), 2)})");
            table.Rows.Add("Current position", $"(X: {Math.Round(flight.GetCurrentPosition().GetX(), 2)}, Y: {Math.Round(flight.GetCurrentPosition().GetY(), 2)})");
            table.Rows.Add("Final position", $"(X: {Math.Round(flight.GetFinalPosition().GetX(), 2)}, Y: {Math.Round(flight.GetFinalPosition().GetY(), 2)})");
            table.Rows.Add("Speed", flight.GetVelocidad());

            flightInfoGridView.DataSource = table;
            flightInfoGridView.RowHeadersVisible = false;
        }

        private void FlightInfoGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Permitir solo la edición de la fila "Speed" (índice 5), columna "Data values" (índice 1)
            if (!(e.RowIndex == 5 && e.ColumnIndex == 1))
            {
                e.Cancel = true;
            }
        }
        private void FlightInfoGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Si es la celda de la fila "Speed" (fila 5, columna 1)
            if (e.RowIndex == 5 && e.ColumnIndex == 1)
            {
                e.CellStyle.BackColor = Color.LightYellow;
                e.CellStyle.ForeColor = Color.Black; // (opcional, para asegurar contraste)
            }
        }

        private void FlightInfoForm_Load(object sender, EventArgs e)
        //initializes  the flight information grid
        {
            // Suponiendo que la primera fila contiene el ID del vuelo
            string flightID = flightInfoGridView.Rows[1].Cells[1].Value.ToString();

            // Cambiar el título del formulario
            this.Text = $"Flight Info - {flightID}";

            flightInfoGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flightInfoGridView.ScrollBars = ScrollBars.Both;

            flightInfoGridView.ClearSelection();
            AjustarAlturaFilas();
        }

        private void FlightInfoGridView_CellEndEdit(object sener,  DataGridViewCellEventArgs e)
        //Allows the user to change values from each flight in the grid
        {

            string field = flightInfoGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            string newValue = flightInfoGridView.Rows[e.RowIndex].Cells[1].Value.ToString();


            switch (field)
            {
                case "Origin":
                case "Current position":
                case "Final position":

                    var newPosition = ParsePosition(newValue);

                    if (newPosition.GetX() != initialData[0].GetOrigin().GetX() || newPosition.GetY() != initialData[0].GetOrigin().GetY())
                        { thereIsAChange = true; }

                    else if (newPosition.GetX() != initialData[0].GetCurrentPosition().GetX() || newPosition.GetY() != initialData[0].GetCurrentPosition().GetY())
                        { thereIsAChange = true; }

                    else if (newPosition.GetX() != initialData[0].GetFinalPosition().GetX() || newPosition.GetY() != initialData[0].GetFinalPosition().GetY())
                        { thereIsAChange = true; }


                    if (newPosition != null)
                    {
                        if (field == "Origin") currentFlight.SetOrigin(newPosition);
                        else if (field == "Current position") currentFlight.SetCurrentPosition(newPosition);
                        else if (field == "Final position") currentFlight.SetFinalPosition(newPosition);
                    }
                    break;

                case "Speed":

                    Console.WriteLine($"Nuevo valor de velocidad ingresado: {newValue}");

                    if (double.TryParse(newValue, out double speed))
                    {
                        if (speed != initialData[0].GetVelocidad())
                        { thereIsAChange = true; }

                        Console.WriteLine($"Velocidad parseada correctamente: {speed}");
                        try
                        {
                            DataValidation.ValidateNum<double>(Convert.ToString(speed), 15, 150, "Speed");
                            currentFlight.SetVelocidad(speed);
                        }
                        catch (FormatException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        catch (OverflowException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        catch (ArgumentException ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        Console.WriteLine($"Velocidad en currentFlight después de set: {currentFlight.GetVelocidad()}");
                    }
                    break;
            }
        }

        private Position ParsePosition(string value)
        //Converts the position (string) to a position (object)
        {
            value = value.Replace("(", "").Replace(")", "");
            string[] parts = value.Split(',');
            if (parts.Length == 2 && double.TryParse(parts[0], out double x) && double.TryParse(parts[1], out double y))
            {
                return new Position(x, y);
            }
            return null;
        }

        private void AjustarAlturaFilas()
        //adjusts the rows height
        {
            if (flightInfoGridView.RowCount > 0)
            {
                int totalAltura = flightInfoGridView.Height - flightInfoGridView.ColumnHeadersHeight;
                int alturaFila = totalAltura / flightInfoGridView.RowCount;

                foreach (DataGridViewRow row in flightInfoGridView.Rows)
                {
                    row.Height = alturaFila;
                }
            }
        }

        private void FlightInfoForm_Resize(object sender, EventArgs e)
        {
            AjustarAlturaFilas();
        }

        public (FlightPlan, bool) GetChanges()
        //indicates whether any changes have been made to the flight plan
        {
            Console.WriteLine($"GetChanges() llamado. Velocidad actual en currentFlight: {currentFlight.GetVelocidad()}");

            return (currentFlight, this.thereIsAChange);
        }

        private void close_btn_Click(object sender, EventArgs e)
        //Close the form
        {
            this.Close();
        }
    }
}
