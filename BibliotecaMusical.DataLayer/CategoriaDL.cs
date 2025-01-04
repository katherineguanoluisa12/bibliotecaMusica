using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class CategoriaDL
    {
        private string connectionString = "your_connection_string_here";

        // Método para obtener todas las categorías
        public List<Categoria> ObtenerTodos()
        {
            var lista = new List<Categoria>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Categorias", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Categoria
                    {
                        Categoria_ID = Convert.ToInt32(reader["Categoria_ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    });
                }
            }

            return lista;
        }

        // Método para obtener una categoría por su ID
        public Categoria Obtener(int categoriaID)
        {
            Categoria categoria = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Categorias WHERE Categoria_ID = @Categoria_ID", connection);
                command.Parameters.AddWithValue("@Categoria_ID", categoriaID);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    categoria = new Categoria
                    {
                        Categoria_ID = Convert.ToInt32(reader["Categoria_ID"]),
                        Nombre = reader["Nombre"].ToString(),
                        Descripcion = reader["Descripcion"].ToString()
                    };
                }
            }

            return categoria;
        }

        // Método para crear una nueva categoría
        public bool Crear(Categoria categoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Categorias (Nombre, Descripcion) VALUES (@Nombre, @Descripcion)", connection);

                command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para eliminar una categoría
        public bool Eliminar(int categoriaID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Categorias WHERE Categoria_ID = @Categoria_ID", connection);
                command.Parameters.AddWithValue("@Categoria_ID", categoriaID);
                return command.ExecuteNonQuery() > 0;
            }
        }

        // Método para editar una categoría existente
        public bool Editar(Categoria categoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Categorias SET Nombre = @Nombre, Descripcion = @Descripcion WHERE Categoria_ID = @Categoria_ID", connection);

                command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);
                command.Parameters.AddWithValue("@Categoria_ID", categoria.Categoria_ID);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
