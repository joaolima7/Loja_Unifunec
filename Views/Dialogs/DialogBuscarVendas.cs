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

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogBuscarVendas : Form
    {
        C_Vendas c_vendas = new C_Vendas();
        Frm_Vendas vendas;
        public DialogBuscarVendas(Frm_Vendas frm)
        {
            InitializeComponent();
            vendas = frm;
        }

        private void DialogBuscarVendas_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = c_vendas.buscarVendas();
            if (tb.Rows.Count > 0)
            {
                dataGridView1.DataSource = tb;
            }
            else
            {

            }
        }

        private void Txb_nomecliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txb_venda_TextChanged(object sender, EventArgs e)
        {
             if (comboBox1.Text == "Nome Cliente")
            {
                string pesquisa = Txb_venda.Text;

                dataGridView1.DataSource = c_vendas.pesquisaRealTime("sqlPesquisaVendasCliente", pesquisa);
            }
            else if (comboBox1.Text == "Data Venda")
            {
                string pesquisa = Txb_venda.Text;

                dataGridView1.DataSource = c_vendas.pesquisaRealTime("sqlPesquisaVendasData", pesquisa);
            }
            else if (comboBox1.Text == "Cód. Venda")
            {
                string pesquisa = Txb_venda.Text;

                dataGridView1.DataSource = c_vendas.pesquisaRealTime("sqlPesquisaVendasCod",pesquisa);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                var codigoValue = selectedRow.Cells["CÓDIGO"].Value.ToString();
                vendas.carregaVenda(codigoValue);
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewRow selectedRow = dataGridView1.CurrentRow;
                    var codigoValue = selectedRow.Cells["CÓDIGO"].Value.ToString();
                    vendas.carregaVenda(codigoValue);
                    this.Close();
                }
            }
        }
    }
}
