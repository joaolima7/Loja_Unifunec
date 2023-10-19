using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja_Unifunec.Conection;
using System.Windows.Forms;

namespace Loja_Unifunec.Controller
{
    internal class C_Produtos
    {

        SqlConnection con;
        SqlCommand cmd;
        DataTable dataTableProdutos;

        string sqlCarregarProdutos = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk order by p.codproduto";
        string sqlConsultaEstoque = "select quantidade from produto where codproduto = @param";
        string sqlBaixaEstoque = "update produto set quantidade = quantidade - @quant where codproduto = @codprod";

        public DataTable carregarProdutos()
        {
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            dataTableProdutos = new DataTable();

            cmd = new SqlCommand(sqlCarregarProdutos, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableProdutos); // Carregar dados diretamente no DataTable
                return dataTableProdutos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dataTableProdutos = null;
            return dataTableProdutos;
        }


        public decimal verificaEstoque(string codproduto)
        {
            decimal estoque = 0;
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();

            cmd = new SqlCommand(sqlConsultaEstoque, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codproduto));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    estoque = reader.GetDecimal(0);
                    return estoque;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return estoque;
        }

        public void baixaEstoque(string codproduto, string quantidade)
        {
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();

            cmd = new SqlCommand(sqlBaixaEstoque, con);
            cmd.Parameters.AddWithValue("@quant", int.Parse(quantidade));
            cmd.Parameters.AddWithValue("@codprod", int.Parse(codproduto));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

    }
}
