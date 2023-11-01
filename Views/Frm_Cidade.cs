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

namespace Loja_Unifunec.Views
{
    public partial class Frm_Cidade : Form
    {
        public Frm_Cidade()
        {
            InitializeComponent();
        }

        private void Frm_Cidade_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Cidade.carregarCidades();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Cidade")
            {
                button1.Text = "Salvar Cidade";
                button4.Enabled = false;
                button2.Enabled = false;
                textBox1.Enabled = true;
                comboBox1.Enabled = true;
                textBox1.Focus();

                List<Uf> ufs = new List<Uf>();
                ufs = C_Uf.carregarComboBoxUf();
                comboBox1.DataSource = ufs;
                comboBox1.DisplayMember = "nomeuf";
                comboBox1.ValueMember = "coduf";


            }
            else if (button1.Text == "Salvar Cidade")
            {
                dataGridView1.DataSource = C_Cidade.inserirCidade(textBox1.Text, comboBox1.SelectedValue.ToString());
                button1.Text = "Adcionar Cidade";
                button4.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button1.Focus();
            }
                
            }
        }
    }

