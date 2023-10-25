using Loja_Unifunec.Controller;
using Loja_Unifunec.Views.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views
{
    public partial class Frm_Funcoes : Form
    {
        public Frm_Funcoes()
        {
            InitializeComponent();
        }

        private void Frm_Funcoes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Funcao.carregarFuncao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Função")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Função";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Função")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Funcao.inserirFuncao(textBox1.Text);
                }
                button1.Text = "Adcionar Função";
                button4.Text = "Excluir Função";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Função")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o Função Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Funcao.excluirFuncao(cod);
                        MessageBox.Show("Função Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Função para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Função";
                textBox1.Text = "";
                button1.Text = "Adcionar Função";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["FUNCAO"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Funcoes frm = new Frm_Report_Funcoes();
            frm.ShowDialog();
        }
    }
}
