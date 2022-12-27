using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate bool ValidacionEventHandler(string texto);
    public class ValidaTextBox : TextBox
    {
        public event ValidacionEventHandler Validacion;

        public ValidaTextBox()
        {
            TextChanged += ValidaTextBox_TextChanged;
        }

        private void ValidaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Validacion != null)
            {
                var isValid = Validacion(Text);

                Background = isValid
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }

    }
}
