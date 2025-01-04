using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudDataLayer
{
    public class Conexion
    {
        public static string Cadena = ConfigurationManager.ConnectionStrings["conexionBddBiblioteca_musical"].ToString();

    }
}
