using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BDcreadorCSVoleDB
{
    class IndicadorEspera : IDisposable
    {
        private Form formularioPorMostrar;
        private Point ubicacion;

        public IndicadorEspera(Point ubicacion1)
        {
            ubicacion = ubicacion1;
            Thread hiloDeEjecucion = new Thread(new ThreadStart(trabajoEnHilo));
            hiloDeEjecucion.IsBackground = true;
            hiloDeEjecucion.SetApartmentState(ApartmentState.STA);
            hiloDeEjecucion.Start();
        }

        public void Dispose()
        {
            formularioPorMostrar.Invoke(new MethodInvoker(stopThread));
        }

        private void stopThread()
        {
            formularioPorMostrar.Close();
        }

        private void trabajoEnHilo()
        {
            formularioPorMostrar = new frmEspera();
            formularioPorMostrar.StartPosition = FormStartPosition.Manual;
            formularioPorMostrar.Location = ubicacion;
            formularioPorMostrar.TopMost = true;
            formularioPorMostrar.Size = new Size(89, 110);
            Application.Run(formularioPorMostrar);
        }
    }
}
