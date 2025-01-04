using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class HistorialActualizacionesDL
    {
        private string connectionString = "your_connection_string_here";

        public List<HistorialActualizacion> Lista()
        {
            var lista = new List<HistorialActualizacion>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM HistorialActualizaciones", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new HistorialActualizacion
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Administrador_ID = Convert.ToInt32(reader["Administrador_ID"]),
                        Accion = reader["Accion"].ToString(),
                        Detalles = reader["Detalles"].ToString(),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"])
                    });
                }
            }

            return lista;
        }

        public HistorialActualizacion Obtener(int id)
        {
            HistorialActualizacion historial = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM HistorialActualizaciones WHERE ID = @ID", connection);
                command.Parameters.AddWithValue("@ID", id);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    historial = new HistorialActualizacion
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Administrador_ID = Convert.ToInt32(reader["Administrador_ID"]),
                        Accion = reader["Accion"].ToString(),
                        Detalles = reader["Detalles"].ToString(),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"])
                    };
                }
            }

            return historial;
        }

        public bool Crear(HistorialActualizacion historial)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO HistorialActualizaciones (Administrador_ID, Accion, Detalles, FechaHora) VALUES (@Administrador_ID, @Accion, @Detalles, @FechaHora)", connection);

                command.Parameters.AddWithValue("@Administrador_ID", historial.Administrador_ID);
                command.Parameters.AddWithValue("@Accion", historial.Accion);
                command.Parameters.AddWithValue("@Detalles", historial.Detalles);
                command.Parameters.AddWithValue("@FechaHora", historial.FechaHora);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
