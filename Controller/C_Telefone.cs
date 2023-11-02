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
    public static class C_Telefone
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtTelef;

        static string sqlCarregarTelef = "select t.codtelefone as CÓDIGO, t.numero as NUMERO, o.nomeoperadora as OPERADORA from telefone t join operadora o on t.codoperadora_fk=o.codoperadora order by t.codtelefone";
        static string sqlInserirTelef = "insert into telefone(numero, codoperadora_fk) values(@param, @param2)";

        public static DataTable carregarTelef()
        {
            dtTelef = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarTelef, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTelef);
                return dtTelef;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTelef = null;
            return dtTelef;
        }

        public static DataTable inserirTelef(string numero, string codoperadora)
        {
            dtTelef = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirTelef, con);
            cmd.Parameters.AddWithValue("@param", numero);
            cmd.Parameters.AddWithValue("@param2", int.Parse(codoperadora.ToString()));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarTelef;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtTelef);
                return dtTelef;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtTelef = null;
            return dtTelef;
        }


    }
}
