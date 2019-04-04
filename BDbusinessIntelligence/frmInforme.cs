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
    public partial class frmInforme : Form
    {
        DateTime fechaSugerida;
        public frmInforme(string ruta, DateTime fecha)
        {
            InitializeComponent();
            fechaSugerida = fecha;
            rtb.LoadFile(ruta);
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
        }

        public frmInforme(DateTime fecha, string richtextfile)
        {
            InitializeComponent();
            fechaSugerida = fecha;
            rtb.Rtf = richtextfile;
        }

        private void btParaImpresion_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Texto Enriquecido (.rtf)|*.rtf";
            saveFileDialog1.FileName = "Informe_" + fechaSugerida.ToString("yyyyMMdd_HHmmss");
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.DefaultExt = ".rtf";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            rtb.SaveFile(saveFileDialog1.FileName);
            System.Diagnostics.Process.Start(saveFileDialog1.FileName);
        }
    }
}
