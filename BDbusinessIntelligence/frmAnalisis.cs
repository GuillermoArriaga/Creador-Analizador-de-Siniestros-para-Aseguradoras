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
    public partial class frmAnalisis : Form
    {
        bool fechaCambiarOrden = false;
        bool mesCambiarOrden = false;

        public frmAnalisis()
        {
            InitializeComponent();
        }

        private void frmAnalisis_Load(object sender, EventArgs e)
        {
            cbAnalisisTipo.Items.AddRange(new string[]
            {
                "Capital de aseguradora",
                "Choques en el estado",
                "Choques en la marca de autos",
                "Choques por piloto",
                "Actividad del ajustador"
            });

            cbAnalisisTipo.SelectedIndex = 0;
            cbAnalisisTipo_SelectedIndexChanged(null, null);
            cbAnalisisElemento.SelectedIndex = 0;
        }

        private void cbAnalisisTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbAnalisisElemento.Items.Clear();
                cbAnalisisElemento.Text = "";

                switch (cbAnalisisTipo.SelectedItem)
                {
                    case "Capital de aseguradora":
                        for (int i = 0; i < Comun.baseDatos.Tables["aseguradoras"].Rows.Count; i++)
                        {
                            cbAnalisisElemento.Items.Add(Comun.baseDatos.Tables["aseguradoras"].Rows[i][1] + " : " + Comun.baseDatos.Tables["aseguradoras"].Rows[i][0]);
                        }
                        //MessageBox.Show(Comun.idCombo(baseDatos.Tables["aseguradoras"].Rows[0][1] + " : " + baseDatos.Tables["aseguradoras"].Rows[0][0]));
                        break;
                    case "Choques en el estado":
                        for (int i = 0; i < Comun.baseDatos.Tables["lugares"].Rows.Count; i++)
                        {
                            string estado = Comun.baseDatos.Tables["lugares"].Rows[i][2].ToString();
                            if (!cbAnalisisElemento.Items.Contains(estado))
                            {
                                cbAnalisisElemento.Items.Add(estado);
                            }
                        }
                        break;
                    case "Choques en la marca de autos":
                        for (int i = 0; i < Comun.baseDatos.Tables["automoviles"].Rows.Count; i++)
                        {
                            string marca = Comun.baseDatos.Tables["automoviles"].Rows[i][2].ToString();
                            if (!cbAnalisisElemento.Items.Contains(marca))
                            {
                                cbAnalisisElemento.Items.Add(marca);
                            }                            
                        }
                        break;
                    case "Choques por piloto":
                        for (int i = 0; i < Comun.baseDatos.Tables["pilotos"].Rows.Count; i++)
                        {
                            cbAnalisisElemento.Items.Add(Comun.baseDatos.Tables["pilotos"].Rows[i][1] + " : " + Comun.baseDatos.Tables["pilotos"].Rows[i][0]);
                        }
                        break;
                    case "Actividad del ajustador":
                        for (int i = 0; i < Comun.baseDatos.Tables["ajustadores"].Rows.Count; i++)
                        {
                            cbAnalisisElemento.Items.Add(Comun.baseDatos.Tables["ajustadores"].Rows[i][1] + " : " + Comun.baseDatos.Tables["ajustadores"].Rows[i][0]);
                        }
                        break;
                }
                //cbAnalisisElemento.DroppedDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btAnalisis_Click(object sender, EventArgs e)
        {
            if (tbFechaIni.Text.Length < 10 || tbFechaFin.Text.Length < 10)
            {
                MessageBox.Show("Las fechas deben ser dd_mm_yyyy o yyyy_mm_dd");
                return;
            }

            using (new IndicadorEspera(this.Location))
            {
                switch (cbAnalisisTipo.Text)
                {
                    case "Capital de aseguradora":
                        AnalisisCapitalAseguradora();
                        break;
                    case "Choques en el estado":
                        AnalisisChoques("un estado.", 2, "lugares", "idlugar");
                        break;
                    case "Choques en la marca de autos":
                        AnalisisChoques("una marca de automoviles.", 2, "automoviles", "idautomovilx");
                        break;
                    case "Choques por piloto":
                        AnalisisChoques("a un piloto.", 0, "pilotos", "idpilotox");
                        break;
                    case "Actividad del ajustador":
                        AnalisisChoques("a un ajustador.", 0, "ajustadores", "idajustadorx");
                        break;
                }
            }
        }

        private void AnalisisChoques(string mensaje, int ubicacion, string tablaNombre, string campoNombre)
        {
            int choquesMes = 0;
            double costoMes = 0;
            int meses = 0;
            double costoTotal = 0;
            int choquesTotal = 0;

            if (!cbAnalisisElemento.Items.Contains(cbAnalisisElemento.Text))
            {
                MessageBox.Show("Seleccione " + mensaje);
                return;
            }

            string estado = cbAnalisisElemento.SelectedItem.ToString();
            if (tablaNombre == "pilotos" || tablaNombre == "ajustadores")
            {
                estado = Comun.idCombo(estado);
            }

            DateTime fechaini = ObtenerFecha(tbFechaIni.Text);
            DateTime fechafin = ObtenerFecha(tbFechaFin.Text);

            List<infochoque> infoChoque = new List<infochoque>();

            choquesMes = 0;
            DateTime fecha = new DateTime(fechaini.Year, fechaini.Month, 1);
            DateTime ultimaFechaGuardada = fecha;

            for (int i = 0; i < Comun.baseDatos.Tables["choques"].Rows.Count; i++)
            {
                // Solo autos con esta aseguradora
                DataRow fila = Comun.baseDatos.Tables["choques"].Rows[i];
                DateTime fechachoque = ObtenerFecha(fila["fecha"].ToString());

                if (fechachoque.CompareTo(fechafin) > 0)
                {
                    // Informe de mes finalizado
                    infoChoque.Add(new infochoque(fecha.ToString("MMMyyyy"), choquesMes, costoMes));

                    meses++;
                    choquesTotal += choquesMes;
                    costoTotal += costoMes;

                    ultimaFechaGuardada = fecha;
                    costoMes = 0;
                    choquesMes = 0;
                    break;
                }

                if (fechachoque.CompareTo(fechaini) < 0)
                {
                    continue;
                }

                //  if (baseDatos.Tables["lugares"].Rows[numAseguradora(fila["idlugar"].ToString())][2].ToString() != estado)

                if (tablaNombre == "pilotos" || tablaNombre == "ajustadores")
                {
                    if (fila[campoNombre].ToString() != estado)
                    {
                        continue;
                    }
                }
                else if (Comun.baseDatos.Tables[tablaNombre].Rows[numAseguradora(fila[campoNombre].ToString())][ubicacion].ToString() != estado)
                {
                    continue;
                }

                // Busqueda por Mes
                if (fechachoque.CompareTo(fecha) >= 0)
                {
                    if (fechachoque.CompareTo(fecha.AddMonths(1)) < 0)
                    {
                        choquesMes++;
                        int idauto = Convert.ToInt32(fila["idautomovilx"].ToString().Substring(1)) - 1;
                        costoMes += 15000 + Convert.ToDouble(fila["intensidad"].ToString()) * Convert.ToInt32(Comun.baseDatos.Tables["automoviles"].Rows[idauto][3]); //aleatorio.Next(Convert.ToInt32(mensualidades * 0.1 / 40), Convert.ToInt32(mensualidades * 0.5));
                    }
                    else
                    {
                        // Informe de mes finalizado
                        infoChoque.Add(new infochoque(fecha.ToString("MMMyyyy"), choquesMes, costoMes));

                        meses++;
                        choquesTotal += choquesMes;
                        costoTotal += costoMes;

                        ultimaFechaGuardada = fecha;
                        costoMes = 0;
                        choquesMes = 0;
                        fecha = fecha.AddMonths(1);
                        i--;    // Busca la fecha adecuada para este registro
                        continue;
                    }
                }
            }

            // Ultimos meses sin actividad
            ultimaFechaGuardada = ultimaFechaGuardada.AddMonths(1);
            while (ultimaFechaGuardada.CompareTo(fechafin) <= 0)
            {
                // Ultimo mes sin choques hasta la fecha fin indicada por el usuario
                infoChoque.Add(new infochoque(ultimaFechaGuardada.ToString("MMMyyyy"), 0, 0));

                meses++;

                ultimaFechaGuardada = ultimaFechaGuardada.AddMonths(1);
            }

            if (ultimaFechaGuardada.Month == fechafin.Month && ultimaFechaGuardada.Year == fechafin.Year)
            {
                infoChoque.Add(new infochoque(ultimaFechaGuardada.ToString("MMMyyyy"), 0, 0));

                meses++;

            }
            // Fin de no actividad en los ultimos meses

            chart.Series.Clear();
            chart.DataBindTable(infoChoque, "mes");
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0,}K";
            chart.ChartAreas[0].AxisX.Minimum = 1;
            chart.ChartAreas[0].AxisX.Maximum = infoChoque.Count;
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

            //string ruta = Application.StartupPath + "\\grafico_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bmp";
            string ruta = Application.StartupPath + "\\grafico.bmp";

            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            chart.SaveImage(ruta, System.Drawing.Imaging.ImageFormat.Bmp);

            DataTable dt = infoTabla(cbAnalisisElemento.SelectedItem.ToString(), infoChoque);

            (new frmVisualizadorTabla(cbAnalisisElemento.SelectedItem.ToString(), dt)).Show();

            // +++++++++++++++++++++++++++++++++++++++++++++    Crear Informe
            RichTextBox rtb = new RichTextBox();
            DateTime fechaId = DateTime.Now;

            rtb.AppendText("Informe Mensual de " + cbAnalisisTipo.Text + " " + cbAnalisisElemento.Text + "\n\n");
            rtb.AppendText("    Tomado el " + fechaId.ToLongDateString() + "    " + fechaId.ToLongTimeString() + "\n\n");
            rtb.AppendText("    Periodo del " + tbFechaIni.Text + " al " + tbFechaFin.Text + "\n\n\n");
            rtb.AppendText("    Meses: " + meses + "    Choques: " + choquesTotal + "    Promedio mensual: " + (choquesTotal/(1.0 + meses)).ToString("N2") + "\n");
            rtb.AppendText("    Costo Total: " + costoTotal.ToString("N2") + "    Promedio mensual: " + (costoTotal / (meses)).ToString("N2") + "\n\n\n");

            Bitmap grafico = new Bitmap(ruta);
            Clipboard.SetDataObject(grafico);
            DataFormats.Format graficoConFormato = DataFormats.GetFormat(DataFormats.Bitmap);
            rtb.Paste(graficoConFormato);
            Clipboard.Clear();
            grafico.Dispose();
            System.IO.File.Delete(ruta);

            dgv.Columns.Clear();
            dgv.DataSource = dt;
            rtb.Font = new Font("Consolas", 9.0f, FontStyle.Regular);
            rtb.AppendText("\n\n" + TablaTextoConDGV(dgv, 0) + "\n\n");

            (new frmInforme(fechaId, rtb.Rtf)).Show();
        }

        private void AnalisisCapitalAseguradora()
        {
            double capital = 0;
            int autosAsegurados = 0;
            double mensualidades = 0;
            double prima = Convert.ToDouble(tbPrima.Text);
            string idaseguradora;
            int idase = 1;
            int choquesMes = 0;
            double costoMes = 0;

            if (!cbAnalisisElemento.Items.Contains(cbAnalisisElemento.Text))
            {
                MessageBox.Show("Seleccione una aseguradora");
                return;
            }

            idaseguradora = Comun.idCombo(cbAnalisisElemento.SelectedItem.ToString());
            idase = Convert.ToInt32(idaseguradora.Substring(1));

            // Conteo de automoviles asegurados y suma de ingresos mensuales por sus primas
            for (int i = 0; i < Comun.baseDatos.Tables["automoviles"].Rows.Count; i++)
            {
                if (idaseguradora == Comun.baseDatos.Tables["automoviles"].Rows[i][4].ToString())
                {
                    mensualidades += prima * Convert.ToInt32(Comun.baseDatos.Tables["automoviles"].Rows[i][3]);
                    autosAsegurados++;
                }
            }

            DateTime fechaini = ObtenerFecha(tbFechaIni.Text);
            DateTime fechafin = ObtenerFecha(tbFechaFin.Text);

            List<infocapital> infoCapital = new List<infocapital>();

            choquesMes = 0;
            DateTime fecha = new DateTime(fechaini.Year, fechaini.Month, 1);
            DateTime ultimaFechaGuardada = fecha;
            Random aleatorio = new Random();

            for( int i=0; i < Comun.baseDatos.Tables["choques"].Rows.Count; i++)
            {
                // Solo autos con esta aseguradora
                DataRow fila = Comun.baseDatos.Tables["choques"].Rows[i];
                DateTime fechachoque = ObtenerFecha(fila["fecha"].ToString());

                if (fechachoque.CompareTo(fechafin) > 0)
                {
                    // Informe de mes finalizado
                    capital += mensualidades - costoMes;
                    infoCapital.Add(new infocapital(fecha.ToString("MMMyyyy"), choquesMes, costoMes, capital));
                    ultimaFechaGuardada = fecha;
                    costoMes = 0;
                    choquesMes = 0;
                    break;
                }

                if (numAseguradora(fila["idajustadorx"].ToString()) != idase)
                {
                    continue;
                }

                if (fechachoque.CompareTo(fechaini) < 0)
                {
                    continue;
                }

                // Busqueda por Mes
                if (fechachoque.CompareTo(fecha) >= 0 )
                {
                    if (fechachoque.CompareTo(fecha.AddMonths(1)) < 0)
                    {
                        choquesMes++;
                        int idauto = Convert.ToInt32(fila["idautomovilx"].ToString().Substring(1)) - 1;
                        costoMes += 15000 + Convert.ToDouble(fila["intensidad"].ToString()) * Convert.ToInt32(Comun.baseDatos.Tables["automoviles"].Rows[idauto][3]); //aleatorio.Next(Convert.ToInt32(mensualidades * 0.1 / 40), Convert.ToInt32(mensualidades * 0.5));
                    }
                    else
                    {
                        // Informe de mes finalizado
                        capital += mensualidades - costoMes;
                        infoCapital.Add(new infocapital(fecha.ToString("MMMyyyy"), choquesMes, costoMes, capital));
                        ultimaFechaGuardada = fecha;
                        costoMes = 0;
                        choquesMes = 0;
                        fecha = fecha.AddMonths(1);
                        i--;    // Busca la fecha adecuada para este registro
                        continue;
                    }
                }
            }

            // Ultimos meses sin actividad
            ultimaFechaGuardada = ultimaFechaGuardada.AddMonths(1);
            while (ultimaFechaGuardada.CompareTo(fechafin) <= 0)
            {
                // Ultimo mes sin choques hasta la fecha fin indicada por el usuario
                capital += mensualidades;
                infoCapital.Add(new infocapital(ultimaFechaGuardada.ToString("MMMyyyy"), 0, 0, capital));
                ultimaFechaGuardada = ultimaFechaGuardada.AddMonths(1);
            }

            if (ultimaFechaGuardada.Month == fechafin.Month && ultimaFechaGuardada.Year == fechafin.Year)
            {
                capital += mensualidades;
                infoCapital.Add(new infocapital(ultimaFechaGuardada.ToString("MMMyyyy"), 0, 0, capital));
            }
            // Fin de no actividad en los ultimos meses

            chart.Series.Clear();
            chart.DataBindTable(infoCapital, "mes");
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0,}K";
            chart.ChartAreas[0].AxisX.Minimum = 1;
            chart.ChartAreas[0].AxisX.Maximum = infoCapital.Count;
            chart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            //chart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            string ruta = Application.StartupPath + "\\grafico.bmp";
            if (System.IO.File.Exists(ruta))
            {
                System.IO.File.Delete(ruta);
            }
            chart.SaveImage(ruta, System.Drawing.Imaging.ImageFormat.Bmp);

            DataTable dt = infoTabla(cbAnalisisElemento.SelectedItem.ToString(), infoCapital);

            (new frmVisualizadorTabla(cbAnalisisElemento.SelectedItem.ToString(), dt)).Show();

            // +++++++++++++++++++++++++++++++++++++++++++++    Crear Informe
            RichTextBox rtb = new RichTextBox();
            DateTime fechaId = DateTime.Now;

            rtb.AppendText("Informe Mensual de " + cbAnalisisTipo.Text + " " + cbAnalisisElemento.Text + "\n\n");
            rtb.AppendText("    Tomado el " + fechaId.ToLongDateString() + "    " + fechaId.ToLongTimeString() + "\n\n");

            rtb.AppendText("    Periodo del " + tbFechaIni.Text + " al " + tbFechaFin.Text + "\n\n\n");

            rtb.AppendText("    Factor de cobro mensual por el precio de cada automovil asegurado: " + tbPrima.Text + "\n\n    Ingreso Mensual: " + mensualidades.ToString("N2") + "    Automoviles asegurados: " + autosAsegurados + "\n\n\n" );

            Bitmap grafico = new Bitmap(ruta);
            Clipboard.SetDataObject(grafico);
            DataFormats.Format graficoConFormato = DataFormats.GetFormat(DataFormats.Bitmap);
            rtb.Paste(graficoConFormato);
            Clipboard.Clear();
            grafico.Dispose();
            System.IO.File.Delete(ruta);

            dgv.Columns.Clear();
            dgv.DataSource = dt;
            rtb.Font = new Font("Consolas", 9.0f, FontStyle.Regular);
            rtb.AppendText("\n\n" + TablaTextoConDGV(dgv, 0) + "\n\n");

            (new frmInforme(fechaId, rtb.Rtf)).Show();
        }


        public DateTime ObtenerFecha(string yyyy_MM_dd)
        {
            DateTime fecha;

            try
            {
                if (fechaCambiarOrden)
                {
                    fecha = new DateTime(
                        Convert.ToInt32(yyyy_MM_dd.Substring(6, 4)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(3, 2)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(0, 2))
                    );
                }
                else
                {
                    fecha = new DateTime(
                        Convert.ToInt32(yyyy_MM_dd.Substring(0, 4)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(5, 2)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(8, 2))
                    );
                }
            }
            catch    // dd_MM_yyyy
            {
                fechaCambiarOrden = !fechaCambiarOrden;
                if (fechaCambiarOrden)
                {
                    fecha = new DateTime(
                        Convert.ToInt32(yyyy_MM_dd.Substring(6, 4)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(3, 2)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(0, 2))
                    );
                }
                else
                {
                    fecha = new DateTime(
                        Convert.ToInt32(yyyy_MM_dd.Substring(0, 4)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(5, 2)),
                        Convert.ToInt32(yyyy_MM_dd.Substring(8, 2))
                    );
                }
            }

            return (fecha);
        }

        public int numAseguradora(string idajustador)
        {
            return( ((Convert.ToInt32(idajustador.Substring(1))) - 1) / 3 + 1);
        }

        public int mesDe(string yyyy_MM_dd)
        {
            int mes = 0;

            try
            {
                if (mesCambiarOrden)
                {
                    mes = Convert.ToInt32(yyyy_MM_dd.Substring(3, 2));
                }
                else
                {
                    mes = Convert.ToInt32(yyyy_MM_dd.Substring(5, 2));
                }
            }
            catch    // dd_MM_yyyy
            {
                mesCambiarOrden = !mesCambiarOrden;
                if (mesCambiarOrden)
                {
                    mes = Convert.ToInt32(yyyy_MM_dd.Substring(3, 2));
                }
                else
                {
                    mes = Convert.ToInt32(yyyy_MM_dd.Substring(5, 2));
                }
            }
            return ( mes );
        }

        public DataTable infoTabla(string titulo, List<infocapital> datos)
        {
            DataTable dt = new DataTable();
            dt.TableName = titulo;
            dt.Columns.Add("mes");
            dt.Columns.Add("capital");
            dt.Columns.Add("choques");
            dt.Columns.Add("costo");

            for (int i = 0; i < datos.Count; i++)
            {
                dt.Rows.Add(datos[i].mes, datos[i].capital.ToString("N2"), datos[i].choques, datos[i].costo.ToString("N2"));
            }

            return dt;
        }

        public DataTable infoTabla(string titulo, List<infochoque> datos)
        {
            DataTable dt = new DataTable();
            dt.TableName = titulo;
            dt.Columns.Add("mes");
            dt.Columns.Add("choques");
            dt.Columns.Add("costo");

            for (int i = 0; i < datos.Count; i++)
            {
                dt.Rows.Add(datos[i].mes, datos[i].choques, datos[i].costo.ToString("N2"));
            }

            return dt;
        }

        public string TablaTextoConDGV(DataGridView dgv, int columnaNoNull)
        {
            // Devuelve una tabla en un string: Cada columna tiene elementos del mismo ancho rellenados con espacios.

            string tablaFinal = "";

            if (dgv == null || dgv.Columns.Count == 0) return tablaFinal;    // Si se ha pasado un objeto vacio nada hace

            string separador = " | ";
            string separadorInicial = "| ";
            string separadorFinal = " |";
            string enter = "\n";
            string renglon = "";

            int numColumnas = dgv.Columns.Count;
            int numFilas = dgv.Rows.Count;
            int[] maxLongitud = new int[numColumnas];
            bool[] columnaNumerica = new bool[numColumnas];
            int valor;
            int anchoTabla = 0;

            // Deteccion de longitudes mayores de string por columna para agregar espacios
            for (int columna = 0; columna < numColumnas; columna++)
            {
                maxLongitud[columna] = dgv.Columns[columna].HeaderText.Length;    // Toma en cuenta el encabezado
                for (int fila = 0; fila < numFilas; fila++)
                {
                    // Deteccion de maxima longitud hasta aqui
                    //if (dgv[columnaNoNull, fila].Value == null ||  dgv[columna, fila].Value.ToString() == "") break;    // En dgv editable por usuario, el ultimo renglon es null
                    if (dgv[columnaNoNull, fila].Value == null || dgv[columna, fila].Value == null) break;    // En dgv editable por usuario, el ultimo renglon es null
                    valor = dgv[columna, fila].Value.ToString().Length;
                    if (maxLongitud[columna] < valor) maxLongitud[columna] = valor;
                }
                anchoTabla += maxLongitud[columna] + separador.Length;
            }
            anchoTabla++;    // El separador Inicial es de 2 "| " y el final también, " |", Ya se habían contado 3 para ellos.

            // Deteccion de columnas numericas para alinearlas a la derecha sumando espacios a la izquierda
            for (int columna = 0; columna < numColumnas; columna++)
            {
                try
                {
                    Convert.ToDouble(dgv[columna, 0].Value.ToString());
                    columnaNumerica[columna] = true;
                }
                catch
                {
                    columnaNumerica[columna] = false;
                }
            }

            // Creacion de tabla
            tablaFinal += Linea(anchoTabla) + enter;
            for (int fila = -1; fila < numFilas; fila++)
            {
                renglon = "";
                if (fila != -1 && dgv[columnaNoNull, fila].Value == null) continue;    // Salta renglon null. En dgv editable por usuario, el ultimo es null.
                else renglon += separadorInicial;

                for (int columna = 0; columna < numColumnas; columna++)
                {
                    if (fila == -1)    // Encabezado
                    {
                        renglon += dgv.Columns[columna].HeaderText + Espacios(maxLongitud[columna], dgv.Columns[columna].HeaderText.Length);
                        if (columna != numColumnas - 1) renglon += separador;
                        else renglon += separadorFinal;
                        continue;
                    }

                    //if (dgv[columna, fila].Value == null) continue;   // prueba

                    // Renglón común
                    if (columnaNumerica[columna]) renglon += Espacios(maxLongitud[columna], dgv[columna, fila].Value.ToString().Length) + dgv[columna, fila].Value.ToString();
                    else renglon += dgv[columna, fila].Value.ToString() + Espacios(maxLongitud[columna], dgv[columna, fila].Value.ToString().Length);
                    if (columna != numColumnas - 1) renglon += separador;
                    else renglon += separadorFinal;
                }
                tablaFinal += renglon + enter;
                if (fila == -1) tablaFinal += Linea(anchoTabla) + enter;
            }
            tablaFinal += Linea(anchoTabla) + enter;

            return tablaFinal;
        }

        public string Espacios(int max, int longitudYaCubierta)
        {
            string espa = "";
            for (int i = longitudYaCubierta; i < max; i++)
            {
                espa += " ";
            }
            return espa;
        }

        public string Linea(int longitud)
        {
            string linea = "";
            for (int i = 0; i < longitud; i++)
            {
                linea += "-";
            }
            return linea;
        }

        private void chart_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            sfd.FilterIndex = 2;
            sfd.Title = "Guardar gráfica como imagen";
            sfd.FileName = "Grafica_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            sfd.InitialDirectory = Application.StartupPath;
            sfd.DefaultExt = ".bmp";

            if (DialogResult.Yes == sfd.ShowDialog())
            {
                if (sfd.FileName == "")
                {
                    sfd.FileName = "Grafica_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                }

                switch (sfd.FilterIndex)
                {
                    case 1:
                        chart.SaveImage(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        chart.SaveImage(sfd.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        chart.SaveImage(sfd.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
            }
        }
    }

    public class Series    // Puntos a graficar
    {
        public string mes { get; set; }
        public double Serie1 { get; set; }
        public double Serie2 { get; set; }
    }

    public class infocapital
    {
        public string mes { get; set; }
        public double capital { get; set; }
        public double choques { get; set; }
        public double costo { get; set; }

        public infocapital(string mes1, double choques1, double costo1, double capital1)
        {
            mes = mes1;
            choques = choques1;
            costo = costo1;
            capital = capital1;
        }
    }

    public class infochoque
    {
        public string mes { get; set; }
        public double costo { get; set; }
        public double choques { get; set; }

        public infochoque(string mes1, double choques1, double costo1)
        {
            mes = mes1;
            choques = choques1;
            costo = costo1;
        }
    }

}
