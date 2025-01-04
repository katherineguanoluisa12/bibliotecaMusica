using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMusical.EntityLayer
{
    public class Prestamo
    {
        public int Prestamo_ID { get; set; }
        public int Usuario_ID { get; set; }
        public int Material_ID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public string Estado { get; set; }
    }
}
