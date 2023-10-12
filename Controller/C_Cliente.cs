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
    internal class C_Cliente
    {

        SqlConnection con;
        SqlCommand cmd;
        DataTable dataTableClientes;
        string sqlCarregarClientes = "SELECT c.codcliente AS CÓDIGO, c.nomecliente AS CLIENTE,c.datanasc AS NASCIMENTO,s.nomesexo AS SEXO,r.nomerua AS RUA,b.nomebairro AS BAIRRO,ce.numerocep AS CEP,ci.nomecidade AS CIDADE,t.nometrabalho AS TRABALHO,c.numeroca AS NUMERO FROM cliente c JOIN sexo s ON s.codsexo = c.codsexo_fk JOIN rua r ON c.codrua_fk = r.codrua JOIN bairro b ON b.codbairro = c.codbairro_fk JOIN cep ce ON c.codcep_fk = ce.codcep JOIN cidade ci ON c.codcidade_fk = ci.codcidade JOIN trabalho t ON c.codtrabalho_fk = t.codtrabalho";



        public DataTable carregarClientes()
        {
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            dataTableClientes = new DataTable();

            cmd = new SqlCommand(sqlCarregarClientes, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableClientes); // Carregar dados diretamente no DataTable
                return dataTableClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return dataTableClientes;
        }

        public DataTable pesquisaRealTime(string nome)
        {
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            dataTableClientes = new DataTable();
            string sqlPesqRealTime = "SELECT c.codcliente AS CÓDIGO, c.nomecliente AS CLIENTE,c.datanasc AS NASCIMENTO,s.nomesexo AS SEXO,r.nomerua AS RUA,b.nomebairro AS BAIRRO,ce.numerocep AS CEP,ci.nomecidade AS CIDADE,t.nometrabalho AS TRABALHO,c.numeroca AS NUMERO FROM cliente c JOIN sexo s ON s.codsexo = c.codsexo_fk JOIN rua r ON c.codrua_fk = r.codrua JOIN bairro b ON b.codbairro = c.codbairro_fk JOIN cep ce ON c.codcep_fk = ce.codcep JOIN cidade ci ON c.codcidade_fk = ci.codcidade JOIN trabalho t ON c.codtrabalho_fk = t.codtrabalho where nomecliente like @nomecliente";

            cmd = new SqlCommand(sqlPesqRealTime, con);
            cmd.Parameters.AddWithValue("@nomecliente","%"+nome+"%");
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTableClientes); // Carregar dados diretamente no DataTable
                return dataTableClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return dataTableClientes;
        }
    }
}
