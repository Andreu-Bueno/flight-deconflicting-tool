using FlightLib;
using FlightLib.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsMenu
{
    public partial class InfoFlights : Form
    //constructor
    {
        FlightPlanList flightsList = new FlightPlanList();
        private string selectedFlightId = null;
        FlightDBManager dbManager = new FlightDBManager();

        public InfoFlights(FlightPlanList flightsList)
        {
            InitializeComponent();
            this.flightsList = flightsList;

            dbManager.StartConnection();

            // Llamar al método load
            LoadFlightData(flightsList);
        }

        public void SetFlightsList (FlightPlanList flightsList)
        //Setter of flights list
        {
            this.flightsList = flightsList;
        }

        private void LoadFlightData(FlightPlanList flightsList)
        //Loads all the Data from flights and creates a datatable to organize them
        {

            // Crear un DataTable para organizar los datos
            DataTable table = new DataTable();
            table.Columns.Add("Airlines", typeof(string));
            table.Columns.Add("Flights", typeof(string));
            table.Columns.Add("Data", typeof(string));
            table.Columns.Add("Data values", typeof(string));
            foreach (string airline in dbManager.GetAirlineNames())
            {
                var (dt, hasInfo) = dbManager.GetAirlineInformation(airline);
                if (hasInfo)
                {
                    string phone = dt.Rows[0]["Telephone"].ToString();
                    string email = dt.Rows[0]["Email"].ToString();
                    table.Rows.Add(airline, phone, email, "");
                }
                else { table.Rows.Add(airline, "", "", ""); }

                    for (int i = 0; i < flightsList.GetNumber(); i++)
                    {
                        if (flightsList.GetFlightPlan(i).GetAirlineName() == airline.ToUpper())
                        {
                            // Agregar fila con el ID del vuelo como título
                            table.Rows.Add("", flightsList.GetFlightPlan(i).GetId(), "", "");

                            // Agregar filas con los datos del vuelo
                            table.Rows.Add("", "", "Origin", $"(X: {flightsList.GetFlightPlan(i).GetOrigin().GetX()}, Y: {flightsList.GetFlightPlan(i).GetOrigin().GetY()})");
                            table.Rows.Add("", "", "Current position", $"(X: {Math.Round(flightsList.GetFlightPlan(i).GetCurrentPosition().GetX(), 2)}, Y: {Math.Round(flightsList.GetFlightPlan(i).GetCurrentPosition().GetY(), 2)})");
                            table.Rows.Add("", "", "Final position", $"(X: {flightsList.GetFlightPlan(i).GetFinalPosition().GetX()}, Y: {flightsList.GetFlightPlan(i).GetFinalPosition().GetY()})");
                            table.Rows.Add("", "", "Speed", flightsList.GetFlightPlan(i).GetVelocidad().ToString());
                        }
                    }
            }

            flightsInfoGridView.DataSource = table;
            ConfigurarEstilosDataGridView();
            dbManager.CloseConnection();
        }

        private void ConfigurarEstilosDataGridView()
        //Style for the data grid
        {
            flightsInfoGridView.AllowUserToAddRows = false;
            flightsInfoGridView.AllowUserToResizeRows = false;
            flightsInfoGridView.AllowUserToResizeColumns = false;
            flightsInfoGridView.RowHeadersVisible = false;

            foreach (DataGridViewColumn column in flightsInfoGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            this.flightsInfoGridView.CellFormatting += flightsInfoGridView_CellFormatting;
        }


        // En el evento load del form ajustamos parámetros del datraGridView
        private void InfoFlights_Load(object sender, EventArgs e)
        {
            flightsInfoGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flightsInfoGridView.ScrollBars = ScrollBars.Both;

            flightsInfoGridView.ClearSelection();
        }

        // Este evento se utiliza para seleccionar en el DataGridView
        // el vuelo con el que comparar con los demás las distancias
        private void flightsInfoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                var cellId = flightsInfoGridView.Rows[e.RowIndex].Cells[1].Value?.ToString();
                var cellData = flightsInfoGridView.Rows[e.RowIndex].Cells[2].Value?.ToString();

                if (!string.IsNullOrEmpty(cellId) && string.IsNullOrEmpty(cellData))
                {
                    // Es una fila de ID de vuelo válida
                    selectedFlightId = cellId;
                }
                else
                {
                    // Clic en fila de datos → limpiar selección
                    selectedFlightId = null;
                }
            }
            else
            {
                // Clic fuera de la columna de IDs → limpiar selección
                selectedFlightId = null;
            }
        }


        // Este evento sirve para dar color amarillo a las filas de aerolíneas y
        // amarillo claro a los vuelos con los datos
        private void flightsInfoGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in flightsInfoGridView.Rows)
            {
                if (row.Cells[0].Value != "")
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void Close_btn_Click(object sender, EventArgs e)
        //Closes the form
        {
            this.Close();
        }

        private void showDistance_btn_Click(object sender, EventArgs e)
        //Opens a New Form to show the distance of each other plane to the plane selected
        {
            if (!string.IsNullOrEmpty(selectedFlightId))
            {
                Distance form = new Distance(flightsList, selectedFlightId);
                form.Show();
            }
            else
            {
                MessageBox.Show("Please, select first a flight by clicking on its ID field.", "Selection required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }
    }
}
