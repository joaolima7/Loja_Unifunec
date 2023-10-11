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


        public DialogExibirClientes()
        {
            InitializeComponent();
        }

        private void DialogExibirClientes_Load(object sender, EventArgs e)
        {
            C_Cliente c_Cliente = new C_Cliente();
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
    }
}
