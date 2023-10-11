using Loja_Unifunec.Conection;
using Loja_Unifunec.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogExibirClientes : Form
    {
        C_Cliente c_Cliente = new C_Cliente();

        public DialogExibirClientes()
        {
            InitializeComponent();
        }

        private void DialogExibirClientes_Load(object sender, EventArgs e)
        {
            
            DataTable tb = new DataTable();
            tb = c_Cliente.carregarClientes();
            if (tb.Rows.Count >0)
            {
                dataGridView1.DataSource = tb;
            }
            else
            {

            }
        }

        private void Txb_nomecliente_TextChanged(object sender, EventArgs e)
        {
            string pesquisa = Txb_nomecliente.Text;

            dataGridView1.DataSource = c_Cliente.pesquisaRealTime(pesquisa);
        }
    }
}
