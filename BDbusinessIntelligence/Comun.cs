using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDcreadorCSVoleDB
{
    public static class Comun
    {
        public static int idchar = 6;
        public static string separador = " : ";
        public static System.Data.DataSet baseDatos;

        public static string idCombo(string itemCombobox)
        {
            return (itemCombobox.Substring(itemCombobox.Length - 6));
        }
    }
}
