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
    public partial class Frm_Trabalho : Form
    {
        public Frm_Trabalho()
        {
            InitializeComponent();
        }

        private void Frm_Trabalho_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Trabalho.carregarTrabalho();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Trabalho")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Trabalho";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Trabalho")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Trabalho.inserirTrabalho(textBox1.Text);
                }
                button1.Text = "Adcionar Trabalho";
                button4.Text = "Excluir Trabalho";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Trabalho")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir o Trabalho Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Trabalho.excluirTrabalho(cod);
                        MessageBox.Show("Trabalho Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Trabalho para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Trabalho";
                textBox1.Text = "";
                button1.Text = "Adcionar Trabalho";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["TRABALHO"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Trabalho frm = new Frm_Report_Trabalho();
            frm.ShowDialog();
        }
    }
}
