using Loja_Unifunec.Conection;
using Loja_Unifunec.Controller;
using Loja_Unifunec.Model;
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
        private DialogCriarVenda dCV;

        public DialogExibirClientes(DialogCriarVenda dCV)
        {
            InitializeComponent();
            this.dCV = dCV;
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



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                // Obtém o valor da coluna "CODIGO" da linha selecionada
                var codigoValue = selectedRow.Cells["CÓDIGO"].Value.ToString();
                var nomeValue = selectedRow.Cells["CLIENTE"].Value.ToString();
                dCV.adicionarCliente(nomeValue, codigoValue);
                this.Close();
            }
        }

        private void DialogExibirClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Txb_nomecliente_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void Txb_nomecliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridView dataGridView = (DataGridView)sender; // Obtém o DataGridView atual
                if (dataGridView.CurrentRow != null)
                {
                    DataGridViewRow selectedRow = dataGridView.CurrentRow;
                    // Obtém o valor da coluna "CÓDIGO" da linha selecionada
                    var codigoValue = selectedRow.Cells["CÓDIGO"].Value.ToString();
                    var nomeValue = selectedRow.Cells["CLIENTE"].Value.ToString();
                    dCV.adicionarCliente(nomeValue, codigoValue);
                    this.Close();
                }
            }
        }
    }
}
