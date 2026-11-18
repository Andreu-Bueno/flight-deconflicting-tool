using FlightLib;
using FlightLib.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace FormsMenu
{
    public partial class AfectedFlights : Form
    {
        FlightPlanList flightsList;

        List<FlightPlan> flightsWithDiffV;
        List<FlightPlan> flightsWithDiffVCopy;

        List<double> originalV;

        DataTable dt = new DataTable();

        FlightDBManager dbManager = new FlightDBManager();

        List<(string, string, string)> airlines = new List<(string, string, string)>();
        


        public AfectedFlights(FlightPlanList flights, List<double> OriginalV)
        {
            InitializeComponent();


            flightsList = flights.CopyFlightPlanList();

            this.originalV = OriginalV;

            dbManager.StartConnection();

            flightsWithDiffV = new List<FlightPlan>();

            var (dT, hasInfo) = dbManager.GetAirlinesInformation();
            if (hasInfo)
            {
                foreach (DataRow row in dT.Rows)
                {
                    airlines.Add((row["CompanyName"].ToString(), row["Telephone"].ToString(), row["Email"].ToString()));
                }
            }

            dataGridView1.DataSource = this.dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
        }

        private void AfectedFlights_Load(object sender, EventArgs e)
        {
            // Inicializamos las listas
            flightsWithDiffV = new List<FlightPlan>();
            flightsWithDiffVCopy = new List<FlightPlan>();

            HashSet<string> addedFlightIDs = new HashSet<string>(); // Para evitar duplicados por ID

            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                FlightPlan flight = flightsList.GetFlightPlan(i);
                double originalSpeed = originalV[i];

                // Si la velocidad ha cambiado y el vuelo aún no está en la lista
                if (flight.GetVelocidad() != originalSpeed)
                {
                    string flightID = flight.GetId();

                    if (!addedFlightIDs.Contains(flightID))
                    {
                        flightsWithDiffV.Add(flight);
                        flightsWithDiffVCopy.Add(flight);
                        addedFlightIDs.Add(flightID); // Marcar como añadido
                    }
                }
            }


            dt.Columns.Add("Airline", typeof(string));
            dt.Columns.Add("Telephone", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Id", typeof(string));
            dt.Columns.Add("Original speed", typeof(string));
            dt.Columns.Add("Resolution speed", typeof(string));

            foreach (FlightPlan flight in flightsWithDiffV)
            {
                string airlineName = flight.GetAirlineName();

                string telephone = "N/A";
                string email = "N/A";

                foreach (var name in airlines)
                {
                    if (airlineName.ToUpper() == name.Item1.ToUpper())
                    {
                        telephone = name.Item2;
                        email = name.Item3;
                        break;
                    }
                }
                dt.Rows.Add(
                    airlineName,
                    telephone,  // Telephone
                    email,  // Email
                    flight.GetId(),
                    originalV[flightsList.GetIndexById(flight.GetId())].ToString("0.##"), // Original
                    flight.GetVelocidad().ToString("0.##") // Resolución
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbManager.CloseConnection();
            this.Close();
        }
    }
}
