using Loja_Unifunec.Controller;
using Loja_Unifunec.Views.Reports;
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

        private void bairrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Bairros)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Bairros))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Bairros novoFormulario = new Frm_Bairros();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void cEPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Cep)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Cep))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Cep novoFormulario = new Frm_Cep();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void funçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Funcoes)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Funcoes))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Funcoes novoFormulario = new Frm_Funcoes();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void lojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Loja)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Loja))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Loja novoFormulario = new Frm_Loja();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Marca)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Marca))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Marca novoFormulario = new Frm_Marca();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void operadorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Operadoras)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Operadoras))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Operadoras novoFormulario = new Frm_Operadoras();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void ruasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Rua)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Rua))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Rua novoFormulario = new Frm_Rua();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void tiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Tipos)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Tipos))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Tipos novoFormulario = new Frm_Tipos();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void tRabalhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Trabalho)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Trabalho))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Trabalho novoFormulario = new Frm_Trabalho();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void uFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Uf)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Uf))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Uf novoFormulario = new Frm_Uf();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void situaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Situacao)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Situacao))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Situacao novoFormulario = new Frm_Situacao();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void sexoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Sexo)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Sexo))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Sexo novoFormulario = new Frm_Sexo();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void cascataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Cidade)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Cidade))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Cidade novoFormulario = new Frm_Cidade();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void telefonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Telefones)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Telefones))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Telefones novoFormulario = new Frm_Telefones();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }

        private void loginsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (C_OpenForms.IsFormOpen(typeof(Frm_Cad_Login)))
            {
                // O formulário já está aberto, traga-o para a frente
                foreach (Form form in Application.OpenForms)
                {
                    if (form.GetType() == typeof(Frm_Cad_Login))
                    {
                        form.BringToFront();
                        return;
                    }
                }
            }
            else
            {
                // O formulário não está aberto, abra-o
                Frm_Cad_Login novoFormulario = new Frm_Cad_Login();
                novoFormulario.MdiParent = this;
                novoFormulario.Show();
            }
        }
    }
}
