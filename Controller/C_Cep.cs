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
    public static class C_Cep
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtCep;

        static string sqlCarregarCep = "select codcep as CÓDIGO, numerocep as CEP from cep";
        static string sqlInserirCep = "insert into cep(numerocep) values(@param)";
        static string sqlExcluirCep = "delete from cep where codcep = @param";

        public static DataTable carregarCep()
        {
            dtCep = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarCep, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCep);
                return dtCep;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCep = null;
            return dtCep;
        }


        public static DataTable inserirCep(string numcep)
        {
            dtCep = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirCep, con);
            cmd.Parameters.AddWithValue("@param", numcep);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarCep;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCep);
                return dtCep;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCep = null;
            return dtCep;
        }

        public static DataTable excluirCep(string codcep)
        {
            dtCep = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirCep, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codcep));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarCep;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCep);
                return dtCep;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCep = null;
            return dtCep;
        }

    }
}
