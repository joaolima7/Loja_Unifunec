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
    public static class C_Marca
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtMarca;

        static string sqlCarregarMarca = "select codmarca as CÓDIGO, nomemarca as MARCA from marca order by codmarca";
        static string sqlInserirMarca = "insert into marca(nomemarca) values(@param)";
        static string sqlBuscarMarcaCb = "select * from marca order by nomemarca";
        static string sqlExcluirMarca = "delete from marca where codmarca = @param";


        public static DataTable carregarMarca()
        {
            dtMarca = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarMarca, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMarca);
                return dtMarca;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtMarca = null;
            return dtMarca;
        }

        public static List<Marca> carregarComboBoxMarca()
        {
            List<Marca> marcas = new List<Marca>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlBuscarMarcaCb, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Marca m = new Marca();

                    m.Codmarca = int.Parse(reader["codmarca"].ToString());
                    m.Nomemarca = reader["nomemarca"].ToString();

                    marcas.Add(m);

                }
                return marcas;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return marcas;
        }

        public static DataTable inserirMarca(string nomemarca)
        {
            dtMarca = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirMarca, con);
            cmd.Parameters.AddWithValue("@param", nomemarca);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarMarca;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMarca);
                return dtMarca;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtMarca = null;
            return dtMarca;
        }

        public static DataTable excluirMarca(string codmarca)
        {
            dtMarca = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirMarca, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codmarca));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarMarca;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtMarca);
                return dtMarca;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtMarca = null;
            return dtMarca;
        }

    }
}
