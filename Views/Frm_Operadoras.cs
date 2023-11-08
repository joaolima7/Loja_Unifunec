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
    public partial class Frm_Operadoras : Form
    {
        public Frm_Operadoras()
        {
            InitializeComponent();
        }

        private void Frm_Operadoras_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Operadora.carregarOperadoras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Operadora")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Operadora";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Operadora")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Operadora.inserirOperadora(textBox1.Text);
                }
                button1.Text = "Adcionar Operadora";
                button4.Text = "Excluir Operadora";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Operadora")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir a Operadora Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Operadora.excluirOperadora(cod);
                        MessageBox.Show("Operadora Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a Operadora para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Operadora";
                textBox1.Text = "";
                button1.Text = "Adcionar Operadora";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["OPERADORA"].Value.ToString();
        }
    }
}
