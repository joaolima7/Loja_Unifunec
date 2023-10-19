using Loja_Unifunec.Conection;
using Loja_Unifunec.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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
        string sqlExibirTodasVendas = "select v.codvenda as CÓDIGO, v.datavenda as DATA, c.nomecliente as CLIENTE, f.nomefuncionario as FUNCIONARIO from venda v join cliente c on v.codcliente_fk=c.codcliente join funcionario f on f.codfuncionario=v.codfuncionario_fk ";
        string sqlExibirVendaSelecionada = "select v.datavenda, c.nomecliente, f.nomefuncionario from venda v join cliente c on c.codcliente=v.codcliente_fk join funcionario f on f.codfuncionario=v.codfuncionario_fk where v.codvenda = @param";
        string sqlExibirVendaProdutoSelecionada = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, ivp.quantidade as QUANTIDADE,ivp.valor as VALOR,ivp.valor*ivp.quantidade as TOTAL from itensvendaproduto ivp join produto p on p.codproduto=ivp.codproduto_fk join venda v on v.codvenda=ivp.codvenda_fk where codvenda_fk = @codvendaa order by p.nomeproduto";
        string sqlPesquisaVendasCliente = "select v.codvenda as CÓDIGO, v.datavenda as DATA, c.nomecliente as CLIENTE, f.nomefuncionario as FUNCIONARIO from venda v join cliente c on v.codcliente_fk=c.codcliente join funcionario f on f.codfuncionario=v.codfuncionario_fk where c.nomecliente like @param2";
        string sqlPesquisaVendasData = "select v.codvenda as CÓDIGO, v.datavenda as DATA, c.nomecliente as CLIENTE, f.nomefuncionario as FUNCIONARIO from venda v join cliente c on v.codcliente_fk=c.codcliente join funcionario f on f.codfuncionario=v.codfuncionario_fk where v.datavenda like @param2";
        string sqlPesquisaVendasCod = "select v.codvenda as CÓDIGO, v.datavenda as DATA, c.nomecliente as CLIENTE, f.nomefuncionario as FUNCIONARIO from venda v join cliente c on v.codcliente_fk=c.codcliente join funcionario f on f.codfuncionario=v.codfuncionario_fk where v.codvenda = @param2";


        public DataTable buscarVendas()
        {
            dtVendas = new DataTable();
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlExibirTodasVendas, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
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

        public DataTable buscarVendaProdutoSelecionada(string codvenda)
        {
            dtVendas = new DataTable();
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlExibirVendaProdutoSelecionada, con);
            cmd.Parameters.AddWithValue("@codvendaa", codvenda);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
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


        public string[] buscarVendaSelecionada(string codvenda)
        {
            SqlDataReader reader;
            string[] dados = new string[3];
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlExibirVendaSelecionada, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codvenda));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime dataDoBanco = reader.GetDateTime(0);
                    string dataFormatada = dataDoBanco.ToString("dd/MM/yyyy"); 
                    dados[0] = dataFormatada;
                    dados[1]=reader.GetString(1);
                    dados[2]=reader.GetString(2);
                    return dados;
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
            dados = null;
            return dados;
        }

        public DataTable pesquisaRealTime(string filtro, string pesquisa)
        {
            
            if (filtro == "sqlPesquisaVendasCliente")
            {
                
                filtro = sqlPesquisaVendasCliente;
                pesquisa = "%"+pesquisa+"%";
            }
            else if (filtro == "sqlPesquisaVendasData")
            {
              
                filtro = sqlPesquisaVendasData;
                pesquisa = "%" + pesquisa + "%";
            }
            else if (filtro == "sqlPesquisaVendasCod")
            {
                filtro = sqlPesquisaVendasCod;

            }
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            dtVendas = new DataTable();
            cmd = new SqlCommand(filtro, con);
       
            cmd.Parameters.AddWithValue("@param2", pesquisa);
            cmd.CommandType = CommandType.Text;
            con.Open();

            try
            {
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
            cmd.Parameters.AddWithValue("@codvenda",int.Parse(codvenda));
            cmd.Parameters.AddWithValue("@codprod",int.Parse(codproduto));
            cmd.Parameters.AddWithValue("@quant",int.Parse(quantidade));
            cmd.Parameters.AddWithValue("@valor",float.Parse(valor));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select p.codproduto as CÓDIGO, p.nomeproduto as PRODUTO, ivp.quantidade as QUANTIDADE," +
                                  "ivp.valor as VALOR,ivp.valor*ivp.quantidade as TOTAL from itensvendaproduto ivp join produto p on p.codproduto=ivp.codproduto_fk" +
                                  " join venda v on v.codvenda=ivp.codvenda_fk where codvenda_fk = @codvendaa order by p.nomeproduto";
                cmd.Parameters.AddWithValue("@codvendaa",codvenda);
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
