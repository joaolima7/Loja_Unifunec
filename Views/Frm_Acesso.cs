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
                   DialogResult res = MessageBox.Show("Deseja ecluir o Acesso?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        //C_Acesso.
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Acesso para Excluir!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text=="Cancelar")
            {
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
                button4.Enabled = false;
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
                button4.Enabled = false;
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
    }
}
