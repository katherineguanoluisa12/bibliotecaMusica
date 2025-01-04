using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace BibliotecaMusical.DataLayer
{
    public class MaterialDL
    {
        private readonly string connectionString = "tu_conexion_a_base_de_datos";

        public List<Material> Obtener()
        {
            List<Material> materiales = new List<Material>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Materiales";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        materiales.Add(new Material
                        {
                            Material_ID = (int)reader["Material_ID"],
                            Titulo = reader["Titulo"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            FechaPublicacion = (DateTime)reader["FechaPublicacion"],
                            Descripcion = reader["Descripcion"].ToString(),
                            Ubicacion = reader["Ubicacion"].ToString(),
                            URL = reader["URL"].ToString(),
                            Estado = reader["Estado"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return materiales;
        }

        public Material Obtener(int materialId)
        {
            Material material = null;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Materiales WHERE Material_ID = @Material_ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Material_ID", materialId);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        material = new Material
                        {
                            Material_ID = (int)reader["Material_ID"],
                            Titulo = reader["Titulo"].ToString(),
                            Tipo = reader["Tipo"].ToString(),
                            Autor = reader["Autor"].ToString(),
                            FechaPublicacion = (DateTime)reader["FechaPublicacion"],
                            Descripcion = reader["Descripcion"].ToString(),
                            Ubicacion = reader["Ubicacion"].ToString(),
                            URL = reader["URL"].ToString(),
                            Estado = reader["Estado"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return material;
        }

        public bool Crear(Material material)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Materiales (Titulo, Tipo, Autor, FechaPublicacion, Descripcion, Ubicacion, URL, Estado) VALUES (@Titulo, @Tipo, @Autor, @FechaPublicacion, @Descripcion, @Ubicacion, @URL, @Estado)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Titulo", material.Titulo);
                    command.Parameters.AddWithValue("@Tipo", material.Tipo);
                    command.Parameters.AddWithValue("@Autor", material.Autor);
                    command.Parameters.AddWithValue("@FechaPublicacion", material.FechaPublicacion);
                    command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", material.Ubicacion);
                    command.Parameters.AddWithValue("@URL", material.URL);
                    command.Parameters.AddWithValue("@Estado", material.Estado);
                    connection.Open();

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Modificar(Material material)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Materiales SET Titulo = @Titulo, Tipo = @Tipo, Autor = @Autor, FechaPublicacion = @FechaPublicacion, Descripcion = @Descripcion, Ubicacion = @Ubicacion, URL = @URL, Estado = @Estado WHERE Material_ID = @Material_ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Titulo", material.Titulo);
                    command.Parameters.AddWithValue("@Tipo", material.Tipo);
                    command.Parameters.AddWithValue("@Autor", material.Autor);
                    command.Parameters.AddWithValue("@FechaPublicacion", material.FechaPublicacion);
                    command.Parameters.AddWithValue("@Descripcion", material.Descripcion);
                    command.Parameters.AddWithValue("@Ubicacion", material.Ubicacion);
                    command.Parameters.AddWithValue("@URL", material.URL);
                    command.Parameters.AddWithValue("@Estado", material.Estado);
                    command.Parameters.AddWithValue("@Material_ID", material.Material_ID);
                    connection.Open();

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int materialId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Materiales WHERE Material_ID = @Material_ID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Material_ID", materialId);
                    connection.Open();

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
