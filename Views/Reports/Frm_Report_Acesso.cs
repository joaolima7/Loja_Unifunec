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
    public partial class Frm_Report_Acesso : Form
    {
        public Frm_Report_Acesso()
        {
            InitializeComponent();
        }

        private void Frm_Report_Acesso_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'lojafunecDataSet1.acesso'. Você pode movê-la ou removê-la conforme necessário.
            this.acessoTableAdapter.Fill(this.lojafunecDataSet1.acesso);
            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
            
        }
    }
}
