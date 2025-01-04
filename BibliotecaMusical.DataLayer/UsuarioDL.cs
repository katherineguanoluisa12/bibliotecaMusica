using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using BibliotecaMusical.EntityLayer;
using NLog.Internal;


namespace BibliotecaMusical.DataLayer
{
    public class UsuarioDL
    {
        private string connectionString;

        public UsuarioDL()
        {
            // Obtén la cadena de conexión desde el archivo Web.config
            connectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ConnectionString;
        }

        public List<Usuario> Lista()
        {
            var usuarios = new List<Usuario>();
            string query = "EXEC sp_VerUsuarios";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Contraseña = reader["Contraseña"].ToString(),
                            Rol = reader["Rol"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                        };
                        usuarios.Add(usuario);
                    }
                }
            }
            return usuarios;
        }

        public Usuario Obtener(int id)
        {
            string query = "EXEC sp_VerUsuarios @ID";
            Usuario usuario = null;

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            ID = Convert.ToInt32(reader["ID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apellido = reader["Apellido"].ToString(),
                            Email = reader["Email"].ToString(),
                            Contraseña = reader["Contraseña"].ToString(),
                            Rol = reader["Rol"].ToString(),
                            FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"])
                        };
                    }
                }
            }
            return usuario;
        }

        public bool Crear(Usuario usuario)
        {
            string query = "EXEC sp_AgregarUsuario @Nombre, @Apellido, @Email, @Contraseña, @Rol, @FechaRegistro";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Rol", usuario.Rol);
                command.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Editar(Usuario usuario)
        {
            string query = "EXEC sp_ModificarUsuario @ID, @Nombre, @Apellido, @Email, @Contraseña, @Rol, @FechaRegistro";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", usuario.ID);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("@Rol", usuario.Rol);
                command.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Eliminar(int id)
        {
            string query = "EXEC sp_EliminarUsuario @ID";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", id);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}
