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
    public partial class DialogInsereProdutoCOmpra : Form
    {
        private string codcompra;
        public DialogInsereProdutoCOmpra(string codcompra)
        {
            InitializeComponent();
            this.codcompra = codcompra;
        }

        private void DialogInsereProdutoCOmpra_Load(object sender, EventArgs e)
        {

        }
    }
}
