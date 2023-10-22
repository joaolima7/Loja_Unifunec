using Loja_Unifunec.Conection;
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
    public static class C_Acesso
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtAcesso;

        static string sqlCarregarAcesso = "select codacesso as CÓDIGO, nomeacesso as ACESSO from acesso";
        static string sqlInserirAcesso = "insert into acesso(nomeacesso) values(@param)";
        static string sqlExcluirAcesso = "delete from acesso where codacesso = @param";

        public static DataTable carregarAcessos()
        {
            dtAcesso = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarAcesso, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAcesso);
                return dtAcesso;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtAcesso = null;
            return dtAcesso;
        }

        public static DataTable inserirAcessos(string nomeacesso)
        {
            dtAcesso = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirAcesso, con);
            cmd.Parameters.AddWithValue("@param", nomeacesso);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarAcesso;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAcesso);
                return dtAcesso;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtAcesso = null;
            return dtAcesso;
        }

        public static DataTable excluirAcessos(string codacesso)
        {
            dtAcesso = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirAcesso, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codacesso));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarAcesso;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtAcesso);
                return dtAcesso;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtAcesso = null;
            return dtAcesso;
        }

    }
}
