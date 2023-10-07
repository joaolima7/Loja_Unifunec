using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Venda
    {
        public int Codvenda { get; set; }
        public string Datavenda { get; set; }
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }

    }
}
