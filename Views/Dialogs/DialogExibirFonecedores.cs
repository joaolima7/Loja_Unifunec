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
    public partial class DialogExibirFonecedores : Form
    {

        private DialogCriarCompra dCC;

        public DialogExibirFonecedores(DialogCriarCompra dCC)
        {
            InitializeComponent();
            this.dCC = dCC;
        }

        private void DialogExibirFonecedores_Load(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            tb = C_Fornecedor.carregarFornecedores();
            if (tb.Rows.Count > 0)
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
                var codigoForn = selectedRow.Cells["CÓDIGO"].Value.ToString();
                var nomeForn = selectedRow.Cells["FORNECEDOR"].Value.ToString();
                Fornecedor forn = new Fornecedor();
                forn.Codfornecedor = int.Parse(codigoForn);
                forn.Nomefornecedor = nomeForn;
                dCC.addForn(forn);
                this.Close();
            }
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
                    var codigoForn = selectedRow.Cells["CÓDIGO"].Value.ToString();
                    var nomeForn = selectedRow.Cells["FORNECEDOR"].Value.ToString();
                    Fornecedor forn = new Fornecedor();
                    forn.Codfornecedor = int.Parse(codigoForn);
                    forn.Nomefornecedor = nomeForn;
                    dCC.addForn(forn);
                    this.Close();
                }
            }
        }
    }
}
