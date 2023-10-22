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
    public static class C_Bairro
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtBairros;

        static string sqlCarregarBairro = "select codbairro as CÓDIGO, nomebairro as BAIRRO from bairro order by codbairro";
        static string sqlInserirBairro = "insert into bairro(nomebairro) values(@param)";
        static string sqlExcluirBairro = "delete from bairro where codbairro = @param";

        public static DataTable carregarBairros()
        {
            dtBairros = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarBairro, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtBairros);
                return dtBairros;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtBairros = null;
            return dtBairros;
        }

        public static DataTable inserirBairro(string nomebairro)
        {
            dtBairros = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirBairro, con);
            cmd.Parameters.AddWithValue("@param", nomebairro);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarBairro;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtBairros);
                return dtBairros;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtBairros = null;
            return dtBairros;
        }

        public static DataTable excluirBairro(string codbairro)
        {
            dtBairros = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirBairro, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codbairro));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarBairro;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtBairros);
                return dtBairros;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtBairros = null;
            return dtBairros;
        }

    }
}
