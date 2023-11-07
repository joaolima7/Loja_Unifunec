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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "HORA")
                {
                    if (e.Value != null && e.Value is TimeSpan)
                    {
                        e.Value = ((TimeSpan)e.Value).ToString("hh\\:mm\\:ss");
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
