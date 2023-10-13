using Loja_Unifunec.Conection;
using Loja_Unifunec.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Unifunec.Controller
{
    internal class C_Vendas
    {
        Conexao cn = new Conexao();
        SqlConnection con;
        SqlCommand cmd;

        string sqlCriarVenda = "insert into venda(datavenda, codcliente_fk, codfuncionario_fk) values (getdate(), @codcliente, @codfunc)";

        public void criarVenda(string codcliente, string codfuncionario)
        {
            string func = codfuncionario;
            string cliente = codcliente;
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlCriarVenda,con);
            cmd.Parameters.AddWithValue("@codcliente",codcliente);
            cmd.Parameters.AddWithValue("@codfunc",codfuncionario);
            cmd.CommandType = CommandType.Text;



        }

    }

}
