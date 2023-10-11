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
        public Frm_Vendas()
        {
            InitializeComponent();
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
               DialogCriarVenda dialogCriarVenda = new DialogCriarVenda();
                dialogCriarVenda.ShowDialog();
            }
        }
    }
}
