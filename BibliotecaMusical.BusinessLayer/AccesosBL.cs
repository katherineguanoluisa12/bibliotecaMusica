using BibliotecaMusical.EntityLayer;
using BibliotecaMusical.DataLayer;
using System;
using System.Collections.Generic;

namespace BibliotecaMusical.BusinessLayer
{
    public class AccesosBL
    {
        private readonly AccesosDL accesosDL = new AccesosDL();

        // Obtener todos los registros de accesos
        public List<Acceso> ObtenerTodos()
        {
            try
            {
                return accesosDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Obtener un acceso específico por su ID
        public Acceso Obtener(int accesoID)
        {
            try
            {
                return accesosDL.Obtener(accesoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Crear un nuevo acceso
        public bool Crear(Acceso acceso)
        {
            try
            {
                return accesosDL.Crear(acceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
