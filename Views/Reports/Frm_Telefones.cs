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

        }

        private void Frm_Telefones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Telefone.carregarTelef();
        }
    }
}
