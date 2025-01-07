using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;

namespace BibliotecaMusical.BusinessLayer
{
    public class MaterialesBL
    {
        private readonly MaterialDL _materialDL = new MaterialDL();

        // Obtener lista de materiales
        public List<Material> Lista(string tipo = null)
        {
            return _materialDL.Lista(tipo);
        }

        // Obtener un material por ID
        public Material Obtener(int id)
        {
            return _materialDL.Obtener(id);
        }

        // Crear un material
        public bool Crear(Material material)
        {
            if (string.IsNullOrEmpty(material.Titulo) || string.IsNullOrEmpty(material.Tipo))
            {
                throw new ArgumentException("El título y el tipo son obligatorios.");
            }

            return _materialDL.Crear(material);
        }

        // Editar un material
        public bool Editar(Material material)
        {
            if (material.MaterialID == 0)
            {
                throw new ArgumentException("El ID del material no puede ser 0.");
            }

            return _materialDL.Editar(material);
        }

        // Eliminar un material
        public bool Eliminar(int id)
        {
            return _materialDL.Eliminar(id);
        }
    }
}

