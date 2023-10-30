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
    public partial class Frm_Report_Trabalho : Form
    {
        public Frm_Report_Trabalho()
        {
            InitializeComponent();
        }

        private void Frm_Report_Trabalho_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'lojafunecDataSet3.trabalho'. Você pode movê-la ou removê-la conforme necessário.
            this.trabalhoTableAdapter.Fill(this.lojafunecDataSet3.trabalho);
            // TODO: esta linha de código carrega dados na tabela 'lojafunecDataSet3.trabalho'. Você pode movê-la ou removê-la conforme necessário.
            this.trabalhoTableAdapter.Fill(this.lojafunecDataSet3.trabalho);
            // TODO: esta linha de código carrega dados na tabela 'lojafunecDataSet3.trabalho'. Você pode movê-la ou removê-la conforme necessário.
            this.trabalhoTableAdapter.Fill(this.lojafunecDataSet3.trabalho);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
