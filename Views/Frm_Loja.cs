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
    public partial class Frm_Loja : Form
    {
        public Frm_Loja()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Loja")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Loja";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Loja")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Loja.inserirLoja(textBox1.Text);
                }
                button1.Text = "Adcionar Loja";
                button4.Text = "Excluir Loja";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Loja")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir a Loja Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Loja.excluirLoja(cod);
                        MessageBox.Show("Loja Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a Loja para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Loja";
                textBox1.Text = "";
                button1.Text = "Adcionar Loja";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["LOJA"].Value.ToString();
        }

        private void Frm_Loja_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Loja.carregarLoja();
        }
    }
}
