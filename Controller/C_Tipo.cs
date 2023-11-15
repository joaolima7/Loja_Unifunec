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
    public static class C_Tipo
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtTipo;

        static string sqlCarregarTipo = "select codtipo as CÓDIGO, nometipo as TIPO from tipo order by codtipo";
        static string sqlInserirTipo = "insert into tipo(nometipo) values(@param)";
        static string sqlCarregarTipoCb = "select * from tipo order by nometipo";
        static string sqlExcluirTipo = "delete from tipo where codtipo = @param";


        public static DataTable carregarTipo()
        {
            dtTipo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarTipo, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTipo);
                return dtTipo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTipo = null;
            return dtTipo;
        }

        public static DataTable inserirTipo(string nometipo)
        {
            dtTipo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirTipo, con);
            cmd.Parameters.AddWithValue("@param", nometipo);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarTipo;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTipo);
                return dtTipo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTipo = null;
            return dtTipo;
        }

        public static DataTable excluirTipo(string codtipo)
        {
            dtTipo = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirTipo, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codtipo));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarTipo;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTipo);
                return dtTipo;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTipo = null;
            return dtTipo;
        }


        public static List<Tipo> carregarComboBoxTipo()
        {
            List<Tipo> tipos = new List<Tipo>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarTipoCb, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Tipo t = new Tipo();

                    t.Codtipo = int.Parse(reader["codtipo"].ToString());
                    t.Nometipo = reader["nometipo"].ToString();

                    tipos.Add(t);

                }
                return tipos;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return tipos;
        }

    }
}
