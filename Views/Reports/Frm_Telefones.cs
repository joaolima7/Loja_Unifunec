using Loja_Unifunec.Controller;
using Loja_Unifunec.Model;
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

namespace Loja_Unifunec.Views.Reports
{
    public partial class Frm_Telefones : Form
    {
        public Frm_Telefones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Telefone")
            {
                button1.Text = "Salvar Telefone";
                List<Operadora> operadoras = new List<Operadora>();
                operadoras = C_Operadora.carregarOperadComboBox();
                comboBox1.DataSource = operadoras;
                comboBox1.DisplayMember = "nomeoperadora";
                comboBox1.ValueMember = "codoperadora";
                maskedTextBox1.Enabled = true;
                comboBox1.Enabled = true;
                button4.Text = "Cancelar";
                maskedTextBox1.Focus();
            }
            else if (button1.Text == "Salvar Telefone")
            {
                if (maskedTextBox1.Text.Length >= 11)
                {
                    dataGridView1.DataSource = C_Telefone.inserirTelef(maskedTextBox1.Text, comboBox1.SelectedValue.ToString());
                    button1.Text = "Adcionar Telefone";
                    maskedTextBox1.Enabled = false;
                    comboBox1.Enabled = false;
                    button4.Text = "Excluir Telefone";
                    button1.Focus();
                }
                else
                {
                    MessageBox.Show("Informe um numero de telefone!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    maskedTextBox1.Focus();
                }
            }  
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Cancelar")
            {
                maskedTextBox1.Enabled = true;
                comboBox1.Enabled = true;
                maskedTextBox1.Text = "";
                comboBox1.Text = "";
                button1.Text = "Adcionar Telefone";
                button4.Text = "Excluir Telefone";
            }
            else if (button4.Text == "Excluir Telefone")
            {
                if (maskedTextBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir o Telefone Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Telefone.excluirTelef(cod);
                        MessageBox.Show("Telefone Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Telefone para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Frm_Telefones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Telefone.carregarTelef();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            maskedTextBox1.Text = row.Cells["NUMERO"].Value.ToString();
            comboBox1.Text = row.Cells["OPERADORA"].Value.ToString();
        }
    }
}
