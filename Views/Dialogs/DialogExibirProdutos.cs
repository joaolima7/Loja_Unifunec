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
    }
}
