using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Primera_interfaz.Clases;

namespace Primera_interfaz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Lista en memoria para almacenar los empleados
        private ObservableCollection<Empleado> empleados;

        public MainWindow()
        {
            InitializeComponent();
            // Inicializamos la lista de empleados
            empleados = new ObservableCollection<Empleado>
            {
                new Empleado { IdEmpleado = 1, NombreEmpleado = "Juan Pérez", DireccionEmpleado = "Calle 1", CiudadEmpleado = "Madrid", PaisEmpleado = "España" },
                new Empleado { IdEmpleado = 2, NombreEmpleado = "Ana García", DireccionEmpleado = "Calle 2", CiudadEmpleado = "Barcelona", PaisEmpleado = "España" }
            };
            // Asignamos la lista al DataGrid
            DataGridXAML.ItemsSource = empleados;
        }

        // Crear un nuevo empleado
        private void CrearCliente(object sender, RoutedEventArgs e)
        {
            // Añadimos un nuevo empleado
            var nuevoEmpleado = new Empleado
            {
                IdEmpleado = empleados.Count + 1,
                NombreEmpleado = "Nuevo Empleado",
                DireccionEmpleado = "Nueva Dirección",
                CiudadEmpleado = "Nueva Ciudad",
                PaisEmpleado = "Nuevo País"
            };
            empleados.Add(nuevoEmpleado);
        }

        // Leer (Seleccionar) un empleado
        private void Leer_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXAML.SelectedItem is Empleado empleadoSeleccionado)
            {
                MessageBox.Show($"ID: {empleadoSeleccionado.IdEmpleado}\n" +
                                $"Nombre: {empleadoSeleccionado.NombreEmpleado}\n" +
                                $"Dirección: {empleadoSeleccionado.DireccionEmpleado}\n" +
                                $"Ciudad: {empleadoSeleccionado.CiudadEmpleado}\n" +
                                $"País: {empleadoSeleccionado.PaisEmpleado}", "Detalles del Empleado");
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado.");
            }
        }

        // Actualizar un empleado seleccionado
        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXAML.SelectedItem is Empleado empleadoSeleccionado)
            {
                empleadoSeleccionado.NombreEmpleado = "Empleado Actualizado";
                empleadoSeleccionado.DireccionEmpleado = "Dirección Actualizada";
                empleadoSeleccionado.CiudadEmpleado = "Ciudad Actualizada";
                empleadoSeleccionado.PaisEmpleado = "País Actualizado";

                // Refresca la vista para mostrar los cambios
                DataGridXAML.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado.");
            }
        }

        // Eliminar un empleado seleccionado
        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridXAML.SelectedItem is Empleado empleadoSeleccionado)
            {
                // Mostrar un mensaje de confirmación
                MessageBoxResult resultado = MessageBox.Show(
                    $"¿Estás seguro de que quieres eliminar al empleado {empleadoSeleccionado.NombreEmpleado}?",
                    "Confirmar eliminación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                // Si el usuario selecciona "Sí", procedemos con la eliminación
                if (resultado == MessageBoxResult.Yes)
                {
                    empleados.Remove(empleadoSeleccionado);
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado.");
            }
        }
    }

    
}
