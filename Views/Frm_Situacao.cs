using Loja_Unifunec.Controller;
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
    public partial class Frm_Situacao : Form
    {
        public Frm_Situacao()
        {
            InitializeComponent();
        }

        private void Frm_Situacao_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Situacao.carregarSituacao();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Situação")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Situação";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Situação")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Situacao.inserirSituacao(textBox1.Text);
                }
                button1.Text = "Adcionar Situação";
                button4.Text = "Excluir Situação";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Situação")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir a Situação Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Situacao.excluirSituacao(cod);
                        MessageBox.Show("Situação Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a Situação para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Situação";
                textBox1.Text = "";
                button1.Text = "Adcionar Situação";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["SITUACAO"].Value.ToString();
        }
    }
}
