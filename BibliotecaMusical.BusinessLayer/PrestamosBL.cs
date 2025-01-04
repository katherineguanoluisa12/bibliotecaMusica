using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;
using System;
using System.Collections.Generic;

namespace BibliotecaMusical.BusinessLayer
{
    public class PrestamosBL
    {
        private readonly PrestamosDL prestamosDL = new PrestamosDL();

        // Obtener todos los préstamos
        public List<Prestamo> ObtenerTodos()
        {
            try
            {
                return prestamosDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Obtener un préstamo por ID
        public Prestamo Obtener(int prestamoID)
        {
            try
            {
                return prestamosDL.Obtener(prestamoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Crear un nuevo préstamo
        public bool Crear(Prestamo prestamo)
        {
            try
            {
                return prestamosDL.Crear(prestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Modificar un préstamo existente
        public bool Modificar(Prestamo prestamo)
        {
            try
            {
                return prestamosDL.Editar(prestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Eliminar un préstamo
        public bool Eliminar(int prestamoID)
        {
            try
            {
                return prestamosDL.Eliminar(prestamoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
