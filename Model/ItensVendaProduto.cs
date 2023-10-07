using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class ItensVendaProduto
    {
        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade {get; set;}
        public double Valor { get; set;}


    }
}
