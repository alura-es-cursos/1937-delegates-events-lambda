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
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Lógica de interacción para EdicionRegistro.xaml
    /// </summary>
    public partial class EdicionRegistro : Window
    {
        private readonly Agencia _agencia;
        public EdicionRegistro(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia ?? throw new ArgumentNullException(nameof(agencia));

            actualizarCajasEdicion();
            actualizarControles();
        }

        private void actualizarCajasEdicion()
        {
            txtNombre.Text = _agencia.Nombre;
            txtNumero.Text = _agencia.Numero;
            txtDireccion.Text = _agencia.Direccion;
            txtDescripcion.Text = _agencia.Descripcion;
            txtTelefono.Text = _agencia.Telefono;
        }

        private void actualizarControles()
        {
            var okEventHandler = (RoutedEventHandler)btnOk_Click + cerrarVentana;
            Delegate cancelarEventHandler = 
                   Delegate.Combine((RoutedEventHandler)btnCancelar_Click,
                                    (RoutedEventHandler)cerrarVentana);
                

            btnOk.Click += okEventHandler;
            btnCancelar.Click += (RoutedEventHandler)cancelarEventHandler;

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void cerrarVentana(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
