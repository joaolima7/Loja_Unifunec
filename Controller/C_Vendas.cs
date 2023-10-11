using Loja_Unifunec.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Controller
{
    internal class C_Vendas
    {
        SqlConnection con;
        SqlCommand cmd;

        string sqlCriarVenda = "insert into venda(codvenda, datavenda, codcliente_fk, codfuncionario_fk) values (getdate(), )";

        public List<Venda> criarVenda(string nomecliente, string nomefuncionario)
        {
            string func = nomefuncionario;
            string cliente = nomecliente;

            List<Venda> vendas = new List<Venda>();
            return vendas;
        }

    }

}
