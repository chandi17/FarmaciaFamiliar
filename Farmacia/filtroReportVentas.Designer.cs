namespace Farmacia
{
    partial class filtroReportVentas
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
            this.reportventasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReporteVenta = new Farmacia.DataSetReporteVenta();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtpfecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpfecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnfiltrar = new System.Windows.Forms.Button();
            this.reportventasTableAdapter = new Farmacia.DataSetReporteVentaTableAdapters.reportventasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reportventasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporteVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // reportventasBindingSource
            // 
            this.reportventasBindingSource.DataMember = "reportventas";
            this.reportventasBindingSource.DataSource = this.dataSetReporteVenta;
            // 
            // dataSetReporteVenta
            // 
            this.dataSetReporteVenta.DataSetName = "DataSetReporteVenta";
            this.dataSetReporteVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reportventasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Farmacia.InformeReporteVenta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(847, 621);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dtpfecha1
            // 
            this.dtpfecha1.CustomFormat = "yyyy-MM-dd";
            this.dtpfecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfecha1.Location = new System.Drawing.Point(9, 37);
            this.dtpfecha1.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfecha1.Name = "dtpfecha1";
            this.dtpfecha1.Size = new System.Drawing.Size(198, 20);
            this.dtpfecha1.TabIndex = 1;
            this.dtpfecha1.ValueChanged += new System.EventHandler(this.dtpfecha1_ValueChanged);
            // 
            // dtpfecha2
            // 
            this.dtpfecha2.CustomFormat = "yyyy-MM-dd";
            this.dtpfecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfecha2.Location = new System.Drawing.Point(225, 37);
            this.dtpfecha2.Margin = new System.Windows.Forms.Padding(2);
            this.dtpfecha2.Name = "dtpfecha2";
            this.dtpfecha2.Size = new System.Drawing.Size(198, 20);
            this.dtpfecha2.TabIndex = 2;
            this.dtpfecha2.Value = new System.DateTime(2022, 3, 29, 23, 59, 0, 0);
            // 
            // btnfiltrar
            // 
            this.btnfiltrar.Location = new System.Drawing.Point(435, 31);
            this.btnfiltrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnfiltrar.Name = "btnfiltrar";
            this.btnfiltrar.Size = new System.Drawing.Size(72, 32);
            this.btnfiltrar.TabIndex = 3;
            this.btnfiltrar.Tag = "";
            this.btnfiltrar.Text = "Filtrar";
            this.btnfiltrar.UseVisualStyleBackColor = true;
            this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
            // 
            // reportventasTableAdapter
            // 
            this.reportventasTableAdapter.ClearBeforeFill = true;
            // 
            // filtroReportVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(847, 621);
            this.Controls.Add(this.btnfiltrar);
            this.Controls.Add(this.dtpfecha2);
            this.Controls.Add(this.dtpfecha1);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "filtroReportVentas";
            this.Text = "filtroReportVentas";
            this.Load += new System.EventHandler(this.filtroReportVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportventasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporteVenta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dtpfecha1;
        private System.Windows.Forms.DateTimePicker dtpfecha2;
        private System.Windows.Forms.Button btnfiltrar;
        private System.Windows.Forms.BindingSource reportventasBindingSource;
        private DataSetReporteVenta dataSetReporteVenta;
        private DataSetReporteVentaTableAdapters.reportventasTableAdapter reportventasTableAdapter;
    }
}