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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Loja_Unifunec.Views.Dialogs
{
    public partial class DialogCriarCompra : Form
    {
        private Frm_Compras frm_compras;
        private Login login = new Login();
        private Fornecedor forn = new Fornecedor();

        public DialogCriarCompra(Frm_Compras compras, Login login)
        {
            InitializeComponent();
            this.frm_compras = compras;
            this.login.Codlogin = login.Codlogin;
            this.login.Usuario = login.Usuario;
            Txb_nomefunc.Text = login.Usuario;
        }
        //DAQUI PRA BAIXO SÃO MÉTODOS

        public void addForn(Fornecedor forn)
        {
            this.forn.Codfornecedor = forn.Codfornecedor;
            this.forn.Nomefornecedor = forn.Nomefornecedor;
            Txb_nomeforn.Text = this.forn.Nomefornecedor;
        }





        //DAQUI PRA BAIXO SÃO EVENTOS
        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Fornecedores frm = new Frm_Fornecedores();
            frm.ShowDialog();
        }
        private void Txb_nomeforn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                DialogExibirFonecedores frm = new DialogExibirFonecedores(this);
                frm.ShowDialog();
            }
        }


       
    }
}
