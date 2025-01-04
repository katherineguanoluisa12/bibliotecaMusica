using CRUD.EnntyLayer;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CrudDataLayer
{
    public class UsuariosDL
    {
        // Lista de usuarios
        private List<Usuarios> lista = new List<Usuarios>();

        // Método para obtener la lista de usuarios desde la base de datos
        public List<Usuarios> ObtenerUsuarios()
        {
            lista.Clear();
            string connectionString = Conexion.Cadena;

            using (SqlConnection oConexion = new SqlConnection(connectionString))
            {
                oConexion.Open();
                SqlCommand comando = new SqlCommand("sp_VerUsuarios", oConexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios usuario = new Usuarios
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                        Email = reader.GetString(reader.GetOrdinal("Email")),
                        Rol = reader.GetString(reader.GetOrdinal("Rol")),
                        FechaRegistro = reader.GetDateTime(reader.GetOrdinal("FechaRegistro"))
                    };
                    lista.Add(usuario);
                }
                reader.Close();
            }

            return lista;
        }

        // Método para crear un nuevo usuario
        public bool CrearUsuario(Usuarios nuevoUsuario)
        {
            string connectionString = Conexion.Cadena;

            using (SqlConnection oConexion = new SqlConnection(connectionString))
            {
                oConexion.Open();
                SqlCommand comando = new SqlCommand("sp_AgregarUsuario", oConexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@Nombre", nuevoUsuario.Nombre);
                comando.Parameters.AddWithValue("@Apellido", nuevoUsuario.Apellido);
                comando.Parameters.AddWithValue("@Email", nuevoUsuario.Email);
                comando.Parameters.AddWithValue("@Contraseña", nuevoUsuario.Contraseña); // Asumiendo que la contraseña ya está cifrada
                comando.Parameters.AddWithValue("@Rol", nuevoUsuario.Rol);
                comando.Parameters.AddWithValue("@FechaRegistro", nuevoUsuario.FechaRegistro);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        // Método para eliminar un usuario
        public bool EliminarUsuario(int id)
        {
            string connectionString = Conexion.Cadena;

            using (SqlConnection oConexion = new SqlConnection(connectionString))
            {
                oConexion.Open();
                SqlCommand comando = new SqlCommand("sp_EliminarUsuario", oConexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }

        // Método para modificar un usuario
        public bool ModificarUsuario(Usuarios usuario)
        {
            string connectionString = Conexion.Cadena;

            using (SqlConnection oConexion = new SqlConnection(connectionString))
            {
                oConexion.Open();
                SqlCommand comando = new SqlCommand("sp_ModificarUsuario", oConexion);
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@ID", usuario.ID);
                comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                comando.Parameters.AddWithValue("@Email", usuario.Email);
                comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña); // Asumiendo que la contraseña ya está cifrada
                comando.Parameters.AddWithValue("@Rol", usuario.Rol);
                comando.Parameters.AddWithValue("@FechaRegistro", usuario.FechaRegistro);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
    }
}
