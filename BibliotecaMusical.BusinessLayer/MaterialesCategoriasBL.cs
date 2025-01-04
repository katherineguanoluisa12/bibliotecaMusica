using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;
using System;
using System.Collections.Generic;

namespace BibliotecaMusical.BusinessLayer
{
    public class MaterialesCategoriasBL
    {
        private readonly MaterialesCategoriasDL materialesCategoriasDL = new MaterialesCategoriasDL();

        // Método para crear una relación entre material y categoría
        public bool Crear(int materialID, int categoriaID)
        {
            try
            {
                return materialesCategoriasDL.Crear(materialID, categoriaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para eliminar una relación entre material y categoría
        public bool Eliminar(int materialID, int categoriaID)
        {
            try
            {
                return materialesCategoriasDL.Eliminar(materialID, categoriaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para obtener las categorías de un material
        public List<int> ObtenerCategoriasPorMaterial(int materialID)
        {
            try
            {
                return materialesCategoriasDL.ObtenerCategoriasPorMaterial(materialID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para obtener los materiales de una categoría
        public List<int> ObtenerMaterialesPorCategoria(int categoriaID)
        {
            try
            {
                return materialesCategoriasDL.ObtenerMaterialesPorCategoria(categoriaID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
