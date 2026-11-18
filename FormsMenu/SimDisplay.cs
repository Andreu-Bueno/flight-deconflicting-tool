using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using FlightLib.Models;
using FlightLib.Text_File_Manager;
using FontAwesome.Sharp;

namespace FormsMenu
{
    public partial class SimDisplay : Form
    {
        // Variables y listaas 
            // Listas de vuelos
        FlightPlanList flightsList = new FlightPlanList();
        FlightPlanList flightsInConflict = new FlightPlanList(); // la lista se ordena de forma que el vuelo en i tiene conflicto con el de i + 1. Por parejas.
        FlightsHistoricList historicList = new FlightsHistoricList();
        private FlightPlanList originalFlightsList;

        // Litas de posiciones
        Position[] flightsPosition = new Position[100];
        PictureBox[] picsList = new PictureBox[100];
        int numPics = 0;
        int numPositionsList = 0;

        // Vuelo en desviación
        private FlightPlan selectedFlightForDiversion = null;
        private string selectedFlightForDiversionId = null;
        private Position diversionPositionCopy = null;

        // Vuelo info
        private FlightPlan selectedFlightInfo = null;

        // Variables para el manejo general de la simulación y diseño
        private int loopTime;
        private double safetyDistance;
        private List<System.Windows.Forms.Label> labelsList = new List<System.Windows.Forms.Label>();
        private int hasBeenOpenedOnce;

        // Variables para el manejo de conflictos
        bool conflictAlerted = false; // Variable global
        bool conflictNow;


        List<double> originalSpeeds = new List<double>();



        public SimDisplay(int loopTime, double safetyDistance)
        {
            InitializeComponent();
            this.loopTime = loopTime;
            this.safetyDistance = safetyDistance;
            this.ActiveControl = AutomaticMove_btn;

            saveToTxt_btn.IconChar = IconChar.FileExport;
            saveToTxt_btn.IconFont = IconFont.Solid;

            icon_btn_SavePdf.IconChar = IconChar.FileExport;
            icon_btn_SavePdf.IconFont = IconFont.Solid;

            miPanel.BackgroundImageLayout = ImageLayout.Stretch;

            // Habilita Double Buffering mediante Reflection (para evitar parpadeo)
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, miPanel, new object[] { true });
        }

        public void SetFlightsList(FlightPlanList list)
        {
            this.flightsList = list;
            this.originalFlightsList = list.CopyFlightPlanList();
        }

        public void UpdateFlightsList(FlightPlanList list)
        {
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                this.flightsList.UpdateFlight(list.GetFlightPlan(i));
            }
        }


        private void AutomaticMove_btn_Click(object sender, EventArgs e)
        {

        }

        private void Move_btn_Click(object sender, EventArgs e)
        {

        }

        private void miPanel_MouseMove(object sender, MouseEventArgs e)
        {

            position_lbl.BackColor = Color.White;
            position_lbl.TextAlign = ContentAlignment.MiddleCenter;
            position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
            position_lbl.Text = "X = " + e.X + " | Y = " + e.Y;
        }

        private void miPanel_MouseLeave(object sender, EventArgs e)
        {
            position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
            position_lbl.Text = "Position out of limits";
        }

        private void Move_btn_Click_1(object sender, EventArgs e)
        {
            // Resetear colores primero
            ResetLabelColors();


            flightsList.Move(loopTime);
            historicList.AddFlightsList(flightsList);

            List<int> conflictingFlights = DetectConflicts();


            for (int i = 0; i < numPositionsList; i++)
            {
                UpdateFlightVisual(i);
            }
            miPanel.Invalidate();
            
        }
        private void ResetLabelColors()
        {
            for (int i = 0; i < numPics; i++)
            {
                if (labelsList[i] != null)
                {
                    labelsList[i].BackColor = Color.FromArgb(128, 220, 220, 220); // Gris claro translúcido
                    labelsList[i].ForeColor = Color.Black;
                }
            }
        }

        //Muestra el formulario con las posiciones iniciales de la simulación.
        private void SimDisplay_Load(object sender, EventArgs e)
        {
            bool anyConflictDetected = false;

            FlightPlanList OriginFlightsCopy = flightsList.CopyFlightPlanList();
            historicList.AddFlightsList(OriginFlightsCopy);
            
          
            if (flightsList.GetNumber() == 0)
            {
                MessageNoflightsToSimulate();
            }
            else
            {
                for (int n = 0; n < flightsList.GetNumber(); n++)
                {
                    for (int j = n + 1; j < flightsList.GetNumber(); j++)
                    {
                        Console.WriteLine($"Verificando conflicto entre {flightsList.GetFlightPlan(n).GetId()} y {flightsList.GetFlightPlan(j).GetId()}");

                        if (PredecirConflicto("", n, j))
                        {
                            Console.WriteLine($"❗ Conflicto detectado entre {flightsList.GetFlightPlan(n).GetId()} y {flightsList.GetFlightPlan(j).GetId()}");
                            flightsInConflict.AddFlightPlan(flightsList.GetFlightPlan(n));
                            flightsInConflict.AddFlightPlan(flightsList.GetFlightPlan(j));
                        }
                    }
                }

                Console.WriteLine($"Número de vuelos en conflicto: {flightsInConflict.GetNumber()}");
               
                if (flightsInConflict.GetNumber() > 0)
                {
                    AutomaticDeconflictingForm atmDeconflictingForm = new AutomaticDeconflictingForm(this.flightsInConflict, this.safetyDistance, this.loopTime);
                    atmDeconflictingForm.ShowDialog();
                    if (atmDeconflictingForm.GetUserDecision())
                    {
                        UpdateFlightsList(atmDeconflictingForm.GetDeconflictedFlights());
                        originalSpeeds = atmDeconflictingForm.GetOriginalSpeeds();
                        originalFlightsList = flightsList.CopyFlightPlanList();
                        UpdateLabels();
                        miPanel.Invalidate();
                    }
                }
                if (flightsList.GetNumber() > 0)
                {
                    Console.Write("Flight velocity changed: {0} \n", flightsList.GetFlightPlan(0).GetVelocidad());
                }
                else
                {
                    Console.WriteLine("No flights available in the list.");
                }

                miPanel.Paint += MiPanel_Paint;

                for (int i = 0; i < flightsList.GetNumber(); i++)
                {
                    if (numPositionsList >= flightsList.GetNumber())
                    {
                        break;
                    }
                    flightsPosition[i] = flightsList.GetFlightPlan(i).GetCurrentPosition();
                    numPositionsList++;
                }


                for (int i = 0; i < numPositionsList; i++)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = DrawCircle(25, 25, Color.Red),
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.Zoom,
                    };
                    MakePictureBoxCircular(pictureBox);
                    //Dibujo la elipse de seguridad alrededor de cada avión.
                    float centerX = (float)flightsPosition[i].GetX() - pictureBox.Width / 2;
                    float centerY = (float)flightsPosition[i].GetY() - pictureBox.Height / 2;

                    pictureBox.Left = (int)Math.Round(centerX);
                    pictureBox.Top = (int)Math.Round(centerY);

                    pictureBox.Tag = flightsList.GetFlightPlan(i);
                    pictureBox.MouseClick += PictureBox_Click;

                    miPanel.Controls.Add(pictureBox);
                    picsList[numPics] = pictureBox;


                    System.Windows.Forms.Label label = new System.Windows.Forms.Label
                    {
                        Text = $"ID: {flightsList.GetFlightPlan(i).GetId()} | Speed: {flightsList.GetFlightPlan(i).GetVelocidad()}",
                        ForeColor = Color.Black,
                        BackColor = Color.FromArgb(128, 220, 220, 220),
                        AutoSize = true,
                        Padding = new Padding(3)
                    };

                    label.Left = pictureBox.Left + 10;
                    label.Top = pictureBox.Top - 20;
                    label.BorderStyle = BorderStyle.FixedSingle;  // Un borde sutil
                    label.Font = new Font(label.Font, FontStyle.Bold);  // Texto en negrita

                    miPanel.Controls.Add(label);
                    labelsList.Add(label);

                    numPics++;
                }
            }
        }

        //Escribe un mensaje en medio del sector que indica que no
        //hay vuelos para simular ya que no se ha cargado ninguno al sistema.
        private void MessageNoflightsToSimulate()
        {
            miPanel.Paint += (s, pe) =>
            {
                string message = "There are no flights to simulate";

                Font font = new Font("Arial", 30, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Red);
                float angle = -45f;

                // Calcular la posición para centrar el texto en el panel
                SizeF textSize = pe.Graphics.MeasureString(message, font);
                float x = (miPanel.Width - textSize.Width) / 2;
                float y = (miPanel.Height - textSize.Height) / 2;

                // Rotar y dibujar el texto en el panel
                pe.Graphics.TranslateTransform(x + textSize.Width / 2, y + textSize.Height / 2); // Mover el origen al centro del texto
                pe.Graphics.RotateTransform(angle); // Aplicar rotación
                pe.Graphics.DrawString(message, font, brush, new PointF(-textSize.Width / 2, -textSize.Height / 2)); // Dibujar texto centrado
            };
        }

        //Función para cambiar el rumbo de un avión y así evitar el conflicto con el resto.
        private void PictureBox_Click(object sender, MouseEventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            if (pictureBox != null && pictureBox.Tag is FlightPlan flight)
            {
                if (e.Button == MouseButtons.Right)
                {
                    selectedFlightForDiversion = flight;
                    selectedFlightForDiversionId = flight.CopyFlightplan().GetId();
                    Console.WriteLine($"Fight selected for diversion: {flight.GetId()}");


                    for (int i = 0; i < numPics; i++)
                    {
                        FlightPlan f = picsList[i].Tag as FlightPlan;
                        if (f == null)
                            continue;

                        Color color;
                        if (f == selectedFlightForDiversion)
                            color = Color.SkyBlue;
                        else if (f == selectedFlightInfo)
                            color = Color.Purple;
                        else
                            color = Color.Red;
                        picsList[i].Image = DrawCircle(25, 25, color);
                    }
                }
                else if (e.Button == MouseButtons.Left)
                {
                    FlightInfoForm infoForm = new FlightInfoForm(flight, flightsList);
                    selectedFlightInfo = flight;


                    for (int i = 0; i < numPics; i++)
                    {
                        FlightPlan f = picsList[i].Tag as FlightPlan;
                        if (f == null)
                            continue;

                        Color color;
                        if (f == selectedFlightForDiversion)
                            color = Color.SkyBlue;
                        else if (f == selectedFlightInfo)
                            color = Color.Purple;
                        else
                            color = Color.Red;
                        picsList[i].Image = DrawCircle(25, 25, color);
                    }

                    infoForm.FormClosed += (s, args) =>
                    {
                        var (updatedFlight, hasChanges) = infoForm.GetChanges();
                        Console.WriteLine("Changes?" + hasChanges);
                        Console.WriteLine($"Velocidad obtenida desde formulario después de GetChanges(): {updatedFlight.GetVelocidad()}");
                        if (updatedFlight != null)
                        {
                            Console.WriteLine($"Actualizando vuelo ID: {updatedFlight.GetId()}");
                            Console.WriteLine($"Velocidad (desde formulario): {updatedFlight.GetVelocidad()}");

                            flightsList.UpdateFlight(updatedFlight);

                            FlightPlan updated = flightsList.GetFlightPlanWthId(updatedFlight.GetId());
                            Console.WriteLine($"Velocidad después: {updated?.GetVelocidad()}");

                            UpdateLabels();

                            if (hasChanges)
                            {

                                flightsList = originalFlightsList.CopyFlightPlanList();
                                updatedFlight.Restart();
                                flightsList.UpdateFlight(updatedFlight);


                                // Limpiar el historial y añadir la posición inicial
                                historicList = new FlightsHistoricList();
                                historicList.AddFlightsList(flightsList.CopyFlightPlanList());

                                // Actualizar las posiciones visuales
                                for (int i = 0; i < flightsList.GetNumber(); i++)
                                {
                                    UpdateFlightVisual(i);
                                }

                                miPanel.Invalidate();
                            }
                        }
                        else { Console.WriteLine("No se detectaron cambios en el vuelo."); }

                        selectedFlightInfo = null;

                        // Restaurar colores a rojo
                        for (int i = 0; i < numPics; i++)
                        {
                            picsList[i].Image = DrawCircle(25, 25, Color.Red);
                        }
                    };
                    infoForm.Show();
                }
            }
        }


        // Para seleccionar el punto de desvío y cambiar el color de selección del vuelo seleccionado
        private void miPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && selectedFlightForDiversion != null)
            {
                Console.WriteLine($"Estado antes de desviar - Punto de desviación: {selectedFlightForDiversion.GetDiversionPoint() != null}");
                
                Position diversionPoint = new Position(e.X, e.Y);
                if (selectedFlightForDiversion.GetCurrentPosition().Distancia(diversionPoint) < 1.0)
                {
                    Console.WriteLine("The deviation point is to close to the current position");
                    position_lbl.Text = "The deviation point is to close to the current position";
                    return;
                }

                FlightPlan flight = flightsList.GetFlightPlanWthId(selectedFlightForDiversion.GetId());
                flight.SetDiversionPoint(diversionPoint);

                List<Segment> route = flight.GetPredictedTrajectories();
                Position currentPosition = flight.GetCurrentPosition();

                if (route.Count > 0)
                {
                    Segment lastSegment = route.Last();
                    if (!lastSegment.HasPassed(currentPosition))
                    {
                        // Si el segmento actual no ha sido completado, lo eliminamos
                        route.RemoveAt(route.Count - 1);
                    }
                }

                flight.ClearPredictedTrajectories();
                flight.AddSegmentsWhenDiversion(diversionPoint);

                Console.WriteLine($"Asignando nuevo punto de desviación a {selectedFlightForDiversion.GetId()}");
                Console.WriteLine($"Punto de desviación seleccionado: ({diversionPoint.GetX()}, {diversionPoint.GetY()})");
                Console.WriteLine($"Estado después de desviar - Punto de desviación: {selectedFlightForDiversion.GetDiversionPoint() != null}");


                // Actualizar los colores de los círculos
                for (int i = 0; i < numPics; i++)
                {
                    FlightPlan f = picsList[i].Tag as FlightPlan;
                    if (f == null)
                        continue;

                    Color color;
                    if (f == selectedFlightInfo)
                        color = Color.Purple;
                    else
                        color = Color.Red;

                    picsList[i].Image = DrawCircle(25, 25, color);
                }

                miPanel.Invalidate(); // Redibuja
                selectedFlightForDiversion = null;
            }
        }

        // Para dibujar los visuales en el panel / pantalla trayectorias, puntos, zonas de seguridad, etc
        private void MiPanel_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("Dibujando zonas de seguridad y trayectorias..."); // Debug
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Suavizar bordes

            // Instanciado de los lápizes de dibujo
            using (Pen penFutureTrajectory = new Pen(Color.Blue, 2) { DashStyle = DashStyle.Dash })
            using (Pen penPastTrajectory = new Pen(Color.Green, 2) { DashStyle = DashStyle.Dash })
            using(Pen penPredictedTrajectory = new Pen(Color.SkyBlue, 2) { DashStyle = DashStyle.Dash })
            using (Brush diversiontPointBrush = new SolidBrush(Color.Yellow))
            {

                int safetyRadius = Convert.ToInt32(safetyDistance);
                List<int> conflictingFlights = DetectConflicts();

                Console.WriteLine($"Safety Distance: {safetyRadius}");

                // Draws the whole trajectory on the sector in blue
                DrawFutureTrajectories(g, penFutureTrajectory);

                // Draws the already flown trajectroy in the sectoror from the historic positions
                DrawPastTrajectories(g, penPastTrajectory);

                // Draws the safety zones
                DrawSafetyZones(g, conflictingFlights, safetyRadius);

                // Draws the trajectory the flight will follow if divarted

                for (int i = 0; i < flightsList.GetNumber(); i++)
                {
                    FlightPlan flight = flightsList.GetFlightPlan(i);
                    if (flight.GetDiversionPoint() != null)
                    {
                        DrawPredictedTrajectoryOfDeviations(g, penPredictedTrajectory, flight);
                    }
                }

                // Draws the point selected vor diversion
                DrawDiversionPoint(g, diversiontPointBrush);
            }
        }

        //Dibuja la trayectoria que seguirá el avión si mantenemos el nuevo rumbo hasta el punto delimitado y
        //luego va hacia el punto en el que debe salir del sector.
        private void DrawPredictedTrajectoryOfDeviations(Graphics g, Pen pen, FlightPlan flight)
        {
            Position diversionPoint = flight.GetDiversionPoint();

            if (diversionPoint == null)
                return;

            if (flight.GetCurrentPosition().Distancia(diversionPoint) < 1.0)
            {
                flight.SetDiversionPoint(null);
                flight.ClearPredictedTrajectories();
                return;
            }

            List<Segment> futureSegments = flight.GetPredictedTrajectories();

            bool isFirst = true;
            foreach (Segment segment in futureSegments)
            {
                PointF start, end;

                if (isFirst)
                {
                    // Dibuja desde la posición actual del vuelo
                    start = new PointF(
                        (float)flight.GetCurrentPosition().GetX(),
                        (float)flight.GetCurrentPosition().GetY());
                    isFirst = false;
                }
                else
                {
                    start = new PointF(
                        (float)segment.GetStart().GetX(),
                        (float)segment.GetStart().GetY());
                }

                end = new PointF(
                    (float)segment.GetEnd().GetX(),
                    (float)segment.GetEnd().GetY());

                g.DrawLine(pen, start, end);
            }

        }

        //Dibuja el punto al que debe dirigirse el avión.
        private void DrawDiversionPoint(Graphics g, Brush brush)
        {
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                FlightPlan flight = flightsList.GetFlightPlan(i);
                Position diversionPosition = flight.GetDiversionPoint();

                if (flight.GetCurrentPosition().Equals(diversionPosition))
                {
                    flight.SetDiversionPoint(null);
                    continue;
                }

                if(diversionPosition != null)
                {
                    PointF diversionPoint = new PointF(
                        (float)diversionPosition.GetX(),
                        (float)diversionPosition.GetY());

                    float radius = 12f;
                    g.FillEllipse(brush, diversionPoint.X - radius/2, diversionPoint.Y - radius/2, radius, radius);
                }
            }
        }

        //Dibuja las trayectorias a futuro para ver si hay potenciales cruces.
        private void DrawFutureTrajectories(Graphics g, Pen pen)
        {
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {

                if (flightsList.GetFlightPlan(i).GetFinalPosition() != null)
                {
                    PointF start = new PointF(
                        (float)flightsList.GetFlightPlan(i).GetCurrentPosition().GetX(),
                        (float)flightsList.GetFlightPlan(i).GetCurrentPosition().GetY());

                    PointF end = new PointF(
                        (float)flightsList.GetFlightPlan(i).GetFinalPosition().GetX(),
                        (float)flightsList.GetFlightPlan(i).GetFinalPosition().GetY());

                    g.DrawLine(pen, start, end);
                }
            }
        }

        //Dibuja la parte de la trayectoria que ya ha recorrido el avión para ver de dónde viene.
        private void DrawPastTrajectories(Graphics g, Pen pen)
        {

            List<FlightPlanList> allHistory = historicList.GetAllHistory();

            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                if (allHistory.Count < 2)
                    continue;

                // Usar la posición real del primer paso como punto inicial
                FlightPlan firstFlight = allHistory[0].GetFlightPlan(i);
                PointF previousPoint = new PointF(
                    (float)firstFlight.GetCurrentPosition().GetX(),
                    (float)firstFlight.GetCurrentPosition().GetY());

                // Empezar desde el segundo paso para evitar línea "desde origen"
                for (int j = 1; j < allHistory.Count; j++)
                {
                    FlightPlan currentFlight = allHistory[j].GetFlightPlan(i);
                    PointF currentPoint = new PointF(
                        (float)currentFlight.GetCurrentPosition().GetX(),
                        (float)currentFlight.GetCurrentPosition().GetY());

                    g.DrawLine(pen, previousPoint, currentPoint);

                    previousPoint = currentPoint;
                }
            }
        }


        //Dibuja las elipses en la que no debe intrometerse ningún otro avión.
        private void DrawSafetyZones(Graphics g, List<int> conflictingFlights, int safetyRadius)
        {
            for (int i = 0; i < numPics; i++)
            {
                if (picsList[i] == null) continue;

                // Centrar los picturebox

                float centerX = picsList[i].Left + picsList[i].Width / 2;
                float centerY = picsList[i].Top + picsList[i].Height / 2;

                Console.WriteLine($"Avión {i}: X={centerX}, Y={centerY}");

                using (Pen penSafetyZone = conflictingFlights.Contains(i) ?
                    new Pen(Color.Red, 2) :
                    new Pen(Color.Yellow, 2))
                {

                    RectangleF safetyZone = new RectangleF(
                        centerX - safetyRadius,
                        centerY - safetyRadius,
                        safetyRadius * 2,
                        safetyRadius * 2);

                    g.DrawEllipse(penSafetyZone, safetyZone);
                }
            }
        }

        private Bitmap DrawCircle(int width, int height, Color color)
        {
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent); // Background color
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillEllipse(brush, 5, 5, width - 10, height - 10);    // Circle with padding
                }
            }
            return bmp;
        }

        // Dibuja las pictureBox (cuadradas) de circulares
        private void MakePictureBoxCircular(PictureBox pictureBox)
        {
            int diameter = Math.Min(pictureBox.Width, pictureBox.Height);
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, diameter, diameter);
            pictureBox.Region = new Region(path); // Apply circular region
        }

        //Refresca la simulación después de que pase un periodo de tiempo.
        private void UpdateFlightVisual(int i)
        {
            var flight = flightsList.GetFlightPlan(i);
            var pos = flight.GetCurrentPosition();
            PointF position = new PointF(Convert.ToSingle(pos.GetX()), Convert.ToSingle(pos.GetY()));

            // Calcular el centro de la imagen
            float centerX = position.X - picsList[i].Width / 2;
            float centerY = position.Y - picsList[i].Height / 2;


            // Actualiza la posición del PictureBox
            picsList[i].Left = (int)Math.Round(centerX);
            picsList[i].Top = (int)Math.Round(centerY);

            // Actualiza la posición de la Label asociada
            labelsList[i].Left = picsList[i].Left + 10;
            labelsList[i].Top = picsList[i].Top - 20;

            MakePictureBoxCircular(picsList[i]);
        }

        //Función para hacer que la simulación se simule automáticamente, donde en cada 
        //segundo pasa el tiempo de ciclo que se haya determinado anteriormente.
        private void AutomaticMove_btn_Click_1(object sender, EventArgs e)
        {
            Timer_ATM_move.Interval = 1000;
            Timer_ATM_move.Start();

            AutomaticMove_btn.Text = "Stop";

            // Cambiar la función de start a finalizar
            AutomaticMove_btn.Click -= AutomaticMove_btn_Click;
            AutomaticMove_btn.Click += Stop_btn_Click;
        }

        //Para parar la simulación automática.
        private void Stop_btn_Click(object sender, EventArgs e)
        {
            Timer_ATM_move.Stop();

            AutomaticMove_btn.Text = "Automatic move";

            // Cambiar la función de finalizar a start
            AutomaticMove_btn.Click -= Stop_btn_Click;
            AutomaticMove_btn.Click += AutomaticMove_btn_Click_1;
        }

        private void Timer_ATM_move_Tick(object sender, EventArgs e)
        {
            conflictNow = false; // Variable para verificar si hay conflicto en este Tick

            // Reiniciar estado de conflictos
            conflictNow = false;



            // Resetear colores de las etiquetas
            ResetLabelColors();

            // Mover todos los vuelos
            MoveAllFlights();

            // Actualizar elementos visuales
            UpdateVisualElements();

            // Añadir al historial
            historicList.AddFlightsList(flightsList.CopyFlightPlanList());

            miPanel.Invalidate();
        }

        private void MoveAllFlights()
        {
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                // Mover el vuelo
                flightsList.GetFlightPlan(i).Move(loopTime);

                // Verificar conflictos para este vuelo
                CheckConflictsForFlight(i);
            }
        }

        //Verifica que no haya conflictos. Y señalizaciones visuales de los conflictos
        private void CheckConflictsForFlight(int currentIndex)
        {
            for (int j = currentIndex + 1; j < flightsList.GetNumber(); j++)
            {
                if (flightsList.GetFlightPlan(currentIndex).ConflictDetection(
                    flightsList.GetFlightPlan(j), safetyDistance))
                {
                    HandleConflict(currentIndex, j);
                }
            }
        }

        // En caso de conflicto aactualiza los labels de los vuelos
        private void HandleConflict(int flight1, int flight2)
        {
            conflictNow = true;
            flightsInConflict.AddFlightPlan(flightsList.GetFlightPlan(flight1));
            flightsInConflict.AddFlightPlan(flightsList.GetFlightPlan(flight2));

            UpdateConflictLabel(flight1);
            UpdateConflictLabel(flight2);
        }

        private List<int> DetectConflicts()
        {
            var result = flightsList.DetectAndHandleConflicts(safetyDistance);
            flightsInConflict = result.ConflictsList;
            return result.ConflictingFlightIndices;
        }

        private void UpdateConflictLabel(int flightIndex)
        {
            if (flightIndex < labelsList.Count && labelsList[flightIndex] != null)
            {
                labelsList[flightIndex].BackColor = Color.FromArgb(200, 255, 100, 100);
                labelsList[flightIndex].ForeColor = Color.White;
            }
        }

        private void UpdateVisualElements()
        {
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                UpdateFlightPosition(i);
            }
        }

        private void UpdateFlightPosition(int i)
        {
            PointF position = new PointF(
                (float)flightsList.GetFlightPlan(i).GetCurrentPosition().GetX(),
                (float)flightsList.GetFlightPlan(i).GetCurrentPosition().GetY());

            if (picsList[i] != null)
            {
                int newLeft = (int)Math.Round(position.X - picsList[i].Width / 2);
                int newTop = (int)Math.Round(position.Y - picsList[i].Height / 2);

                picsList[i].Location = new Point(newLeft, newTop);

                if (labelsList[i] != null)
                {
                    labelsList[i].Location = new Point(newLeft + 10, newTop - 20);
                }
            }
        }

        private void UpdateLabels()
        {
            for (int i = 0; i < numPics; i++)
            {
                FlightPlan vuelo = (FlightPlan)picsList[i].Tag; // Obtener el vuelo asociado al PictureBox
                labelsList[i].Text = $"ID: {vuelo.GetId()} | Speed: {vuelo.GetVelocidad()}"; // Actualizar el Label
            }

            miPanel.Invalidate();
        }

        private void Reset_btn_Click(object sender, EventArgs e)
        {

            // 1. Limpiar desviaciones antes de copiar
            if (flightsList != null)
            {
                flightsList.ResetDiversionPoints();
            }

            flightsList = originalFlightsList.CopyFlightPlanList();

            selectedFlightForDiversion = null;
            diversionPositionCopy = null;

            // Limpiar el historial y añadir la posición inicial
            historicList = new FlightsHistoricList();
            historicList.AddFlightsList(flightsList.CopyFlightPlanList());

            // Actualizar las posiciones visuales
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                flightsList.GetFlightPlan(i).Restart();
                UpdateFlightVisual(i);
            }

            miPanel.Invalidate();

        }

        private void infoFlights_btn_Click(object sender, EventArgs e)
        {
            InfoFlights form = new InfoFlights(flightsList);
            form.Show();
        }

        private void conflictInfo_Btn_Click(object sender, EventArgs e)
        {
            if (flightsList.GetNumber() > 1)
            {
                PredecirConflicto("botón");
            }
            else { position_lbl.Text = "There need to be more than 1 flight."; }
        }


        // Método de visuales que utiliza el método ComputeMinDistance para actualizar conflictos
        private bool PredecirConflicto(string text, int i = 0, int j = 1)
        {
            bool Conflicto = false;
            string txt = text;

            var(numerador, denominador, tmin, dmin) = flightsList.ComputeMinDistance(i, j);

            // Verificamos si el denominador es cero (misma velocidad)
            if (denominador == 0)
            {
                if (txt == "botón")
                {     
                    position_lbl.TextAlign = ContentAlignment.MiddleCenter;
                    position_lbl.BackColor = Color.Red;
                    position_lbl.ForeColor = Color.White;
                    position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
                    position_lbl.Text = "No potential hazard ~ Their relative distance won't change ";
                }
                return Conflicto;
            }

            // Si tmin < 0, significa que el evento ocurrió en el pasado
            if (tmin < 0)
            {
                tmin = 0; // Solo analizamos conflictos en el futuro
                return Conflicto;
            }

            Console.WriteLine($"tmin: {tmin}, dmin: {dmin}");

            if (dmin <= safetyDistance * 2)
            {
                Conflicto = true;
                if (txt == "botón")
                {
                    position_lbl.TextAlign = ContentAlignment.MiddleCenter;
                    position_lbl.BackColor = Color.Red;
                    position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
                    position_lbl.Text = "¡¡ Conflict Alert !!";
                }
                return Conflicto;
            }
            else
            {
                if (txt == "botón")
                {
                    position_lbl.TextAlign = ContentAlignment.MiddleCenter;
                    position_lbl.BackColor = Color.Green;
                    position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
                    position_lbl.Text = "No conflict";

                }
            }

            return Conflicto;
        }


        // Botón para tirar atrás paso por paso en la simulación
        private void GoBackwards_btn_Click(object sender, EventArgs e)
        {
            if(historicList.GetNumber() <= 1)
            {
                position_lbl.TextAlign = ContentAlignment.MiddleCenter;
                position_lbl.BackColor = Color.Yellow;
                position_lbl.Font = new System.Drawing.Font(position_lbl.Font, FontStyle.Bold);
                position_lbl.Text = "There is no previous positions available.";
                return;
            }


            // Resetear colores primero
            for (int i = 0; i < numPics; i++)
            {
                if (labelsList[i] != null)
                {
                    labelsList[i].BackColor = Color.FromArgb(128, 220, 220, 220);
                    labelsList[i].ForeColor = Color.Black;
                }
            }

            string selectedFlightId = selectedFlightForDiversion?.GetId();

            FlightPlanList previousPositions = historicList.BackwardsPosition();

            if (previousPositions != null)
            {
                this.flightsList = previousPositions.CopyFlightPlanList();
                
                if (!string.IsNullOrEmpty(selectedFlightId))
                {
                    selectedFlightForDiversion = flightsList.GetFlightPlanWthId(selectedFlightId);
                }

                for (int i = 0; i < flightsList.GetNumber(); i++)
                {
                    var currentFlight = flightsList.GetFlightPlan(i);
                    var historicFlight = previousPositions.GetFlightPlan(i);

                    // Restaurar punto de desviación si existía
                    if (historicFlight.GetDiversionPoint() != null)
                    {
                        currentFlight.SetDiversionPoint(historicFlight.GetDiversionPoint().CopyPosition());
                    }
                    else
                    {
                        currentFlight.SetDiversionPoint(null);
                    }
                }
            }

            // Verificar conflictos entre todos los pares de vuelos
            bool conflictDetected = false;
            for (int i = 0; i < flightsList.GetNumber(); i++)
            {
                for (int j = i + 1; j < flightsList.GetNumber(); j++)
                {
                    if (flightsList.GetFlightPlan(i).ConflictDetection(flightsList.GetFlightPlan(j), safetyDistance))
                    {
                        conflictDetected = true;
                        // Cambiar color de los labels en conflicto
                        if (i < labelsList.Count && labelsList[i] != null)
                        {
                            labelsList[i].BackColor = Color.FromArgb(200, 255, 100, 100);
                            labelsList[i].ForeColor = Color.White;
                        }
                        if (j < labelsList.Count && labelsList[j] != null)
                        {
                            labelsList[j].BackColor = Color.FromArgb(200, 255, 100, 100);
                            labelsList[j].ForeColor = Color.White;
                        }
                    }
                }
            }
            for (int i = 0; i < numPositionsList; i++)
            {
                UpdateFlightVisual(i);
            }
            miPanel.Invalidate();
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            flightsList.ClearList();

            this.Close();
        }

        //Botón para guardar la simulación el punto en el que está en un fichero de texto.
        private void saveToTxt_btn_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save file as";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FlightPlanSaver txtfile = new FlightPlanSaver();
                    txtfile.SaveToFile(saveFileDialog.FileName, this.flightsList, this.safetyDistance, this.loopTime);

                }
            }
        }

        //Botón para guardar la simulación el punto en el que está en un pdf.
        private void icon_btn_SavePdf_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF file (*.pdf)|*.pdf";
                saveFileDialog.Title = "Exportar simulación a PDF";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var pdfSaver = new FlightPlanPdfSaver();
                    pdfSaver.SaveToPdf(saveFileDialog.FileName, this.flightsList, this.safetyDistance, this.loopTime);
                }
            }

        }
    }
}
