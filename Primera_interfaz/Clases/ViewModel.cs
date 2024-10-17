using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Primera_interfaz.Clases
{
    public class ViewModel 
    {
        // Lista en memoria para almacenar los empleados
        public ObservableCollection<Empleado> Empleados { get; set; }
        public Conexion _conexion;

        public ViewModel()        
        {            
           _conexion = new Conexion();

            // Cargar los empleados desde la base de datos
            var listaEmpleados = _conexion.GetAllEmpleados();
            Empleados = new ObservableCollection<Empleado>(listaEmpleados);
        }

        public void AgregarEmpleado(Empleado nuevoEmpleado)
        {
            _conexion.AddEmpleado(nuevoEmpleado);           

            Empleados.Add(nuevoEmpleado);
        }       

        public void EditarEmpleado(Empleado empleado)
        {
            bool exito = _conexion.Editar(empleado);

            if (exito) {

                var empleadoExistente = Empleados.FirstOrDefault(e => e.IdEmpleado == empleado.IdEmpleado);
                if (empleadoExistente != null)
                {
                    empleadoExistente.NombreEmpleado = empleado.NombreEmpleado;
                    empleadoExistente.DireccionEmpleado = empleado.DireccionEmpleado;
                    empleadoExistente.CiudadEmpleado = empleado.CiudadEmpleado;
                    empleadoExistente.PaisEmpleado = empleado.PaisEmpleado;

                    var index = Empleados.IndexOf(empleadoExistente);
                    Empleados[index] = empleadoExistente;
                }
            }
            else
            {
                MessageBox.Show("Error al actualizar el empleado en la base de datos.");
            }
        }

        // Método para eliminar un empleado
        public void EliminarEmpleado(Empleado empleado)
        {
            bool exito = _conexion.Eliminar(empleado);
            if (exito)
            {
                Empleados.Remove(empleado);
            }
            else
            {
                MessageBox.Show("Error al eliminar el empleado en la base de datos.");
            }
        }

        
    }
}
