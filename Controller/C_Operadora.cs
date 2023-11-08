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
    public static class C_Operadora
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtOperad;
        

        static string sqlCarregarComboBox = "select * from operadora order by codoperadora";
        static string sqlExcluirOperadoras = "delete from operadora where codoperadora = @param";
        static string sqlInserirOperadoras = "insert into operadora(nomeoperadora) values(@param)";
        static string sqlCarregarOperadoras = "select codoperadora as CÓDIGO, nomeoperadora as OPERADORA from operadora order by codoperadora";

        public static List<Operadora> carregarOperadComboBox()
        {
            List<Operadora> listOperad = new List<Operadora>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarComboBox, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Operadora operadora = new Operadora();
                    operadora.Codoperadora = int.Parse(reader["codoperadora"].ToString());
                    operadora.Nomeoperadora = reader["nomeoperadora"].ToString();

                    listOperad.Add(operadora);
                }
                return listOperad;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            listOperad = null;
            return listOperad;
        }

        public static DataTable carregarOperadoras()
        {
            dtOperad = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarOperadoras, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtOperad);
                return dtOperad;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtOperad = null;
            return dtOperad;
        }

        public static DataTable inserirOperadora(string nomeoperadora)
        {
            dtOperad = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirOperadoras, con);
            cmd.Parameters.AddWithValue("@param", nomeoperadora);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarOperadoras;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtOperad);
                return dtOperad;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtOperad = null;
            return dtOperad;
        }

        public static DataTable excluirOperadora(string codoperad)
        {
            dtOperad = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirOperadoras, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codoperad));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarOperadoras;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtOperad);
                return dtOperad;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtOperad = null;
            return dtOperad;
        }

    }
}
