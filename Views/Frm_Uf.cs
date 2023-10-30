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
    public partial class Frm_Uf : Form
    {
        public Frm_Uf()
        {
            InitializeComponent();
        }

        private void Frm_Uf_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Uf.carregarUf();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar UF")
            {
                textBox1.Text = "";
                button1.Text = "Salvar UF";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar UF")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Uf.inserirUf(textBox1.Text,textBox2.Text);
                }
                button1.Text = "Adcionar UF";
                button4.Text = "Excluir UF";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir UF")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir a UF Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Uf.excluirUf(cod);
                        MessageBox.Show("UF Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a UF para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button4.Text = "Excluir UF";
                textBox1.Text = "";
                textBox2.Text = "";
                button1.Text = "Adcionar UF";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["UF"].Value.ToString();
            textBox2.Text = row.Cells["SIGLA"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Uf frm = new Frm_Report_Uf();
            frm.ShowDialog();
        }
    }
}
