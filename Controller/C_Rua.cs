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
    public static class C_Rua
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtSexo;

        static string sqlCarregarRua = "select codrua as CÓDIGO, nomerua as RUA from rua order by codrua";
        static string sqlInserirRua = "insert into rua(nomerua) values(@param)";
        static string sqlExcluirRua = "delete from rua where codrua = @param";


        public static DataTable carregarRua()
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarRua, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSexo);
                return dtSexo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSexo = null;
            return dtSexo;
        }

        public static DataTable inserirRua(string nomerua)
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirRua, con);
            cmd.Parameters.AddWithValue("@param", nomerua);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarRua;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSexo);
                return dtSexo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSexo = null;
            return dtSexo;
        }

        public static DataTable excluirRua(string codrua)
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirRua, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codrua));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarRua;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtSexo);
                return dtSexo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtSexo = null;
            return dtSexo;
        }

    }

}

