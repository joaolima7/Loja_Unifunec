using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Produto
    {
        public int Codproduto { get; set; }
        public string Nomeproduto { get; set; }
        public double Quantidade { get; set; }
        public double Valor { get; set; }
        public Marca Marca { get; set; }
        public Tipo Tipo { get; set; }

    }
}
