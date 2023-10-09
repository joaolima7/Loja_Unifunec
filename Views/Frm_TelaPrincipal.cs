using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views
{
    public partial class Frm_TelaPrincipal : Form
    {

        bool closeForm = false;
        public Frm_TelaPrincipal()
        {
            InitializeComponent();
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Vendas vendas = new Frm_Vendas();
            vendas.MdiParent = this;
            vendas.Show();
        }

        private void Frm_TelaPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closeForm)
            {
                DialogResult result = MessageBox.Show("Deseja sair do Sistema?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela o fechamento do formulário
                }
                else
                {
                    closeForm = true; // Marca que o fechamento foi confirmado
                    Application.Exit(); // Fecha o aplicativo
                }
            }
        }
    }
}
