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

            }
            else if (button1.Text == "Salvar Cidade")
            {
                button1.Text = "Adcionar Cidade";
                button4.Enabled=true;
                button2.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button1.Focus();
            }
        }
    }
}
