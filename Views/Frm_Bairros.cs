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
    public partial class Frm_Bairros : Form
    {
        public Frm_Bairros()
        {
            InitializeComponent();
        }

        private void Frm_Bairros_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Bairro.carregarBairros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Bairro")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Bairro";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
            }
            else if (button1.Text == "Salvar Bairro")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Bairro.inserirBairro(textBox1.Text);
                }
                button1.Text = "Adcionar Bairro";
                button4.Text = "Excluir Bairro";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Bairro")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o Bairro Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Bairro.excluirBairro(cod);
                        MessageBox.Show("Bairro Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Bairro para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Bairro";
                textBox1.Text = "";
                button1.Text = "Adcionar Bairro";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["BAIRRO"].Value.ToString();
        }
    }
}
