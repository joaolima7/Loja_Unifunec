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
        public Frm_Cad_Login()
        {
            InitializeComponent();
        }

        private void Frm_Cad_Login_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Login.carregarLogins();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adcionar Login")
            {
                List<Funcionario> funcionarios = new List<Funcionario>();
                funcionarios = C_Funcionario.carregarComboBoxFunc();
                comboBox1.DataSource = funcionarios;
                comboBox1.ValueMember = "codfuncionario";
                comboBox1.DisplayMember = "nomefuncionario";

                button1.Text = "Salvar Login";
                button4.Text = "Cancelar";
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
                    dataGridView1.DataSource = C_Login.inserirLogin(textBox1.Text, textBox2.Text, comboBox1.SelectedValue.ToString());
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
            if (button4.Text == "Excluir Login")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir o Login Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Login.excluirLogin(cod);
                        MessageBox.Show("Login Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        comboBox1.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Login para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                button1.Text = "Adcionar Login";
                button4.Text = "Excluir Login";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button2.Enabled = true;
                comboBox1.Enabled = false;
                button1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Editar Login")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.Enabled = false;
                    button1.Enabled = false;
                    button4.Enabled = false;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    comboBox1.Enabled = true;
                    button2.Text = "Salvar Edição";

                    List<Funcionario> funcionarios = new List<Funcionario>();
                    funcionarios = C_Funcionario.carregarComboBoxFunc();
                    comboBox1.DataSource = funcionarios;
                    comboBox1.ValueMember = "codfuncionario";
                    comboBox1.DisplayMember = "nomefuncionario";

                }
                else
                {
                    MessageBox.Show("Selecione o Login para Editar!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button2.Text == "Salvar Edição")
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                string cod = row.Cells["CÓDIGO"].Value.ToString();
                dataGridView1.DataSource = C_Login.editarLogin(textBox1.Text, textBox2.Text ,comboBox1.SelectedValue.ToString(), cod);
                dataGridView1.Enabled = true;
                button2.Text = "Editar Login";
                button1.Enabled = true;
                button4.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["USUÁRIO"].Value.ToString();
            textBox2.Text = row.Cells["SENHA"].Value.ToString();
            comboBox1.Text = row.Cells["FUNCIONÁRIO"].Value.ToString();
        }
    }
}
