using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;
using System;
using System.Collections.Generic;

namespace BibliotecaMusical.BusinessLayer
{
    public class CategoriasBL
    {
        private readonly CategoriaDL categoriasDL = new CategoriaDL();

        // Método para obtener todas las categorías
        public List<Categoria> ObtenerTodos()
        {
            try
            {
                return categoriasDL.ObtenerTodos(); // Cambié categoriaDL por categoriasDL
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para obtener una categoría por ID
        public Categoria Obtener(int categoriaId)
        {
            try
            {
                return categoriasDL.Obtener(categoriaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para crear una nueva categoría
        public bool Crear(Categoria categoria)
        {
            try
            {
                return categoriasDL.Crear(categoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para modificar una categoría
        public bool Modificar(Categoria categoria)
        {
            try
            {
                return categoriasDL.Editar(categoria); // Cambié Modificar por Editar según la implementación
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Método para eliminar una categoría
        public bool Eliminar(int categoriaId)
        {
            try
            {
                return categoriasDL.Eliminar(categoriaId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
