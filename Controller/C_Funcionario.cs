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
    public static class C_Funcionario
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtFunc;

        static string sqlCarregarCbFunc = "select * from funcionario order by nomefuncionario";
        
        public static List<Funcionario> carregarComboBoxFunc()
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarCbFunc, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Funcionario func = new Funcionario();

                    func.Codfuncionario = int.Parse(reader["codfuncionario"].ToString());
                    func.Nomefuncionario = reader["nomefuncionario"].ToString();

                    funcionarios.Add(func);

                }
                return funcionarios;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return funcionarios;
        }
    }
}
