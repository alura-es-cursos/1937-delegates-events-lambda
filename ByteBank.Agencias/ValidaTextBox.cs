using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ByteBank.Agencias
{
    public delegate void ValidacionEventHandler(object sender, ValidacionEventArgs e);
    public class ValidaTextBox : TextBox
    {
        private ValidacionEventHandler _validacion;
        public event ValidacionEventHandler Validacion
        {
            add
            {
                _validacion += value;
                OnValidacion();
            }

            remove
            {

            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            OnValidacion();
        }


        protected virtual void OnValidacion()
        {
            if (_validacion != null)
            {
                var listaValidaciones = _validacion.GetInvocationList();
                var e = new ValidacionEventArgs(Text);
                var isValid = true;

                foreach(ValidacionEventHandler validacion in listaValidaciones)
                {
                    validacion(this, e);
                    if (!e.isValid)
                    {
                        isValid = false;
                        break;
                    }
                }

                Background = isValid
                    ? new SolidColorBrush(Colors.White)
                    : new SolidColorBrush(Colors.OrangeRed);
            }
        }

    }
}
