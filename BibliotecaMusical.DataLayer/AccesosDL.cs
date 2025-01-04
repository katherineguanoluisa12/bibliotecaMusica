using BibliotecaMusical.EntityLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BibliotecaMusical.DataLayer
{
    public class AccesosDL
    {
        private string connectionString = "your_connection_string_here";

        public List<Acceso> Lista()
        {
            var lista = new List<Acceso>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Accesos", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Acceso
                    {
                        Acceso_ID = Convert.ToInt32(reader["Acceso_ID"]),
                        Usuario_ID = Convert.ToInt32(reader["Usuario_ID"]),
                        Material_ID = Convert.ToInt32(reader["Material_ID"]),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"])
                    });
                }
            }

            return lista;
        }

        public Acceso Obtener(int accesoID)
        {
            Acceso acceso = null;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Accesos WHERE Acceso_ID = @Acceso_ID", connection);
                command.Parameters.AddWithValue("@Acceso_ID", accesoID);
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    acceso = new Acceso
                    {
                        Acceso_ID = Convert.ToInt32(reader["Acceso_ID"]),
                        Usuario_ID = Convert.ToInt32(reader["Usuario_ID"]),
                        Material_ID = Convert.ToInt32(reader["Material_ID"]),
                        FechaHora = Convert.ToDateTime(reader["FechaHora"])
                    };
                }
            }

            return acceso;
        }

        public bool Crear(Acceso acceso)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Accesos (Usuario_ID, Material_ID, FechaHora) VALUES (@Usuario_ID, @Material_ID, @FechaHora)", connection);

                command.Parameters.AddWithValue("@Usuario_ID", acceso.Usuario_ID);
                command.Parameters.AddWithValue("@Material_ID", acceso.Material_ID);
                command.Parameters.AddWithValue("@FechaHora", acceso.FechaHora);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
