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
    }
}
