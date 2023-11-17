using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja_Unifunec.Conection;
using System.Windows.Forms;
using Loja_Unifunec.Model;

namespace Loja_Unifunec.Controller
{
    public static class C_Produtos
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dataTableProdutos;

        static string sqlCarregarProdutos = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk order by p.codproduto";
        static string sqlPesquisaRealTimeProd = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk where p.nomeproduto like @p1 order by p.codproduto";
        static string sqlPesquisaRealTimeMarca = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk where m.nomemarca like @p1 order by p.codproduto";
        static string sqlPesquisaRealTimeTipo = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, p.quantidade as ESTOQUE," +
            "p.valor as VALOR, m.nomemarca as MARCA, t.nometipo as TIPO from produto p join marca m on m.codmarca = p.codmarca_fk join tipo t" +
            " on t.codtipo = p.codtipo_fk where t.nometipo like @p1 order by p.codproduto";
        static string sqlConsultaEstoque = "select quantidade from produto where codproduto = @param";
        static string sqlExcluirProd = "delete from produto where codproduto = @param";
        static string sqlInserirProdutos = "insert into produto(nomeproduto, quantidade, valor, codmarca_fk, codtipo_fk) values(@p1, @p2, @p3, @p4, @p5)";
        static string sqlBaixaEstoque = "update produto set quantidade = quantidade - @quant where codproduto = @codprod";
        static string sqlEditarProd = "update produto set nomeproduto = @p1, quantidade = @p2, valor = @p3, codmarca_fk = @p4, codtipo_fk = @p5 where codproduto = @codprod";

        public static DataTable carregarProdutos()
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


        public static decimal verificaEstoque(string codproduto)
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

        public static void baixaEstoque(string codproduto, string quantidade)
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

        public static DataTable inserirProduto(object obj)
        {
            Conexao conection = new Conexao();  
            Produto prod = new Produto();
            prod = (Produto)obj;
            dataTableProdutos = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirProdutos, con);
            cmd.Parameters.AddWithValue("@p1", prod.Nomeproduto);
            cmd.Parameters.AddWithValue("@p2", prod.Quantidade);
            cmd.Parameters.AddWithValue("@p3", prod.Valor);
            cmd.Parameters.AddWithValue("@p4", prod.Marca.Codmarca);
            cmd.Parameters.AddWithValue("@p5", prod.Tipo.Codtipo);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto inserido com Sucesso!","ÊXITO",MessageBoxButtons.OK,MessageBoxIcon.Information);

                cmd.CommandText = sqlCarregarProdutos;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableProdutos);
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

        public static DataTable excluirProduto(string codproduto)
        {
            Conexao conection = new Conexao();
            dataTableProdutos = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirProd, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codproduto));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarProdutos;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableProdutos);
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

        public static DataTable editarProduto(object obj)
        {
            Conexao conection = new Conexao();
            Produto prod = new Produto();
            prod = (Produto)obj;
            dataTableProdutos = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlEditarProd, con);
            cmd.Parameters.AddWithValue("@p1", prod.Nomeproduto);
            cmd.Parameters.AddWithValue("@p2", prod.Quantidade);
            cmd.Parameters.AddWithValue("@p3", prod.Valor);
            cmd.Parameters.AddWithValue("@p4", prod.Marca.Codmarca);
            cmd.Parameters.AddWithValue("@p5", prod.Tipo.Codtipo);
            cmd.Parameters.AddWithValue("@codprod", prod.Codproduto );
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarProdutos;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableProdutos);
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

        public static DataTable pesquisaRealTime(string nome, string sql)
        {
            if (sql == "sqlPesquisaRealTimeProd")
            {
                cmd = new SqlCommand(sqlPesquisaRealTimeProd, con);
            }
            else if (sql == "sqlPesquisaRealTimeMarca")
            {
                cmd = new SqlCommand(sqlPesquisaRealTimeMarca, con);
            }
            else if (sql == "sqlPesquisaRealTimeTipo")
            {
                cmd = new SqlCommand(sqlPesquisaRealTimeTipo, con);
            }
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            dataTableProdutos = new DataTable();

            cmd.Parameters.AddWithValue("@p1", "%" + nome + "%");
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

            return dataTableProdutos;
        }

    }
}
