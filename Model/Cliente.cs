using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    internal class Cliente
    {
        public int Codcliente { get; set; }
        public string Nomecliente { get; set; }
        public byte[] Foto { get; set; }
        public string Datanasc { get; set; }
        public Sexo Sexo { get; set; }
        public Rua Rua { get; set; }
        public Bairro Bairro { get; set; }  
        public Cep Cep { get; set; }
        public Cidade Cidade { get; set; }  
        public double Salario { get; set; }
        public Trabalho Trabalho { get; set; }
        public string Numeroca { get; set; }

    }
}
