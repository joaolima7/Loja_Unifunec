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
    public partial class Frm_Tipos : Form
    {
        public Frm_Tipos()
        {
            InitializeComponent();
        }

        private void Frm_Tipos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Tipo.carregarTipo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Tipo")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Tipo";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Tipo")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Tipo.inserirTipo(textBox1.Text);
                }
                button1.Text = "Adcionar Tipo";
                button4.Text = "Excluir Tipo";
                textBox1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Tipo")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o Tipo Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Tipo.excluirTipo(cod);
                        MessageBox.Show("Tipo Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Tipo para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Tipo";
                textBox1.Text = "";
                button1.Text = "Adcionar Tipo";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["TIPO"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Tipo frm = new Frm_Report_Tipo();
            frm.ShowDialog();
        }
    }
}
