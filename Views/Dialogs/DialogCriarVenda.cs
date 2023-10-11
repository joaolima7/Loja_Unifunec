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
    public partial class DialogCriarVenda : Form
    {
        public DialogCriarVenda()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            C_Vendas vendas = new C_Vendas();
            vendas.criarVenda(Txb_nomecliente.Text, Txb_noemfunc.Text);
        }

        private void Txb_nomecliente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txb_nomecliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {       
                DialogExibirClientes dialogExibirClientes = new DialogExibirClientes();
                dialogExibirClientes.ShowDialog();
            }
        }
    }
}
