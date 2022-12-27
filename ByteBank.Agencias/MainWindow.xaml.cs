using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextDB = new ByteBankEntities();
        private readonly ListBox lstAgencias;
        public MainWindow()
        {
            InitializeComponent();
            lstAgencias = new ListBox();
            actualizarControles();
        }

        private void actualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;

            Canvas.SetTop(lstAgencias, 20);
            Canvas.SetLeft(lstAgencias, 20);
            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChanged);

            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);
            Container.Children.Add(lstAgencias);

            lstAgencias.Items.Clear();
            var agencias = _contextDB.Agencias.ToList();

            foreach(var agencia in agencias)
            {
                lstAgencias.Items.Add(agencia);
            }
            
        }

        private void lstAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSeleccionada = (Agencia)lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSeleccionada.Numero;
            txtNombre.Text = agenciaSeleccionada.Nombre;
            txtDescripcion.Text = agenciaSeleccionada.Descripcion;
            txtDireccion.Text = agenciaSeleccionada.Direccion;
            txtTelefono.Text = agenciaSeleccionada.Telefono;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            var agenciaSeleccionada = (Agencia)lstAgencias.SelectedItem;
            var ventanaEdicion = new EdicionRegistro(agenciaSeleccionada);

            bool result = ventanaEdicion.ShowDialog().Value;

            if (result)
            {
                //Ejecutamos cuando es true
            } else
            {
                //Ejecutamos cuando es false
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resultado = MessageBox.Show("Confirma borrar la agencia?", "Alerta", MessageBoxButton.YesNo);

            if (resultado == MessageBoxResult.Yes)
            {
                //Cuando el usuario presiono Si
            } else
            {

            }
        }
    }
}
