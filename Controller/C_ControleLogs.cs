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
    public static class C_ControleLogs
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtLogs;

        static string sqlCarregarLogs = "select l.usuario as USUÁRIO, c.datalog as DATA, c.horalog as HORA, c.descricao as DESCRIÇÃO from controlelogsistema c join login l on l.codlogin = c.codlogin_fk order by c.codcontrole";
        static string sqlInserirLogs = "insert into controlelogsistema(codlogin_fk, descricao, datalog, horalog) values(@param, @param2, getdate(), getdate())";

        public static DataTable carregarLogs()
        {
            dtLogs = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarLogs, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLogs);
                return dtLogs;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLogs = null;
            return dtLogs;
        }

        public static void inserirLog(string codlogin, string descricao)
        {
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarLogs, con);
            cmd.Parameters.AddWithValue("@param", codlogin);
            cmd.Parameters.AddWithValue("@param2", descricao);
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
