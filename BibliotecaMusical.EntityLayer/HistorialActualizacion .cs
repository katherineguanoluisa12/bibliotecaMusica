using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMusical.EntityLayer
{
    public class HistorialActualizacion
    {
        public int ID { get; set; }
        public int Administrador_ID { get; set; }
        public string Accion { get; set; }
        public string Detalles { get; set; }
        public DateTime FechaHora { get; set; }
    }
}
