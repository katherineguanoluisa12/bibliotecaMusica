using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaMusical.EntityLayer
{
    public class Material
    {
        public int MaterialID { get; set; }
        public string Titulo { get; set; }
        public string Tipo { get; set; }
        public string Ubicacion { get; set; }
        public string Autor { get; set; }

        public DateTime FechaPublicacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAgregado { get; set; }
        public int AgregadoPor { get; set; } // ID del usuario que agrega el material
    }
}
