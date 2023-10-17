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

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogExibirProdutos : Form
    {
        C_Produtos c_Produtos = new C_Produtos();
        Frm_Vendas frm_vendas;
        public DialogExibirProdutos(Frm_Vendas frm)
        {
            InitializeComponent();
            this.frm_vendas = frm;
        }

        private void DialogExibirProdutos_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = c_Produtos.carregarProdutos();
            if (tb.Rows.Count > 0)
            {
                dataGridView1.DataSource = tb;
            }
            else
            {

            }
        }

        private void DialogExibirProdutos_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender; // Obtém o DataGridView atual
            if (dataGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = dataGridView.CurrentRow;
                var codigoProd = selectedRow.Cells["CÓDIGO"].Value.ToString();
                var nomeProd = selectedRow.Cells["PRODUTO"].Value.ToString();
                frm_vendas.adicionaProd(codigoProd, nomeProd);
                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridView dataGridView = (DataGridView)sender; // Obtém o DataGridView atual
                if (dataGridView.CurrentRow != null)
                {
                    DataGridViewRow selectedRow = dataGridView.CurrentRow;
                    var codigoProd = selectedRow.Cells["CÓDIGO"].Value.ToString();
                    var nomeProd = selectedRow.Cells["PRODUTO"].Value.ToString();
                    frm_vendas.adicionaProd(codigoProd,nomeProd);
                    this.Close();
                }
            }
        }
    }
}
