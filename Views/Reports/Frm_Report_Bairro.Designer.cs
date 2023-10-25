namespace Loja_Unifunec.Views.Reports
{
    partial class Frm_Report_Bairro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Report_Bairro));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lojafunecDataSet3 = new Loja_Unifunec.lojafunecDataSet3();
            this.lojafunecDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bairroBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bairroTableAdapter = new Loja_Unifunec.lojafunecDataSet3TableAdapters.bairroTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bairroBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bairroBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.bairroBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Loja_Unifunec.Views.Reports.Report_Bairros.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // lojafunecDataSet3
            // 
            this.lojafunecDataSet3.DataSetName = "lojafunecDataSet3";
            this.lojafunecDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lojafunecDataSet3BindingSource
            // 
            this.lojafunecDataSet3BindingSource.DataSource = this.lojafunecDataSet3;
            this.lojafunecDataSet3BindingSource.Position = 0;
            // 
            // bairroBindingSource
            // 
            this.bairroBindingSource.DataMember = "bairro";
            this.bairroBindingSource.DataSource = this.lojafunecDataSet3BindingSource;
            // 
            // bairroTableAdapter
            // 
            this.bairroTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Report_Bairro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Report_Bairro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Bairros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Report_Bairro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bairroBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private lojafunecDataSet3 lojafunecDataSet3;
        private System.Windows.Forms.BindingSource lojafunecDataSet3BindingSource;
        private System.Windows.Forms.BindingSource bairroBindingSource;
        private lojafunecDataSet3TableAdapters.bairroTableAdapter bairroTableAdapter;
    }
}