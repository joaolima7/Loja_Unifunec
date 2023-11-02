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
    }
}
