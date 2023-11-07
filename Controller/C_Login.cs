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
    static class C_Login
    {
         static Conexao conection = new Conexao();
         static SqlConnection con;
         static SqlCommand cmd;
         static DataTable dtLogins;

        static string sqlBuscarLogin = "select * from login where usuario = @User and senha = @Password";
        static string sqlExcluirLogin = "delete from login where codlogin = @param";
        static string sqlInserirLogin = "insert into login(usuario, senha, codfuncionario_fk) values(@param, @param2, @param3)";
        static string sqlCarregarLogin = "select l.codlogin as CÓDIGO, l.usuario as USUÁRIO, l.senha as SENHA, f.nomefuncionario as FUNCIONÁRIO from login l join funcionario f on f.codfuncionario=l.codfuncionario_fk order by l.codlogin";
        static string sqlEditarLogin = "update login set usuario = @param, senha = @param2, codfuncionario_fk = @param3 where codlogin = @param4";

        public static void buscarLogin(string usuario, string senha)
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
                    string codlogin = reader["codlogin"].ToString();
                    string nomeuser = reader["usuario"].ToString();
                    Frm_TelaPrincipal tela = new Frm_TelaPrincipal(nomeuser, codfunc);
                    C_ControleLogs.inserirLog(codlogin,"LOGIN NO SISTEMA");
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


        public static DataTable carregarLogins()
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

        public static DataTable inserirLogin(string usuario, string senha, string codfuncionario)
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

        public static DataTable excluirLogin(string codlogin)
        {
            dtLogins = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirLogin, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codlogin));
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

        public static DataTable editarLogin(string usuario, string senha, string codfunc, string codlogin)
        {
            dtLogins = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlEditarLogin, con);
            cmd.Parameters.AddWithValue("@param", usuario);
            cmd.Parameters.AddWithValue("@param2", senha);
            cmd.Parameters.AddWithValue("@param3", int.Parse(codfunc));
            cmd.Parameters.AddWithValue("@param4", int.Parse(codlogin));
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
