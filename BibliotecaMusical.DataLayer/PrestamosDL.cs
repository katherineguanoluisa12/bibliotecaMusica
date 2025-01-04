using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class PrestamosDL

    {
        private string connectionString;

        public PrestamosDL()
        {
            // Obtén la cadena de conexión desde el archivo Web.config
            connectionString = ConfigurationManager.ConnectionStrings["CRUDConnectionString"].ConnectionString;
        }

        public List<Prestamo> Lista()
        {
            var lista = new List<Prestamo>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Prestamos", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Prestamo
                    {
                        Prestamo_ID = Convert.ToInt32(reader["Prestamo_ID"]),
                        Usuario_ID = Convert.ToInt32(reader["Usuario_ID"]),
                        Material_ID = Convert.ToInt32(reader["Material_ID"]),
                        FechaPrestamo = Convert.ToDateTime(reader["FechaPrestamo"]),
                        FechaDevolucion = reader["FechaDevolucion"] as DateTime?,
                        Estado = reader["Estado"].ToString()
                    });
                }
            }

            return lista;
        }

        public Prestamo Obtener(int prestamoID)
        {
            Prestamo prestamo = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Prestamos WHERE Prestamo_ID = @Prestamo_ID", connection);
                command.Parameters.AddWithValue("@Prestamo_ID", prestamoID);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    prestamo = new Prestamo
                    {
                        Prestamo_ID = Convert.ToInt32(reader["Prestamo_ID"]),
                        Usuario_ID = Convert.ToInt32(reader["Usuario_ID"]),
                        Material_ID = Convert.ToInt32(reader["Material_ID"]),
                        FechaPrestamo = Convert.ToDateTime(reader["FechaPrestamo"]),
                        FechaDevolucion = reader["FechaDevolucion"] as DateTime?,
                        Estado = reader["Estado"].ToString()
                    };
                }
            }

            return prestamo;
        }

        public bool Crear(Prestamo prestamo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Prestamos (Usuario_ID, Material_ID, FechaPrestamo, FechaDevolucion, Estado) VALUES (@Usuario_ID, @Material_ID, @FechaPrestamo, @FechaDevolucion, @Estado)", connection);

                command.Parameters.AddWithValue("@Usuario_ID", prestamo.Usuario_ID);
                command.Parameters.AddWithValue("@Material_ID", prestamo.Material_ID);
                command.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                command.Parameters.AddWithValue("@FechaDevolucion", (object)prestamo.FechaDevolucion ?? DBNull.Value);
                command.Parameters.AddWithValue("@Estado", prestamo.Estado);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Eliminar(int prestamoID)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Prestamos WHERE Prestamo_ID = @Prestamo_ID", connection);
                command.Parameters.AddWithValue("@Prestamo_ID", prestamoID);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool Editar(Prestamo prestamo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Prestamos SET Usuario_ID = @Usuario_ID, Material_ID = @Material_ID, FechaPrestamo = @FechaPrestamo, FechaDevolucion = @FechaDevolucion, Estado = @Estado WHERE Prestamo_ID = @Prestamo_ID", connection);

                command.Parameters.AddWithValue("@Usuario_ID", prestamo.Usuario_ID);
                command.Parameters.AddWithValue("@Material_ID", prestamo.Material_ID);
                command.Parameters.AddWithValue("@FechaPrestamo", prestamo.FechaPrestamo);
                command.Parameters.AddWithValue("@FechaDevolucion", (object)prestamo.FechaDevolucion ?? DBNull.Value);
                command.Parameters.AddWithValue("@Estado", prestamo.Estado);
                command.Parameters.AddWithValue("@Prestamo_ID", prestamo.Prestamo_ID);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
