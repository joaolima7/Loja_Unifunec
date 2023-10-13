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
    public partial class Frm_Vendas : Form
    {
        public string usuario;
        public string codfunc;
        public Frm_Vendas(string func, string codfunc)
        {
            InitializeComponent();
            this.usuario = func;
            this.codfunc = codfunc;
        }

        private void Frm_Vendas_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja iniciar uma Venda?","VENDAS",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
               
               DialogCriarVenda dialogCriarVenda = new DialogCriarVenda(usuario,codfunc);
                dialogCriarVenda.ShowDialog();
            }
        }

        private void button1_EnabledChanged(object sender, EventArgs e)
        {
            if (button1.Enabled)
            {
                button1.Cursor = Cursors.Hand;
            }
            else
            {
                button1.Cursor = Cursors.Default;
            }
        }

        private void button2_EnabledChanged(object sender, EventArgs e)
        {
            if (button2.Enabled)
            {
                button2.Cursor = Cursors.Hand;
            }
            else
            {
                button2.Cursor = Cursors.Default;
            }
        }

        private void button3_EnabledChanged(object sender, EventArgs e)
        {
            if (button3.Enabled)
            {
                button3.Cursor = Cursors.Hand;
            }
            else
            {
                button3.Cursor = Cursors.Default;
            }
        }

        private void button4_EnabledChanged(object sender, EventArgs e)
        {
            if (button4.Enabled)
            {
                button4.Cursor = Cursors.Hand;
            }
            else
            {
                button4.Cursor = Cursors.Default;
            }
        }

        private void button5_EnabledChanged(object sender, EventArgs e)
        {
            if (button5.Enabled)
            {
                button5.Cursor = Cursors.Hand;
            }
            else
            {
                button5.Cursor = Cursors.Default;
            }
        }

        private void button6_EnabledChanged(object sender, EventArgs e)
        {
            if (button6.Enabled)
            {
                button6.Cursor = Cursors.Hand;
            }
            else
            {
                button6.Cursor = Cursors.Default;
            }
        }
    }
}
