using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Fornecedor
    {
        public int Codfornecedor { get; set; }
        public string Nomefornecedor { get; set; }
        public int Numerocasa { get; set; }
        public Rua Rua { get; set; }    
        public Bairro Bairro { get; set; } 
        public Cep Cep { get; set; }    
        public Cidade Cidade { get; set; }  

    }
}
