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
    public partial class Frm_Marca : Form
    {
        public Frm_Marca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Marca")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Marca";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Marca")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Marca.inserirMarca(textBox1.Text);
                }
                button1.Text = "Adcionar Marca";
                button4.Text = "Excluir Marca";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Marca")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir a Marca Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Marca.excluirMarca(cod);
                        MessageBox.Show("Marca Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a Marca para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Marca";
                textBox1.Text = "";
                button1.Text = "Adcionar Marca";
            }
        }

        private void Frm_Marca_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Marca.carregarMarca();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["MARCA"].Value.ToString();
        }
    }
}
