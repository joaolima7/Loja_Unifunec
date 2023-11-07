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
    public partial class Frm_logs : Form
    {
        public Frm_logs()
        {
            InitializeComponent();
        }

        private void Frm_logs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = C_ControleLogs.carregarLogs();
        }
    }
}
