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
    public static class C_Trabalho
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtTrabalho;

        static string sqlCarregarTrabalho = "select codtrabalho as CÓDIGO, nometrabalho as TRABALHO from trabalho order by codtrabalho";
        static string sqlInserirTrabalho = "insert into trabalho(nometrabalho) values(@param)";
        static string sqlExcluirTrabalho = "delete from trabalho where codtrabalho = @param";


        public static DataTable carregarTrabalho()
        {
            dtTrabalho = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarTrabalho, con);

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTrabalho);
                return dtTrabalho;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTrabalho = null;
            return dtTrabalho;
        }

        public static DataTable inserirRua(string nometrabalho)
        {
            dtTrabalho = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirTrabalho, con);
            cmd.Parameters.AddWithValue("@param", nometrabalho);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarTrabalho;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTrabalho);
                return dtTrabalho;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTrabalho = null;
            return dtTrabalho;
        }

        public static DataTable excluirTrabalho(string codtrabalho)
        {
            dtTrabalho = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirTrabalho, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codtrabalho));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarTrabalho;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTrabalho);
                return dtTrabalho;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTrabalho = null;
            return dtTrabalho;
        }

    }

}

