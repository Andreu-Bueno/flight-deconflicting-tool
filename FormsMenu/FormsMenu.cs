using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;
using FontAwesome.Sharp;


namespace FormsMenu
{
    public partial class FormsMenu : Form
    {

        FlightPlanList miLista = new FlightPlanList();
        private int loopTime = 60; // Valor por defecto
        private double safetyDistance;
        int j = 0;
        SQLiteConnection cnx;
        LoginForm loginForm;
        string username;
        string password;

        public FormsMenu(SQLiteConnection connection, LoginForm form, string Username, string Password)
        {
            InitializeComponent();
            cnx = connection;
            loginForm = form;

            username = Username;
            password = Password;


            AddIcons();
        }

        //Para abrir el form en el que está la simulación.
        private void simulationDisplayToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SimDisplay form = new SimDisplay(loopTime, safetyDistance);
            form.SetFlightsList(miLista.CopyFlightPlanList());
            form.ShowDialog();
        }

        //Para añadir planes de vuelo a nuestra simulación.
        private void addFlightplanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AñadirFlightplans Form = new AñadirFlightplans();
            Form.SetOpened(j);
            Form.SetFlightPlansList(miLista);
            Form.ShowDialog();
            var (lista, safetyDistance, loopTime) = Form.DameListaYDatos();
            this.safetyDistance = safetyDistance;
            this.loopTime = loopTime;
            j = Form.GetOpened();
        }


        //Añadimos tanto la distancia de seguridad como el tiempo de ciclo, datos esenciales para la simulación.
        private void simulationSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SimulationSettings form = new SimulationSettings();
            form.ShowDialog();

            safetyDistance = form.GetSafetyDistance();
            loopTime = form.GetLoopTime();
        }

        //Abre el form para darte de baja de la base de datos (eliminar tu cuenta)
        private void darToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAccount form = new DeleteAccount(loginForm, this);
            form.ShowDialog();
        }

        //Un botón que cierra por completo la aplicación, para evitar que siga ejecutándose en segundo plano.
        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cnx.Close();
            this.Close();
            Application.Exit();
        }

        //Añade los iconos deseados para que el diseño final sea más atractivo.
        private void AddIcons()
        {

            iconMenuItem.IconChar = FontAwesome.Sharp.IconChar.Bars;
            iconMenuItem.IconFont = FontAwesome.Sharp.IconFont.Solid;

            //
            closeToolStripMenuItem1.Image = IconChar.SquareXmark.ToBitmap(Color.LightCoral, 16);
            closeToolStripMenuItem1.MouseEnter += (s, e) =>
            {
                closeToolStripMenuItem1.Image = IconChar.SquareXmark.ToBitmap(Color.Red, 16);
            };
            closeToolStripMenuItem1.MouseLeave += (s, e) =>
            {
                closeToolStripMenuItem1.Image = IconChar.SquareXmark.ToBitmap(Color.LightCoral, 16);
            };

            //
            addFlightplanToolStripMenuItem.Image = IconChar.Plane.ToBitmap(Color.Gray, 16);
            addFlightplanToolStripMenuItem.MouseEnter += (s, e) =>
            {
                addFlightplanToolStripMenuItem.Image = IconChar.Plane.ToBitmap(Color.Blue, 16);
            };
            addFlightplanToolStripMenuItem.MouseLeave += (s, e) =>
            {
                addFlightplanToolStripMenuItem.Image = IconChar.Plane.ToBitmap(Color.Gray, 16);
            };

            //
            simulationDisplayToolStripMenuItem1.Image = IconChar.Desktop.ToBitmap(Color.Gray, 16);
            simulationDisplayToolStripMenuItem1.MouseEnter += (s, e) =>
            {
                simulationDisplayToolStripMenuItem1.Image = IconChar.Desktop.ToBitmap(Color.Blue, 16);
            };
            simulationDisplayToolStripMenuItem1.MouseLeave += (s, e) =>
            {
                simulationDisplayToolStripMenuItem1.Image = IconChar.Desktop.ToBitmap(Color.Gray, 16);
            };
            
            //
            simulationSettingsToolStripMenuItem.Image = IconChar.Gear.ToBitmap(Color.Gray, 16);
            simulationSettingsToolStripMenuItem.MouseEnter += (s, e) =>
            {
                simulationSettingsToolStripMenuItem.Image = IconChar.Gear.ToBitmap(Color.Blue, 16);
            };
            simulationSettingsToolStripMenuItem.MouseLeave += (s, e) =>
            {
                simulationSettingsToolStripMenuItem.Image = IconChar.Gear.ToBitmap(Color.Gray, 16);
            };

            //
            darToolStripMenuItem.Image = IconChar.UserXmark.ToBitmap(Color.Gray, 16);
            darToolStripMenuItem.MouseEnter += (s, e) =>
            {
                darToolStripMenuItem.Image = IconChar.UserXmark.ToBitmap(Color.Blue, 16);
            };
            darToolStripMenuItem.MouseLeave += (s, e) =>
            {
                darToolStripMenuItem.Image = IconChar.UserXmark.ToBitmap(Color.Gray, 16);
            };

            //
            groupPicture_btn.Image = IconChar.UsersLine.ToBitmap(Color.Gray, 80);
            groupPicture_btn.MouseEnter += (s, e) =>
            {
                groupPicture_btn.Image = IconChar.UsersLine.ToBitmap(Color.Blue, 80);
            };
            groupPicture_btn.MouseLeave += (s, e) =>
            {
                groupPicture_btn.Image = IconChar.UsersLine.ToBitmap(Color.Gray, 80);
            };

            //
            airlinesDb_btn.Image = IconChar.Database.ToBitmap(Color.Gray, 80);
            airlinesDb_btn.MouseEnter += (s, e) =>
            {
                airlinesDb_btn.Image = IconChar.Database.ToBitmap(Color.Blue, 80);
            };
            airlinesDb_btn.MouseLeave += (s, e) =>
            {
                airlinesDb_btn.Image = IconChar.Database.ToBitmap(Color.Gray, 80);
            };

            //
            instructions_functionalities_btn.Image = IconChar.Clipboard.ToBitmap(Color.Gray, 80);
            instructions_functionalities_btn.MouseEnter += (s, e) =>
            {
                instructions_functionalities_btn.Image = IconChar.Clipboard.ToBitmap(Color.Blue, 80);
            };
            instructions_functionalities_btn.MouseLeave += (s, e) =>
            {
                instructions_functionalities_btn.Image = IconChar.Clipboard.ToBitmap(Color.Gray, 80);
            };

            //
            editUserToolStripMenuItem.Image = IconChar.UserTag.ToBitmap(Color.Gray, 16);
            editUserToolStripMenuItem.MouseEnter += (s, e) =>
            {
                editUserToolStripMenuItem.Image = IconChar.UserTag.ToBitmap(Color.Blue, 16);
            };
            editUserToolStripMenuItem.MouseLeave += (s, e) =>
            {
                editUserToolStripMenuItem.Image = IconChar.UserTag.ToBitmap(Color.Gray, 16);
            };

        }

        //Si clicas te abre un form en el que se ve la fotografía de los miembros del equipo.
        private void iconButton1_Click(object sender, EventArgs e)
        {
            GroupPictureForm form = new GroupPictureForm();
            form.Show();
        }

        //Abre un form donde encontramos todos los procesos relacionados con las aerolíneas.
        private void airlinesDb_btn_Click_1(object sender, EventArgs e)
        {
            AirlinesForm form = new AirlinesForm();
            form.Show();
        }
        
        // Abre un form donde se ven las instrucciones y funcionalidades añadidas del proyecto
        private void instructions_functionalities_btn_Click(object sender, EventArgs e)
        {
            Tutorial_FunctionalitiesForm form = new Tutorial_FunctionalitiesForm();
            form.Show();
        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditUserForm form = new EditUserForm(username, password);
            form.Show();
        }
    }
}
