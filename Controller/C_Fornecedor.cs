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
    public static class C_Fornecedor
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtForn;

        static String sqlCarregarForn = "select f.codfornecedor as CÓDIGO, f.nomefornecedor as FORNECEDOR, f.numerocasa as NUMERO, r.nomerua as RUA, b.nomebairro as BAIRRO, c.numerocep as CEP, cdd.nomecidade as CIDADE from fornecedor f join rua r on r.codrua = f.codrua_fk join bairro b on b.codbairro = f.codbairro_fk join cep c on c.codcep = f.codcep_fk join cidade cdd on cdd.codcidade = f.codcidade_fk order by codfornecedor";
        static String sqlInserirForn = "insert into fornecedor(nomefornecedor, numerocasa, codrua_fk, codbairro_fk, codcep_fk, codcidade_fk) values(@p1, @p2, @p3, @p4, @p5, @p6)";
        public static DataTable carregarFornecedores()
        {
            dtForn = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarForn, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtForn);
                return dtForn;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtForn = null;
            return dtForn;
        }


        public static DataTable inserirFornecedor(object obj)
        {
            Fornecedor forn = new Fornecedor();
            forn = (Fornecedor)obj;
            dtForn = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirForn, con);
            cmd.Parameters.AddWithValue("@p1", forn.Nomefornecedor);
            cmd.Parameters.AddWithValue("@p2", forn.Numerocasa);
            cmd.Parameters.AddWithValue("@p3", forn.Rua.Codrua);
            cmd.Parameters.AddWithValue("@p4", forn.Bairro.Codbairro);
            cmd.Parameters.AddWithValue("@p5", forn.Cep.Codcep);
            cmd.Parameters.AddWithValue("@p6", forn.Cidade.Codcidade);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarForn;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtForn);
                return dtForn;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtForn = null;
            return dtForn;
        }


    }
}
