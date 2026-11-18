using FlightLib;
using FlightLib.Text_File_Manager;
using FlightLib.Utils;
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
    public partial class AutomaticDeconflictingForm : Form
    {
        FlightPlanList flightsInConflictList = new FlightPlanList();
        FlightPlanList DeconflictedFlights = new FlightPlanList();
        DataTable table = new DataTable();
        double safetyDistance;
        private List<double> originalV;

        bool userDecision = false;
        private List<Tuple<int, int>> unresolvedConflicts = new List<Tuple<int, int>>();
        private int looptime;

        public AutomaticDeconflictingForm(FlightPlanList flightPlansList, double safetyDistance, int looptime)
        {
            InitializeComponent();

            this.looptime = looptime;

            // Set of the deconflicted flights
            for (int i = 0; i < flightPlansList.GetNumber(); i++)
            {
                this.DeconflictedFlights.AddFlightPlan(flightPlansList.GetFlightPlan(i));
            }

            // Set of the flights in conflict
            for (int i = 0; i < flightPlansList.GetNumber(); i++)
            {
                this.flightsInConflictList.AddFlightPlan(flightPlansList.GetFlightPlan(i));
            }

            // Set of the safety distance
            this.safetyDistance = safetyDistance;

            // Set of the original speeds
            originalV = new List<double>();
            for (int i = 0; i < flightPlansList.GetNumber(); i += 1)
            {
                this.originalV.Add(flightPlansList.GetFlightPlan(i).GetVelocidad());
            }

            // Cargar los datos
            LoadFlightData(flightPlansList);

            // Asignar el método Resize al evento del forms
            this.Resize += FlightInfoForm_Resize;
        }
        //Obtiene la decisión del usuario respecto a los cambios de velocidad.

        public bool GetUserDecision() { return userDecision; }
        public List<double> GetOriginalSpeeds() { return this.originalV; }
        public FlightPlanList GetDeconflictedFlights() { return this.DeconflictedFlights.CopyFlightPlanList(); }
        public List<Tuple<int, int>> GetUnresolvedConflicts() { return this.unresolvedConflicts; }
        
        //Carga los datos de una lista de planes de vuelo para realizar la simulación.
        private void LoadFlightData(FlightPlanList flightsList)
        {
            ConflictResolver res = new ConflictResolver(this.flightsInConflictList, this.DeconflictedFlights, safetyDistance);
            // Resolver todos los conflictos de forma iterativa
            res.ResolveAllConflicts();

            AlertMessage_lbl.Text = "There's been conflict detection" + "\n" + "Do you want to deconflict them?";
            if (unresolvedConflicts.Count > 0)
            {
                AlertMessage_lbl.Text += $"\n\nWarning: {unresolvedConflicts.Count} conflicts couldn't be fully resolved!";
                AlertMessage_lbl.Text += "\nConflicting flights are highlighted in pink.";
            }
            else
            {
                AlertMessage_lbl.Text += "\n\nAll conflicts were successfully resolved!";
            }

            // Crear un DataTable para organizar los datos
            table.Columns.Add("Select", typeof(bool)); // Nueva columna para checkboxes
            table.Columns.Add("Flights", typeof(string));
            table.Columns.Add("Origin", typeof(string));
            table.Columns.Add("Current position", typeof(string));
            table.Columns.Add("Final position", typeof(string));
            table.Columns.Add("Original Speed", typeof(string));
            table.Columns.Add("Resolution speed", typeof(string));

            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                string conflictStatus = "No conflict";
                if (unresolvedConflicts.Any(c => c.Item1 == i || c.Item2 == i))
                {
                    conflictStatus = "Unresolved conflict";
                }

                table.Rows.Add(true, 
                    flightsList.GetFlightPlan(i).GetId(),
                    $"({flightsList.GetFlightPlan(i).GetOrigin().GetX()}, {flightsList.GetFlightPlan(i).GetOrigin().GetY()})",
                    $"({flightsList.GetFlightPlan(i).GetCurrentPosition().GetX()}, {flightsList.GetFlightPlan(i).GetCurrentPosition().GetY()})",
                    $"({flightsList.GetFlightPlan(i).GetFinalPosition().GetX()}, {flightsList.GetFlightPlan(i).GetFinalPosition().GetY()})",
                    originalV[i].ToString(),
                    DeconflictedFlights.GetFlightPlan(i).GetVelocidad().ToString()
                    );
            }

            flightInfoGridView.DataSource = table;
            flightInfoGridView.Columns["Flights"].ReadOnly = true;
            flightInfoGridView.Columns["Origin"].ReadOnly = true;
            flightInfoGridView.Columns["Current position"].ReadOnly = true;
            flightInfoGridView.Columns["Final position"].ReadOnly = true;
            flightInfoGridView.Columns["Original Speed"].ReadOnly = true;
            flightInfoGridView.Columns["Resolution speed"].ReadOnly = true;


            flightInfoGridView.Columns["Select"].ReadOnly = false; // Solo la columna "Select" editable
            for (int i = 1; i < flightInfoGridView.Columns.Count; i++)
            {
                flightInfoGridView.Columns[i].ReadOnly = true;
            }
        }

        //Muestra en un datagridview los conflictos que hay.
        private void AutomaticDeconflictingForm_Load(object sender, EventArgs e)
        {
            flightInfoGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            flightInfoGridView.ClearSelection();
            flightInfoGridView.RowHeadersVisible = false;

            for (int i = 0; i < flightInfoGridView.Rows.Count; i += 2)
            {
                Color pairColor = (i / 2) % 2 == 0 ? Color.LightBlue : Color.LightGreen;
                flightInfoGridView.Rows[i].DefaultCellStyle.BackColor = pairColor;

                if (i + 1 < flightInfoGridView.Rows.Count)
                {
                    flightInfoGridView.Rows[i + 1].DefaultCellStyle.BackColor = pairColor;
                }
            }
        }

        //Ajusta la altura de las filas de dicha datagridview para que queden escaladas.
        private void AjustarAlturaFilas()
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




        //Aceptamos el cambio de velocidad para resolver el conflicto.
        private void Accept_btn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < flightInfoGridView.Rows.Count; i++)
            {
                bool aplicarResolucion = Convert.ToBoolean(flightInfoGridView.Rows[i].Cells["Select"].Value);

                if (!aplicarResolucion)
                {
                    // Restaurar velocidad original si el usuario no quiere aplicar la resolución
                    DeconflictedFlights.GetFlightPlan(i).SetVelocidad(originalV[i]);
                }
            }
            AfectedFlights form = new AfectedFlights(this.DeconflictedFlights, this.originalV);
            form.ShowDialog();

            userDecision = true;
            this.Close();
        }




        //Rechazamos las propuestas de cambios de velocidades aún sabiendo que habrá conflicto.
        private void Decline_btn_Click(object sender, EventArgs e)
        {
            // Restaurar velocidades originales
            for (int i = 0; i < DeconflictedFlights.GetNumber(); i++)
            {
                DeconflictedFlights.GetFlightPlan(i).SetVelocidad(originalV[i]);
            }
            this.Close();
        }
    }
}