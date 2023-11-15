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
    public partial class Frm_Produtos : Form
    {
        public Frm_Produtos()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Frm_Produtos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Produtos.carregarProdutos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Adicionar Produto")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button1.Text = "Salvar Produto";
                button4.Text = "Cancelar";
                button2.Enabled = false;
                dataGridView1.Enabled = false;
                textBox1.Focus();

                comboBox1.DataSource = C_Marca.carregarComboBoxMarca();
                comboBox1.ValueMember = "codmarca";
                comboBox1.DisplayMember = "nomemarca";
                comboBox2.DataSource = C_Tipo.carregarComboBoxTipo();
                comboBox2.ValueMember = "codtipo";
                comboBox2.DisplayMember = "nometipo";
            }
            else if (button1.Text == "Salvar Produto")
            {
                dataGridView1.Enabled = true;
                Produto prod = new Produto();
                prod.Marca = new Marca();
                prod.Tipo = new Tipo();
                prod.Tipo.Codtipo = int.Parse(comboBox2.SelectedValue.ToString());
                prod.Marca.Codmarca = int.Parse(comboBox1.SelectedValue.ToString());
                prod.Nomeproduto = textBox1.Text;
                prod.Quantidade = int.Parse(textBox2.Text);
                prod.Valor = int.Parse(textBox3.Text);
                dataGridView1.DataSource = C_Produtos.inserirProduto(prod);
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                button1.Text = "Adicionar Produto";
                button4.Text = "Excluir Produto";
                button2.Enabled = true;
                button1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Excluir Produto")
            {
                if (textBox1.Text != "")
                {
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string cod = row.Cells["CÓDIGO"].Value.ToString();
                    DialogResult res = MessageBox.Show("Deseja ecluir o Produto Cód. " + cod + " ?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        dataGridView1.DataSource = C_Produtos.excluirProduto(cod);
                        MessageBox.Show("Produto Cód. " + cod + " Excluido com Sucesso", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Selecione o Produto para Excluir!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (button4.Text == "Cancelar")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox1.DataSource = null;
                comboBox2.DataSource = null;
                button1.Text = "Adicionar Produto";
                button4.Text = "Excluir Produto";
                button2.Enabled = true;
                dataGridView1.Enabled = true;
                button1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            if (button2.Text == "Editar Produto")
            {
                if (textBox1.Text != "")
                {
                    button2.Text = "Salvar Edição";
                    button4.Text = "Cancelar";
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    dataGridView1.Enabled = false;
                    comboBox1.DataSource = C_Marca.carregarComboBoxMarca();
                    comboBox1.ValueMember = "codmarca";
                    comboBox1.DisplayMember = "nomemarca";
                    comboBox2.DataSource = C_Tipo.carregarComboBoxTipo();
                    comboBox2.ValueMember = "codtipo";
                    comboBox2.DisplayMember = "nometipo";
                    dataGridView1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Selecione um Produto para Editar!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else if (button2.Text == "Salvar Edição")
            {
                Produto prod = new Produto();
                prod.Marca = new Marca();
                prod.Tipo = new Tipo();
                prod.Tipo.Codtipo = int.Parse(comboBox2.SelectedValue.ToString());
                prod.Marca.Codmarca = int.Parse(comboBox1.SelectedValue.ToString());
                prod.Nomeproduto = textBox1.Text;
                prod.Quantidade = double.Parse(textBox2.Text);
                prod.Valor = double.Parse(textBox3.Text);
                prod.Codproduto = int.Parse(row.Cells["CÓDIGO"].Value.ToString());
                dataGridView1.DataSource = C_Produtos.editarProduto(prod);
                button2.Text = "Editar Produto";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                dataGridView1.Enabled = true;
                dataGridView1.Enabled = true;
                button4.Text = "Excluir Produto";

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["PRODUTO"].Value.ToString();
            textBox2.Text = row.Cells["ESTOQUE"].Value.ToString();
            textBox3.Text = row.Cells["VALOR"].Value.ToString();
            comboBox1.Text = row.Cells["MARCA"].Value.ToString();
            comboBox2.Text = row.Cells["TIPO"].Value.ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Produtos.pesquisaRealTime(textBox4.Text);
        }
    }
}
