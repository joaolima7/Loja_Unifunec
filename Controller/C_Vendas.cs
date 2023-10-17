using Loja_Unifunec.Conection;
using Loja_Unifunec.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Controller
{
    internal class C_Vendas
    {
        Conexao cn = new Conexao();
        SqlConnection con;
        SqlCommand cmd;
        DataTable dtVendas;

        string sqlCriarVenda = "insert into venda(datavenda, codcliente_fk, codfuncionario_fk) values (getdate(), @codcliente, @codfunc)";
        string sqlVendaProduto = "insert into itensvendaproduto(codvenda_fk, codproduto_fk, quantidade, valor) values (@codvenda, @codprod, @quant, @valor)";

        public int criarVenda(string codcliente, string codfuncionario)
        {
            int codvenda = -1;
            string func = codfuncionario;
            string cliente = codcliente;
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlCriarVenda,con);
            cmd.Parameters.AddWithValue("@codcliente",codcliente);
            cmd.Parameters.AddWithValue("@codfunc",codfuncionario);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(codvenda) FROM venda";
                codvenda = Convert.ToInt32(cmd.ExecuteScalar());

                return codvenda;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return codvenda;

        }

        public DataTable insereVendaProduto(string codvenda, string codproduto, string quantidade, string valor)
        {
            dtVendas = new DataTable();
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlVendaProduto,con);
            cmd.Parameters.AddWithValue("@codvenda",codvenda);
            cmd.Parameters.AddWithValue("@codprod",codproduto);
            cmd.Parameters.AddWithValue("@quant",quantidade);
            cmd.Parameters.AddWithValue("@valor",valor);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select p.codproduto as CÓDIGO,1 p.nomeproduto as PRODUTO, p.valor as VALOR, ivp.quantidade as QUANTIDADE," +
                                  "ivp.valor as VALOR from itensvendaproduto ivp join produto p on p.codproduto=ivp.codproduto_fk" +
                                  " join venda v on v.codvenda=ivp.codvenda_fk where codvenda_fk = @codvenda order by p.nomeproduto";
                cmd.Parameters.AddWithValue("@codvenda",codvenda);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtVendas);
                return dtVendas;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtVendas = null;
            return dtVendas;

        }

    }

}
