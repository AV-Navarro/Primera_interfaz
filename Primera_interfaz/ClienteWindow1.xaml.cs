using Primera_interfaz.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Primera_interfaz
{
    /// <summary>
    /// Lógica de interacción para ClienteWindow1.xaml
    /// </summary>
    public partial class ClienteWindow1 : Window
    {
        private ObservableCollection<Empleado> empleadosList;
        private Conexion conexion;
        
        public ClienteWindow1(ObservableCollection<Empleado> empleados, Conexion conexion)
        {
            InitializeComponent();
            this.empleadosList = empleados;
            this.conexion = conexion;

            
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            //Verificar que no esten vacíos los campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtPais.Text))
            {
                MessageBox.Show("Por favor completa todos los campos.");
                return; // No continúa si hay campos vacíos
            }

            var nuevoEmpleado = new Empleado
            {
               
                NombreEmpleado = txtNombre.Text,
                DireccionEmpleado = txtDireccion.Text,
                CiudadEmpleado = txtCiudad.Text,
                PaisEmpleado = txtPais.Text
            };

            conexion.AddEmpleado(nuevoEmpleado);

            empleadosList.Add(nuevoEmpleado);
            MessageBox.Show("Empleado agregado con éxito!");
            Close(); // Cerrar la ventana después de agregar
        }
    }
}