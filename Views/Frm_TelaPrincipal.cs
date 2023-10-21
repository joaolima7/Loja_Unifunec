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

namespace Loja_Unifunec.Views
{
    public partial class Frm_TelaPrincipal : Form
    {

        bool closeForm = false;
        public string usuario;
        public string codfunc;
        public Frm_TelaPrincipal(string user, string coduser)
        {
            InitializeComponent();
            this.usuario = user;
            this.codfunc = coduser;
            label1.Text = usuario;
        }

        private void vendaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (C_OpenForms.IsFormOpen(typeof(Frm_Vendas)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Vendas))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Vendas novoFormulario = new Frm_Vendas(usuario, codfunc);
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
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

        private void Frm_TelaPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void acessosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Acesso)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Acesso))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Acesso novoFormulario = new Frm_Acesso();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }
    }
}
