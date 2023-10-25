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
    public partial class Frm_Acesso : Form
    {
        public Frm_Acesso()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text== "Excluir Acesso")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o Acesso Cód. "+cod+" ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Acesso.excluirAcessos(cod);
                        MessageBox.Show("Acesso Cód. "+cod+" Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Acesso para Excluir!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text=="Cancelar")
            {
                textBox1.Enabled = false;
                button4.Text = "Excluir Acesso";
                textBox1.Text = "";
                button1.Text = "Adcionar Acesso";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text== "Adcionar Acesso")
            {
                textBox1.Text = "";
                button1.Text = "Salvar Acesso";
                button4.Text = "Cancelar";
                textBox1.Enabled = true;
            }
            else if (button1.Text == "Salvar Acesso")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.DataSource = C_Acesso.inserirAcessos(textBox1.Text);
                }
                button1.Text = "Adcionar Acesso";
                button4.Text = "Excluir Acesso";
                textBox1.Enabled = false;
            }
        }

        private void Frm_Acesso_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Acesso.carregarAcessos();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["ACESSO"].Value.ToString();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {

                // O formulário não está aberto, abra-o
                Frm_Report_Acesso novoFormulario = new Frm_Report_Acesso();
                novoFormulario.ShowDialog();
            
        }
    }
}
