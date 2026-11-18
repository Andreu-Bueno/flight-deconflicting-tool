using FlightLib;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormsMenu
{
    //Esta clase calcula la distancia entre un vuelo selecionado y otros.
    public partial class Distance : Form
    {
        FlightPlanList flightPlansList = new FlightPlanList();
        string id;
        public Distance(FlightPlanList flighsList, string id)
        {
            InitializeComponent();
            flightPlansList = flighsList;
            this.id = id;
        }

        private void Distance_Load_1(object sender, EventArgs e)
        //Show the distance between the selected aircraft and each other aircraft
        {
            //int vectordistance = Math.Sqrt((flightplan.GetCurrentPosition**2)
            textBoxVariable.Text = id;
            DataTable table = new DataTable();

            table.Columns.Add("Flights");
            table.Columns.Add("Distance");


            for (int i = 0; i < flightPlansList.GetNumber(); i++)
            {
                if (flightPlansList.GetFlightPlan(i).GetId() != id)
                    table.Rows.Add(flightPlansList.GetFlightPlan(i).GetId(), Math.Round(flightPlansList.GetFlightPlanWthId(id).
                        Distance(flightPlansList.GetFlightPlan(i)), 2));
            }

            DataGridView_distances.DataSource = table;
            DataGridView_distances.RowHeadersVisible = false;
            DataGridView_distances.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridView_distances.ScrollBars = ScrollBars.Both;

        }

        private void close_btn_Click(object sender, EventArgs e)
        //Close the Form
        {
            this.Close();
        }
    }
}
