﻿using Loja_Unifunec.Conection;
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
    public static class C_Cidade 
    {

        static Conexao conection = new Conexao();
        static SqlConnection con;
        static SqlCommand cmd;
        static DataTable dtCidades;

        static string sqlCarregarCidades = "select c.codcidade as CÓDIGO, c.nomecidade as CIDADE, uf.nomeuf as ESTADO, uf.sigla as SIGLA from cidade c join uf on c.coduf_fk=uf.coduf order by codcidade";
        static string sqlInserirCidade = "insert into cidade(nomecidade, coduf_fk) values(@param, @param2)";
        static string sqlExcluirCidade = "delete from cidade where codcidade = @param";
        static string sqlCarregarCidadesCb = "select * from cidade order by nomecidade";
        static string sqlEditarCidade = "update cidade set nomecidade = @param, coduf_fk = @param2 where codcidade = @param3";
        public static DataTable carregarCidades()
        {
            dtCidades = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarCidades, con);
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCidades);
                return dtCidades;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCidades = null;
            return dtCidades;
        }

        public static DataTable inserirCidade(string nomecidade, string coduf)
        {
            dtCidades = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlInserirCidade, con);
            cmd.Parameters.AddWithValue("@param", nomecidade);
            cmd.Parameters.AddWithValue("@param2", int.Parse(coduf));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarCidades;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCidades);
                return dtCidades;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCidades = null;
            return dtCidades;
        }

        public static DataTable editarCidade(string nomecidade, string coduf, string codcidade)
        {
            dtCidades = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlEditarCidade, con);
            cmd.Parameters.AddWithValue("@param", nomecidade);
            cmd.Parameters.AddWithValue("@param2", int.Parse(coduf));
            cmd.Parameters.AddWithValue("@param3", int.Parse(codcidade));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarCidades;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCidades);
                return dtCidades;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCidades = null;
            return dtCidades;
        }

        public static DataTable excluirCidade(string codcidade)
        {
            dtCidades = new DataTable();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlExcluirCidade, con);
            cmd.Parameters.AddWithValue("@param", int.Parse(codcidade));
            cmd.CommandType = CommandType.Text;

            con.Open();

            try
            {

                cmd.ExecuteNonQuery();

                cmd.CommandText = sqlCarregarCidades;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtCidades);
                return dtCidades;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            dtCidades = null;
            return dtCidades;
        }

        public static List<Cidade> carregarComboBoxCidade()
        {
            List<Cidade> cdds = new List<Cidade>();
            con = conection.conectaSQL();
            cmd = new SqlCommand(sqlCarregarCidadesCb, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;

            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Cidade cidade = new Cidade();

                    cidade.Codcidade = int.Parse(reader["codcidade"].ToString());
                    cidade.Nomecidade = reader["nomecidade"].ToString();

                    cdds.Add(cidade);

                }
                return cdds;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro com o Banco de Dados\n" + ex.ToString());
            }
            finally
            {
                con.Close();
            }
            cdds = null;
            return cdds;
        }



    }
}
