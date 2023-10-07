using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class ControleLogSistema
    {
        public int Codcontrole { get; set; }
        public Login Login { get; set; }
        public string Descricao { get; set; }
        public string Datalog { get; set; }
        public string Horalog { get; set; }

    }
}
