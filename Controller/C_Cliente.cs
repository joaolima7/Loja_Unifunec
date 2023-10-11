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
    internal class C_Cliente
    {

        SqlConnection con;
        SqlCommand cmd;
        DataTable dataTableClientes;
        string sqlCarregarClientes = "select * from cliente";
        

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
            string sqlPesqRealTime = "select * from cliente where nomecliente like @nomecliente";

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
