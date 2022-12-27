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
using static System.Net.Mime.MediaTypeNames;

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
            RoutedEventHandler dialogResultTrue = (o, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (o, e) => DialogResult = false;
           

            var okEventHandler = dialogResultTrue + cerrarVentana;
            Delegate cancelarEventHandler = 
                   Delegate.Combine(dialogResultFalse,
                                    (RoutedEventHandler)cerrarVentana);
                

            btnOk.Click += okEventHandler;
            btnCancelar.Click += (RoutedEventHandler)cancelarEventHandler;

            txtNumero.TextChanged += ValidaCampoNulo;
            txtNombre.TextChanged += ValidaCampoNulo;
            txtDireccion.TextChanged += ValidaCampoNulo;
            txtDescripcion.TextChanged += ValidaCampoNulo;
            txtTelefono.TextChanged += ValidaCampoNulo;

        }

        private void ValidaCampoNulo(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            var textoVacio = String.IsNullOrEmpty(txt.Text);

            if (textoVacio)
            {
                txt.Background = new SolidColorBrush(Colors.OrangeRed);
            }
            else
            {
                txt.Background = new SolidColorBrush(Colors.White);
            }
        }

       
        private void cerrarVentana(object sender, EventArgs e)
        {
            Close();
        }
    }
}

