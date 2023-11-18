using Loja_Unifunec.Model;
using Loja_Unifunec.Views.Dialogs;
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
    public partial class Frm_Compras : Form
    {
        private Compra purchaseCurrent;
        public Frm_Compras()
        {
            InitializeComponent();
        }

        //Abaixo são métodos 

        private void clearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            lbl_codVenda.Text = "-";
            lbl_dataVenda.Text = "__/__/____";
        }

        private void purchaseCreated(Compra compra)
        {
            purchaseCurrent.Codcompra = compra.Codcompra;
            purchaseCurrent.Datacompra = compra.Datacompra;
            purchaseCurrent.Funcionario = compra.Funcionario;
            purchaseCurrent.Fornecedor = compra.Fornecedor;
        }





        //Abaixo são eventos do formulário
        private void Frm_Compras_Load(object sender, EventArgs e)
        {

        }

        private void btn_inserir_compra_Click(object sender, EventArgs e)
        {
            clearFields();
            DialogCriarCompra frm = new DialogCriarCompra();
            frm.ShowDialog();
        }
    }
}
