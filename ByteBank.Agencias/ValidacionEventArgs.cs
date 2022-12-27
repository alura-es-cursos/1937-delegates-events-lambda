using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agencias
{
    public class ValidacionEventArgs
    {
        public string Texto { get; private set; }
        public bool isValid { get; set; }

        public ValidacionEventArgs(string texto)
        {
            Texto = texto;
        }

    }
}
