using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.EnntyLayer
{
    public class Materiales
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Autor { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string URL { get; set; }
        public string Estado { get; set; }
    }
}
