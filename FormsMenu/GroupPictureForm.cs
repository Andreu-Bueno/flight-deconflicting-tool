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
    public partial class GroupPictureForm : Form
    {
        public GroupPictureForm()
        {
            InitializeComponent();

            //Se ajusta la foto al picture box.
            pictureBox1.Image = Properties.Resources.GroupPicture;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
