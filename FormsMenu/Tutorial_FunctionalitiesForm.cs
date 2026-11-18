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
    public partial class Tutorial_FunctionalitiesForm : Form
    {
        // Explicación y tutorial del programa / simulador
        public Tutorial_FunctionalitiesForm()
        {
            InitializeComponent();

            text_lbl.Text = "Hello user, here we have a resume of the best functionalities of our code:" +
                "\n" + "\n" +
                "\n- The most remarkable one is that you can modify the heading of " + "\n" +
                "\t" + "\t" + "the airplanes by right clicking on the desired plane and right clicking again in the desired heading point on the panel." +
                "\n" + "\n" +
                "\n- We also add some requirements for the password, it must be a combination of letters and numbers," + "\n" +
                "\t" + "\t" + "minimum 8 characters and without spacing, for it to be more robust; you can test this by creating an account." +
                "\n" + "\n" +
                "\n- For passwords we also added a hashing or codification system for more " + "\n" +
                "\t" + "\t" + "added security in our data base, so not anyone can get anyones password;" + "\n" +
                "\t" + "\t" + " you can see this in IO(DB) --> FlightDBManager --> ComputeSha256Hash." +
                "\n" + "\n" +
                "\n- We also can export the simulated flightplans and get the comunications with " + "\n" +
                "\t" + "\t" + "the airlines of the actions taken to a pdf if you need to; you can check this on SimDisplay." +
                "\n" + "\n" +
                "\n- We can delete a user from the data base if we don't want it anymore; " + "\n" +
                "\t" + "\t" + "you can try this on FormsMenus strip." +
                "\n" + "\n" +
                "\n- If we forgot our password we can reset it with a code sent by email; " + "\n" +
                "\t" + "\t" + "check this out on Login.";
        }
    }
}
