using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primera_interfaz.Clases
{
    public class ViewModel 
    {
        // Lista en memoria para almacenar los empleados
        public ObservableCollection<Empleado> Empleados { get; set; }

        public ViewModel()        
        {            
            Empleados = new ObservableCollection<Empleado> 

            {
                new() {

                    IdEmpleado = 1,
                    NombreEmpleado = "María López",
                    DireccionEmpleado = "Av. Principal 456",
                    CiudadEmpleado = "Barcelona",
                    PaisEmpleado = "España"
                },

                 new() {

                     IdEmpleado = 2,
                     NombreEmpleado = "Paco López",
                     DireccionEmpleado = "Av. Principal 456",
                     CiudadEmpleado = "Barcelona",                    
                     PaisEmpleado = "España"
                 },
                 new() {

                     IdEmpleado = 3,
                     NombreEmpleado = "Luis López",
                     DireccionEmpleado = "Av. Principal 456",
                     CiudadEmpleado = "Barcelona",
                     PaisEmpleado = "España"
                 }
            };
        }
       

    }
}
