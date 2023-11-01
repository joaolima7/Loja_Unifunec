namespace Loja_Unifunec.Views.Reports
{
    partial class Frm_Report_Cidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Report_Cidade));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lojafunecDataSet4 = new Loja_Unifunec.lojafunecDataSet4();
            this.vCidadeUfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.v_CidadeUfTableAdapter = new Loja_Unifunec.lojafunecDataSet4TableAdapters.V_CidadeUfTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCidadeUfBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vCidadeUfBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Loja_Unifunec.Views.Reports.Report_Cidades.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // lojafunecDataSet4
            // 
            this.lojafunecDataSet4.DataSetName = "lojafunecDataSet4";
            this.lojafunecDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vCidadeUfBindingSource
            // 
            this.vCidadeUfBindingSource.DataMember = "V_CidadeUf";
            this.vCidadeUfBindingSource.DataSource = this.lojafunecDataSet4;
            // 
            // v_CidadeUfTableAdapter
            // 
            this.v_CidadeUfTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Report_Cidade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Report_Cidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Cidades";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Report_Cidade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vCidadeUfBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private lojafunecDataSet4 lojafunecDataSet4;
        private System.Windows.Forms.BindingSource vCidadeUfBindingSource;
        private lojafunecDataSet4TableAdapters.V_CidadeUfTableAdapter v_CidadeUfTableAdapter;
    }
}