using Loja_Unifunec.Conection;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja_Unifunec.Views.Reports
{
    public partial class Frm_Report_Produtos : Form
    {
        string sql;
        public Frm_Report_Produtos(string sql)
        {
            InitializeComponent();
            this.sql = sql;
        }

        private void Frm_Report_Produtos_Load(object sender, EventArgs e)
        {
            DataTable dtProd = new DataTable();
            Conexao con = new Conexao();
            DataSet ds = new DataSet("ds");

            // Passo 2: Configurar o DataSource do ReportViewer
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource("dtProd", ds.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Passo 3: Escrever a Query Personalizada

            // Passo 4: Preencher a DataTable com os Dados
            using (SqlConnection connection = con.conectaSQL())
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(this.sql, connection);
                adapter.Fill(ds, "dtProd");
            }

            // Passo 5: Configurar o ReportViewer
            reportViewer1.RefreshReport();
        }
    }
}
