using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Model
{
    public class Funcionario
    {
        public int Codfuncionario { get; set; }
        public string Nomefuncionario { get; set; }
        public byte[] Foto { get; set; }
        public Rua Rua { get; set; }
        public Bairro Bairro { get; set; }
        public Cep Cep { get; set; }
        public Cidade Cidade { get; set; }
        public Funcao Funcao { get; set; }
        public double Salario { get; set; }
        public Loja Loja { get; set; }
        public Sexo Sexo { get; set; }
        public string Datanasc { get; set; }


    }
}
