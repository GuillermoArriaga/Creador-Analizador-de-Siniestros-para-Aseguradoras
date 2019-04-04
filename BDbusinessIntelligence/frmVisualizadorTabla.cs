using System;
using System.Data;
using System.Windows.Forms;

namespace BDcreadorCSVoleDB
{
    public partial class frmVisualizadorTabla : Form
    {
        public frmVisualizadorTabla(string nombreTabla)
        {
            InitializeComponent();

            tbTitulo.Text = nombreTabla;
            dgvDatos.DataSource = Comun.baseDatos.Tables[nombreTabla];
            AcceptButton = btIr;

            cbTabla.Items.Clear();
            for (int i = 0; i < Comun.baseDatos.Tables.Count; i++)
            {
                cbTabla.Items.Add(Comun.baseDatos.Tables[i].TableName);
            }
            cbTabla.Text = nombreTabla;
        }

        public frmVisualizadorTabla(string nombreTabla, DataTable dtabla)
        {
            InitializeComponent();

            tbTitulo.Text = nombreTabla;
            dgvDatos.DataSource = dtabla;
            AcceptButton = btIr;

            cbTabla.Visible = false;
            groupBox1.Visible = false;

            groupBox2.Location = groupBox1.Location;
            groupBox2.Size = new System.Drawing.Size(groupBox2.Size.Width, groupBox2.Size.Height + groupBox1.Size.Height + 3);
            groupBox2.Text = "";
        }

        private void cbTabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbTitulo.Text = cbTabla.SelectedItem.ToString();
            dgvDatos.DataSource = Comun.baseDatos.Tables[tbTitulo.Text];
        }

        private void btCSV_Click(object sender, EventArgs e)
        {
            string archivo = Application.StartupPath + "\\" + tbTitulo.Text + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
            DGVaCSV(dgvDatos, archivo);
            System.Diagnostics.Process.Start(Application.StartupPath);
            System.Diagnostics.Process.Start(archivo);
        }

        public void DGVaCSV(DataGridView dgv, string archivo)
        {
            if (dgv.Rows.Count > 0)
            {
                string valor = "";
                DataGridViewRow fila = new DataGridViewRow();
                //StreamWriter escritor = new StreamWriter(archivo, false, System.Text.Encoding.GetEncoding(1252));
                System.IO.StreamWriter escritor = new System.IO.StreamWriter(archivo, false, System.Text.Encoding.UTF8);
                /*
                 Para que el escritor pase bien las vocales acentuadas: 
                    Al abrir el StreamWriter, indicar el parámetro opcional: Juego de caracteres. 
                    El juego ANSI en un Windows en español es el 1252
 
                StreamWriter escritor = new StreamWriter(archivo, false, System.Text.Encoding.GetEncoding(1252));
                
                    O bien:
                StreamWriter escritor = new StreamWriter(archivo, false, System.Text.Encoding.UTF8);
                 */


                // Escritura de encabezados en csv
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        escritor.Write(",");
                    }
                    escritor.Write(dgv.Columns[i].HeaderText);
                }

                escritor.WriteLine();

                // Escritura fila por fila en csv
                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                    if (j > 0)
                    {
                        escritor.WriteLine();
                    }

                    fila = dgv.Rows[j];

                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            escritor.Write(",");
                        }

                        valor = fila.Cells[i].Value.ToString();
                        // Remplaza comas por espacios
                        valor = valor.Replace(',', ' ');
                        // Remplaza enters en celda con espacios
                        valor = valor.Replace(Environment.NewLine, " ");

                        escritor.Write(valor);
                    }
                }
                escritor.Close();
            }
        }

        private void btIr_Click(object sender, EventArgs e)
        {
            dgvDatos.Sort(dgvDatos.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
            try
            {
                dgvDatos.CurrentCell = dgvDatos[0, Convert.ToInt32(tbNumId.Text) - 1];
            }
            catch
            {
                tbNumId.Text = "1";
                dgvDatos.CurrentCell = dgvDatos[0, 0];
            }
            tbNumId.SelectAll();
            tbNumId.Focus();
        }

        private void frmVisualizadorTabla_Load(object sender, EventArgs e)
        {
            dgvDatos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            try
            {
                if (dgvDatos.Columns[2].Name == "fecha")
                {
                    dgvDatos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }

                if (dgvDatos.Columns[4].Name == "idaseguradora")
                {
                    dgvDatos.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                }
            }
            catch { }
            tbNumId.SelectAll();
            tbNumId.Focus();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string nombre = dgvDatos.Columns[dgvDatos.CurrentCell.ColumnIndex].Name;
            if( nombre.Substring(0, 2) == "id" )    // formacion de nombre de tabla por su idpropio
            {
                nombre = nombre.Substring(2);    // remueve palabra "id"
                if (nombre.Substring(nombre.Length - 1, 1) == "x" || nombre.Substring(nombre.Length - 1, 1) == "y")
                {
                    nombre = nombre.Substring(0, nombre.Length - 1);
                }
                if (nombre.Substring(nombre.Length - 1, 1) == "r" || nombre.Substring(nombre.Length - 1, 1) == "l")
                {
                    nombre = nombre + "e";    // lugar e s, ajustador e s, automvil e s
                }
                nombre = nombre + "s";

                int numId = Convert.ToInt32(dgvDatos.CurrentCell.Value.ToString().Substring(1)) - 1;

                dgvRegistro.Columns.Clear();

                for (int i = 0; i < Comun.baseDatos.Tables[nombre].Columns.Count; i++)
                {
                    dgvRegistro.Columns.Add(Comun.baseDatos.Tables[nombre].Columns[i].ColumnName, Comun.baseDatos.Tables[nombre].Columns[i].ColumnName);
                }
                dgvRegistro.Rows.Add();
                for (int i = 0; i < Comun.baseDatos.Tables[nombre].Columns.Count; i++)
                {
                    dgvRegistro[i, 0].Value = Comun.baseDatos.Tables[nombre].Rows[numId][i].ToString();
                }
            }
        }
    }
}
