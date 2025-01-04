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
        private readonly MaterialDL materialesDL = new MaterialDL();

        public List<Material> ObtenerTodo()
        {
            try
            {
                return materialesDL.Obtener();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Material Obtener(int materialId)
        {
            try
            {
                return materialesDL.Obtener(materialId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(Material material)
        {
            try
            {
                return materialesDL.Crear(material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(Material material)
        {
            try
            {
                return materialesDL.Modificar(material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int materialId)
        {
            try
            {
                return materialesDL.Eliminar(materialId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
