using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    public class Cidade
    {
        public int Codcidade { get; set; }
        public string Nomecidade { get; set; }
        public Uf Uf { get; set; }

    }
}
