using Loja_Unifunec.Conection;
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
    public static class C_Compra
    {
        static Conexao cn = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtCompras;


        static String sqlInserirCompra = "insert into compra(datacompra, codfornecedor_fk, codfuncionario_fk) values(getdate(), @p1, @p2)";
        static String sqlInserirProdutoCompra = "insert into itenscompraproduto(codcompra_fk, codproduto_fk, quantidade, valor) values(@p1, @p2, @p3, @p4)";
        static String sqlExibirProdutosCompra = "select p.nomeproduto as PRODUTO, icp.quantidade as QUANTIDADE, icp.valor as VALOR from itenscompraproduto icp join produto p on p.codproduto=icp.codproduto_fk where icp.codcompra_fk = @codcompra";



        public static int criarCompra(string codforn, string codfunc)
        {
            int codcompra = -1;
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlInserirCompra, con);
            cmd.Parameters.AddWithValue("@p1", codforn);
            cmd.Parameters.AddWithValue("@p2", codfunc);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(codcompra) FROM compra";
                codcompra = Convert.ToInt32(cmd.ExecuteScalar());

                return codcompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return codcompra;

        }

        public static DataTable insereVendaProduto(string codcompra, string codproduto, string quantidade, string valor)
        {

            dtCompras = new DataTable();
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlInserirProdutoCompra, con);
            cmd.Parameters.AddWithValue("@p1", int.Parse(codcompra));
            cmd.Parameters.AddWithValue("@p2", int.Parse(codproduto));
            cmd.Parameters.AddWithValue("@p3", int.Parse(quantidade));
            cmd.Parameters.AddWithValue("@p4", float.Parse(valor));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlExibirProdutosCompra;

                cmd.Parameters.AddWithValue("@codcompra", int.Parse(codcompra));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCompras);
                return dtCompras;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCompras = null;
            return dtCompras;

        }


    }
}
