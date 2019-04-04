using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDcreadorCSVoleDB
{
    public partial class frmEspera : Form
    {
        public frmEspera()
        {
            InitializeComponent();
        }

        public void frmEspera_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
