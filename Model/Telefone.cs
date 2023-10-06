using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Telefone
    {
        public int Codtelefone { get; set; }
        public string Numero { get; set; }
        public Operadora Operadora { get; set; }

    }
}
