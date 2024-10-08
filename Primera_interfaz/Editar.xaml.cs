using Primera_interfaz.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Editar.xaml
    /// </summary>
    public partial class Editar : Window
    {
        private Empleado empleadoSeleccionado;
        private ObservableCollection<Empleado> empleadosList;
        

        public Editar(Empleado empleado, ObservableCollection<Empleado> empleados)
        {
            InitializeComponent();

            this.empleadoSeleccionado = empleado;
            this.empleadosList = empleados;

            // Precargo los datos del empleado en los TextBox
            txtId.Text = empleadoSeleccionado.IdEmpleado.ToString();
            txtNombre.Text = empleadoSeleccionado.NombreEmpleado.ToString();
            txtDireccion.Text = empleadoSeleccionado.DireccionEmpleado.ToString();  
            txtCiudad.Text = empleadoSeleccionado.CiudadEmpleado.ToString();
            txtPais.Text = empleadoSeleccionado.PaisEmpleado.ToString();
        }

        private void Editar_Click(object sender, RoutedEventArgs e)
        {
            // Actualizar los datos del empleado seleccionado
            empleadoSeleccionado.NombreEmpleado = txtNombre.Text;
            empleadoSeleccionado.DireccionEmpleado = txtDireccion.Text;
            empleadoSeleccionado.CiudadEmpleado = txtCiudad.Text;
            empleadoSeleccionado.PaisEmpleado = txtPais.Text;                        

            MessageBox.Show("Empleado editado exitosamente!");
            Close(); // Cerrar la ventana después de editar
        }
    
    }
}

