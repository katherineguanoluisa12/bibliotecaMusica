using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class MaterialDL
    {
        private string connectionString;

        public MaterialDL()
        {
            // Obtén la cadena de conexión desde el archivo Web.config
            connectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ConnectionString;
        }

        // Obtener lista de materiales
        public List<Material> Lista(string tipo = null)
        {
            var materiales = new List<Material>();
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_ConsultarMateriales", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Tipo", (object)tipo ?? DBNull.Value);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var material = new Material
                    {
                        MaterialID = Convert.ToInt32(reader["MaterialID"]),
                        Titulo = reader["Titulo"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Ubicacion = reader["Ubicacion"].ToString(),
                        Autor = reader["Autor"].ToString(),
                        FechaPublicacion = Convert.ToDateTime(reader["FechaPublicacion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaAgregado = Convert.ToDateTime(reader["FechaAgregado"]),
                        AgregadoPor = Convert.ToInt32(reader["AgregadoPor"]),
                    };
                    materiales.Add(material);
                }
            }
            return materiales;
        }

        // Obtener un material por ID
        public Material Obtener(int id)
        {
            Material material = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_ConsultarMateriales", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaterialID", id);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    material = new Material
                    {
                        MaterialID = Convert.ToInt32(reader["MaterialID"]),
                        Titulo = reader["Titulo"].ToString(),
                        Tipo = reader["Tipo"].ToString(),
                        Ubicacion = reader["Ubicacion"].ToString(),
                        Autor = reader["Autor"].ToString(),
                        FechaPublicacion = Convert.ToDateTime(reader["FechaPublicacion"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        FechaAgregado = Convert.ToDateTime(reader["FechaAgregado"]),
                        AgregadoPor = Convert.ToInt32(reader["AgregadoPor"]),
                    };
                }
            }
            return material;
        }

        // Crear un material
        public bool Crear(Material material)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_InsertarMaterial", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                // Agregar los parámetros para insertar un nuevo material
                command.Parameters.AddWithValue("@Titulo", material.Titulo);
                command.Parameters.AddWithValue("@Tipo", material.Tipo);
                command.Parameters.AddWithValue("@Ubicacion", material.Ubicacion);
                command.Parameters.AddWithValue("@Autor", material.Autor);
                command.Parameters.AddWithValue("@FechaPublicacion", material.FechaPublicacion);
                command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                command.Parameters.AddWithValue("@AgregadoPor", material.AgregadoPor);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Editar un material
        public bool Editar(Material material)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_ActualizarMaterial", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaterialID", material.MaterialID);
                command.Parameters.AddWithValue("@Titulo", material.Titulo);
                command.Parameters.AddWithValue("@Tipo", material.Tipo);
                command.Parameters.AddWithValue("@Ubicacion", material.Ubicacion);
                command.Parameters.AddWithValue("@Autor", material.Autor);
                command.Parameters.AddWithValue("@FechaPublicacion", material.FechaPublicacion);
                command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                command.Parameters.AddWithValue("@AgregadoPor", material.AgregadoPor);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Eliminar un material
        public bool Eliminar(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("sp_EliminarMaterial", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MaterialID", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
