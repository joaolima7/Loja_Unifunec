using Loja_Unifunec.Conection;
using Loja_Unifunec.Views;
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
    internal class C_Login
    {

        SqlConnection con;
        SqlCommand cmd;

        string sqlBuscarLogin = "select * from login where usuario = @User and senha = @Password";
        string sqlBuscarFunc = "select * from funcionario where codfuncionario = @codfunc";

        public void buscarLogin(string usuario, string senha)
        {
            Conexao conexao = new Conexao();
            con = conexao.conectaSQL();
            cmd = new SqlCommand(sqlBuscarLogin,con);

            cmd.Parameters.AddWithValue("@User", usuario);
            cmd.Parameters.AddWithValue("@Password", senha);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string codfunc = reader["codfuncionario_fk"].ToString();
                    string nomeuser = reader["usuario"].ToString();
                    Frm_TelaPrincipal tela = new Frm_TelaPrincipal(nomeuser, codfunc);
                    reader.Close();
                    tela.Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou Senha Incorretos!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n"+ex.ToString());
            }
            finally
            {
                con.Close();
                
            }
        }
    }
}
