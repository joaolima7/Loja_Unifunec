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
    public static class C_Uf
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtUf;

        static string sqlCarregarUf = "select coduf as CÓDIGO, nomeuf as UF, sigla as SIGLA from uf order by coduf";
        static string sqlInserirUf = "insert into uf(nomeuf, sigla) values(@param, @param2)";
        static string sqlExcluirUf = "delete from uf where coduf = @param";


        public static DataTable carregarUf()
        {
            dtUf = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarUf, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtUf);
                return dtUf;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtUf = null;
            return dtUf;
        }

        public static DataTable inserirUf(string nomeuf, string sigla)
        {
            dtUf = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirUf, con);
            cmd.Parameters.AddWithValue("@param", nomeuf);
            cmd.Parameters.AddWithValue("@param2", sigla);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarUf;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtUf);
                return dtUf;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtUf = null;
            return dtUf;
        }

        public static DataTable excluirUf(string coduf)
        {
            dtUf = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirUf, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(coduf));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarUf;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtUf);
                return dtUf;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtUf = null;
            return dtUf;
        }

    }

}
