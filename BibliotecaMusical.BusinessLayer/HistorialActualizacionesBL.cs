using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;
using System;
using System.Collections.Generic;

namespace BibliotecaMusical.BusinessLayer
{
    public class HistorialActualizacionesBL
    {
        private readonly HistorialActualizacionesDL historialActualizacionesDL = new HistorialActualizacionesDL();

        // Obtener todos los registros del historial
        public List<HistorialActualizacion> ObtenerTodos()
        {
            try
            {
                return historialActualizacionesDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Obtener un historial por su ID
        public HistorialActualizacion Obtener(int id)
        {
            try
            {
                return historialActualizacionesDL.Obtener(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Crear un nuevo registro de historial
        public bool Crear(HistorialActualizacion historial)
        {
            try
            {
                return historialActualizacionesDL.Crear(historial);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
