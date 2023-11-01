using Loja_Unifunec.Controller;
using Loja_Unifunec.Model;
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
                button4.Text = "Cancelar";
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
                button4.Text = "Excluir Cidade";
                button4.Enabled = true;
                button2.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                button1.Focus();
            }
                
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["CIDADE"].Value.ToString();
            comboBox1.Text = row.Cells["ESTADO"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Cidade")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja excluir a Cidade Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Cidade.excluirCidade(cod);
                        MessageBox.Show("Cidade Cód. " + cod + " Excluida com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        comboBox1.Text= "";
                    }
                }
                else
                {
                    MessageBox.Show("Selecione a Cidade para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                button4.Text = "Excluir Cidade";
                button4.Text = "Editar Cidade";
                button2.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
                dataGridView1.Enabled = true;
                button1.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Editar Cidade")
            {
                if (textBox1.Text != "")
                {
                    dataGridView1.Enabled = false;
                    button1.Enabled = false;
                    button4.Enabled = false;
                    textBox1.Enabled = true;
                    comboBox1.Enabled = true;
                    button2.Text = "Salvar Edição";

                    List<Uf> ufs = new List<Uf>();
                    ufs = C_Uf.carregarComboBoxUf();
                    comboBox1.DataSource = ufs;
                    comboBox1.DisplayMember = "nomeuf";
                    comboBox1.ValueMember = "coduf";

                }
                else
                {
                    MessageBox.Show("Selecione a Cidade para Editar!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button2.Text == "Salvar Edição")
            {
                DataGridViewRow row = dataGridView1.CurrentRow;
                string cod = row.Cells["CÓDIGO"].Value.ToString();
                dataGridView1.DataSource = C_Cidade.editarCidade(textBox1.Text, comboBox1.SelectedValue.ToString(), cod);
                dataGridView1.Enabled = true;
                button1.Enabled = true;
                button4.Enabled = true;
                textBox1.Enabled = false;
                comboBox1.Enabled = false;
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Frm_Report_Cidade frm = new Frm_Report_Cidade();
            frm.ShowDialog();
        }
    }
    }

