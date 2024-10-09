using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
        //private ObservableCollection<Empleado> empleadosFiltrados;

        public MainWindow()
        {
            InitializeComponent();
            empleados = new ObservableCollection<Empleado>();


            // Asignamos la lista al DataGrid
            DataGridXAML.ItemsSource = null;
            DataGridXAML.ItemsSource = empleados;

            // Crear un empleado al iniciar (opcional)
            Empleado primerEmpleado = new Empleado
            {
                IdEmpleado = 1,
                NombreEmpleado = "María López",
                DireccionEmpleado = "Av. Principal 456",
                CiudadEmpleado = "Barcelona",
                PaisEmpleado = "España"
            };

            empleados.Add(primerEmpleado); // Agregar el empleado a la lista
        }

        // Método filtrar búsqueda
        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            //Obtengo el texto del TexBox
            string textoBusqueda = txtBusqueda.Text.ToLower();

            //Filtrado
            var empleadoFiltrados = empleados.Where(emp => emp.NombreEmpleado.ToLower().Contains(textoBusqueda)).ToList();

            //Actualizo el DataGRid
            DataGridXAML.ItemsSource = null;
            DataGridXAML.ItemsSource = empleadoFiltrados;
        }

        // Crear un nuevo empleado
        private void CrearCliente(object sender, RoutedEventArgs e)
        {
            // Añadimos un nuevo empleado
            ClienteWindow1 clienteWindow = new ClienteWindow1(empleados);
            clienteWindow.ShowDialog(); // Muestra la ventana como un diálogo modal

            DataGridXAML.Items.Refresh();

            // Deseleccionar el empleado 
            DataGridXAML.SelectedItem = null;
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

                DataGridXAML.Items.Refresh();

                // Deseleccionar el empleado 
                DataGridXAML.SelectedItem = null;
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
                Editar editarWindow = new Editar(empleadoSeleccionado, empleados);
                editarWindow.ShowDialog();

                DataGridXAML.Items.Refresh();

                // Deseleccionar el empleado 
                DataGridXAML.SelectedItem = null;
            }

            else
            {
                MessageBox.Show("Por favor selecciona un empleado.");
            }
        }

        //Metodo para deseleccionar
        private void DataGridXAML_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Verificar si el clic no fue en una celda
            if (!(e.OriginalSource is DataGridCell))
            {
                // Deseleccionar cualquier selección existente
                DataGridXAML.SelectedItem = null;
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
                    DataGridXAML.Items.Refresh();

                    // Deseleccionar el empleado después de eliminar
                    DataGridXAML.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Por favor selecciona un empleado.");
            }
        }
    }


}