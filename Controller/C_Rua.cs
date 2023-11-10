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
    public static class C_Rua
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtSexo;

        static string sqlCarregarRua = "select codrua as CÓDIGO, nomerua as RUA from rua order by codrua";
        static string sqlCarregarRuaCb = "select * from rua order by nomerua";
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

        public static List<Rua> carregarComboBoxRua()
        {
            List<Rua> ruas = new List<Rua>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarRuaCb, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rua rua = new Rua();

                    rua.Codrua = int.Parse(reader["codrua"].ToString());
                    rua.Nomerua = reader["nomerua"].ToString();

                    ruas.Add(rua);

                }
                return ruas;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            ruas = null;
            return ruas;
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

