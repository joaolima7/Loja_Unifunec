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
    public static class C_Loja
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtLoja;

        static string sqlCarregarLoja = "select codloja as CÓDIGO, nomeloja as LOJA from loja order by codloja";
        static string sqlInserirLoja = "insert into loja(nomeloja) values(@param)";
        static string sqlExcluirLoja = "delete from loja where codloja = @param";

        public static DataTable carregarLoja()
        {
            dtLoja = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarLoja, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLoja);
                return dtLoja;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLoja = null;
            return dtLoja;
        }

        public static DataTable inserirLoja(string nomeloja)
        {
            dtLoja = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirLoja, con);
            cmd.Parameters.AddWithValue("@param", nomeloja);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarLoja;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLoja);
                return dtLoja;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLoja = null;
            return dtLoja;
        }

        public static DataTable excluirLoja(string codloja)
        {
            dtLoja = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirLoja, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codloja));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarLoja;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLoja);
                return dtLoja;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLoja = null;
            return dtLoja;
        }

    }
}
