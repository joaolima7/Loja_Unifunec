using Loja_Unifunec.Conection;
using Loja_Unifunec.Model;
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
         Conexao conection = new Conexao();
         SqlConnection con;
         SqlCommand cmd;
         DataTable dtLogins;

        string sqlBuscarLogin = "select * from login where usuario = @User and senha = @Password";
        string sqlInserirLogin = "insert into login(usuario, senha, codfuncionario_fk) values(@param, @param2, @param3)";
        string sqlCarregarLogin = "select l.codlogin as CÓDIGO, l.usuario as USUÁRIO, l.senha as SENHA, f.nomefuncionario as FUNCIONÁRIO from login l join funcionario f on f.codfuncionario=l.codfuncionario_fk order by l.codlogin";
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


        public DataTable carregarLogins()
        {
            dtLogins = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarLogin, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLogins);
                return dtLogins;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLogins = null;
            return dtLogins;
        }

        public DataTable inserirLogin(string usuario, string senha, string codfuncionario)
        {
            dtLogins = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirLogin, con);
            cmd.Parameters.AddWithValue("@param", usuario);
            cmd.Parameters.AddWithValue("@param2", senha);
            cmd.Parameters.AddWithValue("@param3", int.Parse(codfuncionario));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarLogin;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtLogins);
                return dtLogins;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtLogins = null;
            return dtLogins;
        }

    }
}
