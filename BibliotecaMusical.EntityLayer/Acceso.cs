using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMusical.EntityLayer
{
    public class Acceso
    {
        public int Acceso_ID { get; set; }
        public int Usuario_ID { get; set; }
        public int Material_ID { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
