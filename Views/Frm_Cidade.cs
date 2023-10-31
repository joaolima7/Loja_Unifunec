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
    public partial class Frm_Cidade : Form
    {
        public Frm_Cidade()
        {
            InitializeComponent();
        }

        private void Frm_Cidade_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_Cidade.carregarCidades();
        }
    }
}
