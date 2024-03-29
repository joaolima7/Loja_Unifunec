﻿using Loja_Unifunec.Controller;
using Loja_Unifunec.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Loja_Unifunec.Views
{
    public partial class Frm_Fornecedores : Form
    {
        public Frm_Fornecedores()
        {
            InitializeComponent();
        }

        private void Frm_Fornecedores_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Fornecedor.carregarFornecedores();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Fornecedor")
            {
                List<Rua> ruas = new List<Rua>();
                List<Cep> ceps = new List<Cep>();
                List<Bairro> bairros = new List<Bairro>();
                List<Cidade> cdds = new List<Cidade>();

                ruas = C_Rua.carregarComboBoxRua();
                bairros = C_Bairro.carregarComboBoxBairro();
                ceps = C_Cep.carregarComboBoxCep();
                cdds = C_Cidade.carregarComboBoxCidade();

                comboBox1.DataSource = ruas;
                comboBox1.ValueMember = "codrua";
                comboBox1.DisplayMember = "nomerua";

                comboBox2.DataSource = bairros;
                comboBox2.ValueMember = "codbairro";
                comboBox2.DisplayMember = "nomebairro";

                comboBox3.DataSource = ceps;
                comboBox3.ValueMember = "codcep";
                comboBox3.DisplayMember = "numerocep";

                comboBox4.DataSource = cdds;
                comboBox4.ValueMember = "codcidade";
                comboBox4.DisplayMember = "nomecidade";


                textBox1.Text = "";
                comboBox1.Text = "";
                textBox3.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                button1.Text = "Salvar Fornecedor";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                textBox3.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                dataGridView1.Enabled = false;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Fornecedor")
            {
                if (textBox1.Text != "" && textBox3.Text != "")
                {
                    Fornecedor forn = new Fornecedor();
                    forn.Cep = new Cep();
                    forn.Cidade = new Cidade();
                    forn.Bairro = new Bairro();
                    forn.Rua = new Rua();
                    forn.Nomefornecedor = textBox1.Text;
                    forn.Numerocasa = int.Parse(textBox3.Text);
                    forn.Rua.Codrua = int.Parse(comboBox1.SelectedValue.ToString());
                    forn.Bairro.Codbairro = int.Parse(comboBox2.SelectedValue.ToString());
                    forn.Cep.Codcep = int.Parse(comboBox3.SelectedValue.ToString());
                    forn.Cidade.Codcidade = int.Parse(comboBox4.SelectedValue.ToString());

                    dataGridView1.DataSource = C_Fornecedor.inserirFornecedor(forn); 

                }
                button1.Text = "Adcionar Fornecedor";
                button4.Text = "Excluir Fornecedor";
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                dataGridView1.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Fornecedor")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir o Fornecedor Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Fornecedor.excluirFornecedor(cod);
                        MessageBox.Show("Fornecedor Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        textBox3.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";
                        comboBox4.Text = "";
                    }
                }
            }
            else if (button4.Text == "Cancelar")
            {
                button1.Text = "Adcionar Fornecedor";
                button4.Text = "Excluir Fornecedor";
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                textBox3.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                dataGridView1.Enabled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["FORNECEDOR"].Value.ToString();
            comboBox1.Text = row.Cells["RUA"].Value.ToString();
            textBox3.Text = row.Cells["NUMERO"].Value.ToString();
            comboBox2.Text = row.Cells["BAIRRO"].Value.ToString();
            comboBox3.Text = row.Cells["CEP"].Value.ToString();
            comboBox4.Text = row.Cells["CIDADE"].Value.ToString();
        }
    }
}
