using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using BibliotecaMusical.EntityLayer;

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

        // Método para listar usuarios
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

        // Método para obtener un usuario específico por ID
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

        // Método para crear un nuevo usuario
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

        // Método para editar un usuario existente
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

        // Método para eliminar un usuario
        public bool Eliminar(int id)
        {
            string query = "EXEC sp_EliminarUsuario @Usuario_ID";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Usuario_ID", id);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (SqlException ex)
            {
                // Manejo del error para identificar problemas específicos
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return false;
            }
        }

        // Método no implementado (por si se requiere en el futuro)
        public bool Guardar(int id)
        {
            throw new NotImplementedException();
        }
        public Usuario ClasificarUsuario(string email, string contraseña)
        {
            Usuario usuario = null;

            string query = "EXEC sp_ClasificarUsuario @Email, @Contraseña";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Contraseña", contraseña);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                ID = reader["ID"] != DBNull.Value ? Convert.ToInt32(reader["ID"]) : 0,
                                Nombre = reader["Nombre"]?.ToString(),
                                Apellido = reader["Apellido"]?.ToString(),
                                Rol = reader["Rol"]?.ToString()
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Mostrar el error detallado de SQL
                Console.WriteLine($"Error SQL: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Mostrar cualquier otro error
                Console.WriteLine($"Error general: {ex.Message}");
            }

            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado o credenciales inválidas.");
            }

            return usuario; // Retorna el usuario o null
        }
    }
}


