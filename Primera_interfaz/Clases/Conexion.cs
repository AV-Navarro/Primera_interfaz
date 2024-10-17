using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Media.Media3D;
using System.Windows;


namespace Primera_interfaz.Clases
{
    public class Conexion
    {
        private string conexionString = "Data Source=Empleados.db;Version=3;";

        public Conexion()
        {
            CrearTablaSiNoExiste(); // Llama al método en el constructor
        }

        // Método que crea la tabla si no existe
        private void CrearTablaSiNoExiste() 
        {
            using (var conexion = new SQLiteConnection(conexionString)) 
            {
                conexion.Open();

                //SQL para crea tabla
                string query = @"
                CREATE TABLE IF NOT EXISTS Empleado (
                    Id INTEGER PRIMARY KEY,
                    Nombre TEXT NOT NULL,
                    Direccion TEXT NOT NULL,
                    Ciudad TEXT NOT NULL,
                    Pais TEXT NOT NULL
                );";
                using (var command = new SQLiteCommand(query, conexion))
                {
                    command.ExecuteNonQuery(); // Ejecuta el comando
                }
            }
        }

        public List<Empleado> GetAllEmpleados()
        {
            List<Empleado> oLista = new List<Empleado>();

            using (var connection = new SQLiteConnection(conexionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Direccion, Ciudad, Pais FROM Empleado";
                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.CommandType = System.Data.CommandType.Text;
                {
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Empleado()
                            {
                                IdEmpleado = int.Parse(dr["Id"].ToString()),
                                NombreEmpleado = dr["Nombre"].ToString(),
                                DireccionEmpleado = dr["Direccion"].ToString(),
                                CiudadEmpleado = dr["Ciudad"].ToString(),
                                PaisEmpleado = dr["Pais"].ToString(),
                            });
                        }
                    }
                }
            }

            return oLista;
        }

        public bool Editar(Empleado obj)
        {
            bool respuesta = true;



            using (var connection = new SQLiteConnection(conexionString))
            {
                connection.Open();
                string query = "Update Empleado set Nombre = @nombre, Direccion = @direccion, Ciudad = @ciudad, Pais = @pais where Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.IdEmpleado));
                cmd.Parameters.Add(new SQLiteParameter("@nombre", obj.NombreEmpleado));
                cmd.Parameters.Add(new SQLiteParameter("@direccion", obj.DireccionEmpleado));
                cmd.Parameters.Add(new SQLiteParameter("@ciudad", obj.CiudadEmpleado));
                cmd.Parameters.Add(new SQLiteParameter("@pais", obj.PaisEmpleado));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }


        public void AddEmpleado(Empleado empleado)
        {
            using (var connection = new SQLiteConnection(conexionString))
            {
                connection.Open();
                string query = "INSERT INTO Empleado (Nombre, Direccion, Ciudad, Pais) VALUES (@nombre, @direccion, @ciudad, @pais)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", empleado.NombreEmpleado);
                    command.Parameters.AddWithValue("@direccion", empleado.DireccionEmpleado);
                    command.Parameters.AddWithValue("@ciudad", empleado.CiudadEmpleado);
                    command.Parameters.AddWithValue("@pais", empleado.PaisEmpleado);
                    command.CommandType = System.Data.CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool Eliminar(Empleado obj)
        {
            bool respuesta = true;

            using (var connection = new SQLiteConnection(conexionString))
            {
                connection.Open();
                string query = "Delete from empleado where Id = @id";

                SQLiteCommand cmd = new SQLiteCommand(query, connection);
                cmd.Parameters.Add(new SQLiteParameter("@id", obj.IdEmpleado));
                cmd.CommandType = System.Data.CommandType.Text;

                if (cmd.ExecuteNonQuery() < 1)
                {
                    respuesta = false;
                }
            }

            return respuesta;
        }

    }

}

