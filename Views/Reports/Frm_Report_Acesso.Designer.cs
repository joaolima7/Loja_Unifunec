namespace Loja_Unifunec.Views.Reports
{
    partial class Frm_Report_Acesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Report_Acesso));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lojafunecDataSet1 = new Loja_Unifunec.lojafunecDataSet1();
            this.acessoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.acessoTableAdapter = new Loja_Unifunec.lojafunecDataSet1TableAdapters.acessoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.acessoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.acessoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Loja_Unifunec.Views.Reports.Report_Acessos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(779, 568);
            this.reportViewer1.TabIndex = 0;
            // 
            // lojafunecDataSet1
            // 
            this.lojafunecDataSet1.DataSetName = "lojafunecDataSet1";
            this.lojafunecDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // acessoBindingSource
            // 
            this.acessoBindingSource.DataMember = "acesso";
            this.acessoBindingSource.DataSource = this.lojafunecDataSet1;
            // 
            // acessoTableAdapter
            // 
            this.acessoTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Report_Acesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 568);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Report_Acesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Acessos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Report_Acesso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.acessoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private lojafunecDataSet1 lojafunecDataSet1;
        private System.Windows.Forms.BindingSource acessoBindingSource;
        private lojafunecDataSet1TableAdapters.acessoTableAdapter acessoTableAdapter;
    }
}