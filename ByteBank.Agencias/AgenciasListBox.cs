using ByteBank.Agencias.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ByteBank.Agencias
{
    public class AgenciasListBox : ListBox
    {
        private readonly MainWindow _mainW;

        public AgenciasListBox(MainWindow mainW)
        {
            _mainW = mainW ?? throw new ArgumentNullException(nameof(mainW));
        }

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);

            var agenciaSeleccionada = (Agencia)SelectedItem;

            _mainW.txtNumero.Text = agenciaSeleccionada.Numero;
            _mainW.txtNombre.Text = agenciaSeleccionada.Nombre;
            _mainW.txtDescripcion.Text = agenciaSeleccionada.Descripcion;
            _mainW.txtDireccion.Text = agenciaSeleccionada.Direccion;
            _mainW.txtTelefono.Text = agenciaSeleccionada.Telefono;
        }
    }
}
