namespace Loja_Unifunec.Views.Reports
{
    partial class Frm_Report_Sexo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Report_Sexo));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lojafunecDataSet3 = new Loja_Unifunec.lojafunecDataSet3();
            this.sexoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sexoTableAdapter = new Loja_Unifunec.lojafunecDataSet3TableAdapters.sexoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sexoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Loja_Unifunec.Views.Reports.Report_Sexos.rdlc";
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
            // sexoBindingSource
            // 
            this.sexoBindingSource.DataMember = "sexo";
            this.sexoBindingSource.DataSource = this.lojafunecDataSet3;
            // 
            // sexoTableAdapter
            // 
            this.sexoTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Report_Sexo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Report_Sexo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatórios de Sexos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Report_Sexo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lojafunecDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private lojafunecDataSet3 lojafunecDataSet3;
        private System.Windows.Forms.BindingSource sexoBindingSource;
        private lojafunecDataSet3TableAdapters.sexoTableAdapter sexoTableAdapter;
    }
}