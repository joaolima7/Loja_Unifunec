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
    public partial class Frm_Cad_Login : Form
    {
        C_Login login = new C_Login();
        public Frm_Cad_Login()
        {
            InitializeComponent();
        }

        private void Frm_Cad_Login_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = login.carregarLogins();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Login")
            {
                List<Funcionario> funcionarios = new List<Funcionario>();

                button1.Text = "Salvar Login";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                comboBox1.Enabled = true;
                button2.Enabled = false;
                textBox1.Focus();
            }
            else if (button1.Text == "Salvar Login")
            {
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    dataGridView1.DataSource = login.inserirLogin(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString());
                    button1.Text = "Adcionar Login";
                    button4.Text = "Excluir Login";
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    button2.Enabled = true;
                    comboBox1.Enabled = false;
                    button1.Focus();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
