using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class MaterialesCategoriasDL
    {
        private string connectionString = "your_connection_string_here";

        public bool Crear(int materialID, int categoriaID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO MaterialesCategorias (Material_ID, Categoria_ID) VALUES (@Material_ID, @Categoria_ID)", connection);

                command.Parameters.AddWithValue("@Material_ID", materialID);
                command.Parameters.AddWithValue("@Categoria_ID", categoriaID);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int materialID, int categoriaID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM MaterialesCategorias WHERE Material_ID = @Material_ID AND Categoria_ID = @Categoria_ID", connection);

                command.Parameters.AddWithValue("@Material_ID", materialID);
                command.Parameters.AddWithValue("@Categoria_ID", categoriaID);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public List<int> ObtenerCategoriasPorMaterial(int materialID)
        {
            var categorias = new List<int>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Categoria_ID FROM MaterialesCategorias WHERE Material_ID = @Material_ID", connection);
                command.Parameters.AddWithValue("@Material_ID", materialID);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    categorias.Add(Convert.ToInt32(reader["Categoria_ID"]));
                }
            }

            return categorias;
        }

        public List<int> ObtenerMaterialesPorCategoria(int categoriaID)
        {
            var materiales = new List<int>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT Material_ID FROM MaterialesCategorias WHERE Categoria_ID = @Categoria_ID", connection);
                command.Parameters.AddWithValue("@Categoria_ID", categoriaID);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    materiales.Add(Convert.ToInt32(reader["Material_ID"]));
                }
            }

            return materiales;
        }
    }
}
