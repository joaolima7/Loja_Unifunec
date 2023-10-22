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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Loja_Unifunec.Views
{
    public partial class Frm_Cep : Form
    {
        public Frm_Cep()
        {
            InitializeComponent();
        }

        private void Frm_Cep_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Cep.carregarCep();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar CEP")
            {
                maskedTextBox1.Text = "";
                button1.Text = "Salvar CEP";
                button4.Text = "Cancelar";
                maskedTextBox1.Enabled = true;
            }
            else if (button1.Text == "Salvar CEP")
            {
                if (maskedTextBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Cep.inserirCep(maskedTextBox1.Text);
                }
                button1.Text = "Adcionar CEP";
                button4.Text = "Excluir CEP";
                maskedTextBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir CEP")
            {
                if (maskedTextBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o CEP Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Cep.excluirCep(cod);
                        MessageBox.Show("CEP Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o CEP para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                maskedTextBox1.Enabled = false;
                button4.Text = "Excluir CEP";
                maskedTextBox1.Text = "";
                button1.Text = "Adcionar CEP";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            maskedTextBox1.Text = row.Cells["CEP"].Value.ToString();
        }
    }
}
