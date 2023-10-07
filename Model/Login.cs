using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Login
    {
        public int Codlogin { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public Funcionario Funcionario { get; set; }
    }
}
