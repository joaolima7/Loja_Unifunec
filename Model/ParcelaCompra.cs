using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class ParcelaCompra
    {
        public int Codparcela { get; set; }
        public string Datavencimento { get; set; }
        public double Valor { get; set; }
        public Situacao Situacao { get; set; }
        public Compra Compra { get; set; }

    }
}
