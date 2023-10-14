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
    public partial class DialogCriarVenda : Form
    {
        private Frm_Vendas frm_venda;
        private bool fecharForm = false;
        string codcliente;
        string nomefunc;
        string codfunc;
        public DialogCriarVenda(string nomefunc, string codfunc,Frm_Vendas vendas)
        {
            InitializeComponent();
            Txb_nomecliente.ReadOnly = true;
            Txb_noemfunc.ReadOnly = true;
            this.nomefunc = nomefunc;
            this.codfunc = codfunc;
            Txb_noemfunc.Text = nomefunc;
            frm_venda = vendas;
        }

        public void adicionarCliente(string nomecliente, string codcliente)
        {
            Txb_nomecliente.Text = nomecliente;
            this.codcliente = codcliente;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Txb_nomecliente.Text.Length >0)
            {
                C_Vendas vendas = new C_Vendas();
                int codvenda =vendas.criarVenda(codcliente, codfunc);
                frm_venda.vendaCriada(codvenda.ToString(),Txb_nomecliente.Text,Txb_noemfunc.Text);
                fecharForm = true;
                this.Close();
            }
            else if(Txb_nomecliente.Text == "")
            {
                MessageBox.Show("Selecione o Cliente para prosseguir!","ATENÇÃO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Txb_nomecliente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Txb_nomecliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (!checkBox1.Checked)
                {
                    DialogExibirClientes dialogExibirClientes = new DialogExibirClientes(this);
                    dialogExibirClientes.ShowDialog();
                }
            }
        }

        private void DialogCriarVenda_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                codcliente = "4";
                Txb_nomecliente.Text = "CONSUMIDOR";
            }
            else
            {
                codcliente = null;
                Txb_nomecliente.Text = "";
            }
        }

        private void DialogCriarVenda_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fecharForm)
            {
                DialogResult result = MessageBox.Show("Deseja abandonar Venda?", "ATENÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    fecharForm = true;
                    this.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
