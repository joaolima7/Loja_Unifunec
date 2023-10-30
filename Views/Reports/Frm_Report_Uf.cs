using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views.Reports
{
    public partial class Frm_Report_Uf : Form
    {
        public Frm_Report_Uf()
        {
            InitializeComponent();
        }

        private void Frm_Report_Uf_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'lojafunecDataSet3.uf'. Você pode movê-la ou removê-la conforme necessário.
            this.ufTableAdapter.Fill(this.lojafunecDataSet3.uf);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
