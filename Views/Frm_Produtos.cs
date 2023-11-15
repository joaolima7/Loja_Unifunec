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

            }
            else if (button4.Text == "Cancelar")
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
