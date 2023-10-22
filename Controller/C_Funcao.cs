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
    public static class C_Funcao
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtFuncao;

        static string sqlCarregarFuncao = "select codfuncao as CÓDIGO, nomefuncao as FUNCAO from funcao order by codfuncao";
        static string sqlInserirFuncao = "insert into funcao(nomefuncao) values(@param)";
        static string sqlExcluirFuncao = "delete from funcao where codfuncao = @param";

        public static DataTable carregarFuncao()
        {
            dtFuncao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarFuncao, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFuncao);
                return dtFuncao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtFuncao = null;
            return dtFuncao;
        }

        public static DataTable inserirFuncao(string nomefuncao)
        {
            dtFuncao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirFuncao, con);
            cmd.Parameters.AddWithValue("@param", nomefuncao);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarFuncao;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFuncao);
                return dtFuncao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtFuncao = null;
            return dtFuncao;
        }

        public static DataTable excluirFuncao(string codfuncao)
        {
            dtFuncao = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirFuncao, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codfuncao));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarFuncao;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFuncao);
                return dtFuncao;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtFuncao = null;
            return dtFuncao;
        }


    }
}
