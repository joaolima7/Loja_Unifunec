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
    public partial class Frm_Sexo : Form
    {
        public Frm_Sexo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Sexo")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Sexo";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Sexo")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Sexo.inserirSexo(textBox1.Text);
                }
                button1.Text = "Adcionar Sexo";
                button4.Text = "Excluir Sexo";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Sexo")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir o Sexo Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Sexo.excluirSexo(cod);
                        MessageBox.Show("Sexo Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Sexo para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Sexo";
                textBox1.Text = "";
                button1.Text = "Adcionar Sexo";
            }
        }

        private void Frm_Sexo_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Sexo.carregarSexo();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["SEXO"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Sexo frm = new Frm_Report_Sexo();
            frm.ShowDialog();
        }
    }
}
