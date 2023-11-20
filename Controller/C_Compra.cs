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
    public static class C_Compra
    {
        static Conexao cn = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtCompras;


        static String sqlInserirCompra = "insert into compra(datacompra, codfornecedor_fk, codfuncionario_fk) values(getdate(), @p1, @p2)";



        public static int criarCompra(string codforn, string codfunc)
        {
            int codcompra = -1;
            con = cn.conectaSQL();
            cmd = new SqlCommand(sqlInserirCompra, con);
            cmd.Parameters.AddWithValue("@p1", codforn);
            cmd.Parameters.AddWithValue("@p2", codfunc);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(codcompra) FROM compra";
                codcompra = Convert.ToInt32(cmd.ExecuteScalar());

                return codcompra;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return codcompra;

        }



    }
}
