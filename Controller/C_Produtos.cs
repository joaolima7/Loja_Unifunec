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
    }
}
