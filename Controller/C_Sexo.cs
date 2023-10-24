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
    public static class C_Sexo
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtSexo;

        static string sqlCarregarSexo = "select codsexo as CÓDIGO, nomesexo as SEXO from sexo order by codsexo";
        static string sqlInserirSexo = "insert into sexo(nomesexo) values(@param)";
        static string sqlExcluirSexo = "delete from sexo where codsexo = @param";


        public static DataTable carregarSexo()
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarSexo, con);
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

        public static DataTable inserirSexo(string nomemarca)
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirSexo, con);
            cmd.Parameters.AddWithValue("@param", nomemarca);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarSexo;
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

        public static DataTable excluirSexo(string codsexo)
        {
            dtSexo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirSexo, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codsexo));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarSexo;
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
