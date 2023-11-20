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
        private Compra compraAtual = new Compra();
        private Login login = new Login();
        public Frm_Compras(string user, string codfunc, string nomefunc)
        {
            InitializeComponent();
            login.Usuario = user;
            login.Funcionario = new Funcionario();
            login.Funcionario.Codfuncionario = int.Parse(codfunc);
            login.Funcionario.Nomefuncionario = nomefunc;

        }

        //Abaixo são métodos 

        private void clearFields()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            lbl_codCompra.Text = "-";
            lbl_dataCompra.Text = "__/__/____";
        }

        public void compraCreated(Compra compra)
        {
            compraAtual.Codcompra = compra.Codcompra;
            compraAtual.Datacompra = DateTime.Now.ToString("dd/MM/yyyy");
            compraAtual.Funcionario = new Funcionario();
            compraAtual.Fornecedor = new Fornecedor();
            compraAtual.Funcionario.Nomefuncionario = login.Funcionario.Nomefuncionario;
            compraAtual.Funcionario.Codfuncionario = login.Funcionario.Codfuncionario;
            compraAtual.Fornecedor.Nomefornecedor = compra.Fornecedor.Nomefornecedor;
            compraAtual.Fornecedor.Codfornecedor = compra.Fornecedor.Codfornecedor;

            lbl_codCompra.Text = compraAtual.Codcompra.ToString();
            lbl_dataCompra.Text = compraAtual.Datacompra;
            textBox1.Text = compraAtual.Fornecedor.Nomefornecedor;
            textBox2.Text = compraAtual.Funcionario.Nomefuncionario;
        }





        //Abaixo são eventos do formulário
        private void Frm_Compras_Load(object sender, EventArgs e)
        {

        }

        private void btn_inserir_compra_Click(object sender, EventArgs e)
        {
            //clearFields();
            DialogCriarCompra frm = new DialogCriarCompra(this, login);
            frm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null)
            {
                btn_excluir_compra.Enabled = true;
                btn_editar_compra.Enabled = true;
                btn_editar_parcelas.Enabled = true;
                btn_insere_prods.Enabled = true;
            }
            else if(textBox1.Text == string.Empty)
            {
                btn_excluir_compra.Enabled = false;
                btn_editar_compra.Enabled = false;
                btn_editar_parcelas.Enabled = false;
                btn_insere_prods.Enabled = false;
            }
        }

        private void btn_insere_prods_Click(object sender, EventArgs e)
        {
            DialogInsereProdutoCOmpra frm = new DialogInsereProdutoCOmpra(compraAtual.Codcompra.ToString());
            frm.ShowDialog();
        }
    }
}
