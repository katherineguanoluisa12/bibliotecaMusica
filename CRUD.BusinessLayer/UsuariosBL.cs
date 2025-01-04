using System;
using System.Collections.Generic;
using CrudDataLayer;
using CRUD.EnntyLayer;


namespace CRUD.BusinessLayer
{
    public class UsuarioBL
    {
        UsuariosDL usuarioDL = new UsuariosDL();  // Asumiendo que tienes un UsuarioDL para manejar la capa de datos

        // Obtener lista de usuarios
        public List<Usuarios> Lista()
        {
            try
            {
                return usuarioDL.Lista();  // Devuelve la lista de usuarios desde la capa de datos
            }
            catch (Exception ex)
            {
                throw ex;  // Lanzar cualquier excepción capturada
            }
        }

        // Obtener un usuario específico por su ID
        public Usuarios Obtener(int ID)
        {
            try
            {
                return usuarioDL.Obtener(ID);  // Obtener un usuario por ID desde la capa de datos
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Crear un nuevo usuario
        public bool Crear(Usuarios entidad)
        {
            try
            {
                if (string.IsNullOrEmpty(entidad.Nombre))  // Validación de campos obligatorios
                    throw new OperationCanceledException("El nombre no puede ser vacío");

                if (string.IsNullOrEmpty(entidad.Email))  // Validación para el email
                    throw new OperationCanceledException("El email no puede ser vacío");

                return usuarioDL.Crear(entidad);  // Crear el usuario en la capa de datos
            }
            catch (Exception ex)
            {
                throw ex;  // Lanzar la excepción si ocurre algún error
            }
        }

        // Editar un usuario existente
        public bool Editar(Usuarios entidad)
        {
            try
            {
                // Buscar el usuario para verificar si existe
                var encontrado = usuarioDL.Obtener(entidad.ID);

                if (encontrado.IdUsuario == 0)
                    throw new OperationCanceledException("No existe el usuario");

                return usuarioDL.Editar(entidad);  // Editar el usuario en la capa de datos
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Eliminar un usuario por su ID
        public bool Eliminar(int idUsuario)
        {
            try
            {
                var encontrado = usuarioDL.Obtener(ID);
                if (encontrado.IdUsuario == 0)
                    throw new OperationCanceledException("No existe el usuario");

                return usuarioDL.Eliminar(ID);  // Eliminar el usuario desde la capa de datos
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
