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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogInsereProdutoCOmpra : Form
    {
        private Frm_Compras frm_compras;
        DataTable dt = new DataTable();
        private string codcompra;
        private string codprod;
        public DialogInsereProdutoCOmpra(string codcompra,string nomeforn, Frm_Compras frm)
        {
            InitializeComponent();
            this.codcompra = codcompra;
            this.frm_compras = frm;
            lbl_Forn.Text = nomeforn;
            lbl_codCompra.Text = codcompra;
        }

        private void clearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
        }

        private void DialogInsereProdutoCOmpra_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Produtos.carregarProdutos();
        }

        private void lbl_codCompra_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Produtos.pesquisaRealTime(textBox4.Text, "sqlPesquisaRealTimeProd");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["PRODUTO"].Value.ToString();
            codprod = row.Cells["CÓDIGO"].Value.ToString();
            textBox3.Text = row.Cells["VALOR"].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                
                dt = C_Compra.insereVendaProduto(codcompra,codprod,textBox2.Text, textBox3.Text);
                MessageBox.Show("Produto Inserido!!", "ÊXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
                if (dt != null)
                {
                    frm_compras.dtProdutosInseridos(dt);
                }


            }
            else
            {
                MessageBox.Show("Selecione um Produto e Quantidade!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void DialogInsereProdutoCOmpra_FormClosed(object sender, FormClosedEventArgs e)
        {

            
        }
    }
}
