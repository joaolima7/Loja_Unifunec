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
    public static class C_Situacao
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtSituacao;

        static string sqlCarregarSituacao = "select codsituacao as CÓDIGO, nomesituacao as SITUACAO from situacao order by codsituacao";
        static string sqlInserirSituacao = "insert into situacao(nomesituacao) values(@param)";
        static string sqlExcluirSituacao = "delete from situacao where codsituacao = @param";


        public static DataTable carregarSituacao()
        {
            dtSituacao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarSituacao, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSituacao);
                return dtSituacao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSituacao = null;
            return dtSituacao;
        }

        public static DataTable inserirSituacao(string nomesituacao)
        {
            dtSituacao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirSituacao, con);
            cmd.Parameters.AddWithValue("@param", nomesituacao);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarSituacao;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSituacao);
                return dtSituacao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSituacao = null;
            return dtSituacao;
        }

        public static DataTable excluirSituacao(string codsituacao)
        {
            dtSituacao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirSituacao, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codsituacao));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarSituacao;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSituacao);
                return dtSituacao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSituacao = null;
            return dtSituacao;
        }

    }
}
