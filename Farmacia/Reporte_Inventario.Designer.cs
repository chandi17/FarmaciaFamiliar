namespace Farmacia
{
    partial class Reporte_Inventario
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btnfiltrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PA_reporteinv1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetInventario = new Farmacia.DataSetInventario();
            this.dataSetInventarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pAreporteinv1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pA_reporteinv1TableAdapter = new Farmacia.DataSetInventarioTableAdapters.PA_reporteinv1TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.PA_reporteinv1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAreporteinv1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnfiltrar
            // 
            this.btnfiltrar.Location = new System.Drawing.Point(722, 69);
            this.btnfiltrar.Name = "btnfiltrar";
            this.btnfiltrar.Size = new System.Drawing.Size(96, 40);
            this.btnfiltrar.TabIndex = 4;
            this.btnfiltrar.Tag = "";
            this.btnfiltrar.Text = "Buscar";
            this.btnfiltrar.UseVisualStyleBackColor = true;
            this.btnfiltrar.Click += new System.EventHandler(this.btnfiltrar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(824, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 40);
            this.button1.TabIndex = 5;
            this.button1.Tag = "";
            this.button1.Text = "Borrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(220, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre del producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(444, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 69);
            this.label2.TabIndex = 7;
            this.label2.Text = "Inventario";
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.reportViewer1.DocumentMapWidth = 70;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.PA_reporteinv1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Farmacia.InfromeInventario.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 125);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1121, 601);
            this.reportViewer1.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(474, 88);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 22);
            this.textBox1.TabIndex = 9;
            // 
            // PA_reporteinv1BindingSource
            // 
            this.PA_reporteinv1BindingSource.DataMember = "PA_reporteinv1";
            this.PA_reporteinv1BindingSource.DataSource = this.dataSetInventario;
            // 
            // dataSetInventario
            // 
            this.dataSetInventario.DataSetName = "DataSetInventario";
            this.dataSetInventario.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetInventarioBindingSource
            // 
            this.dataSetInventarioBindingSource.DataSource = this.dataSetInventario;
            this.dataSetInventarioBindingSource.Position = 0;
            // 
            // pAreporteinv1BindingSource
            // 
            this.pAreporteinv1BindingSource.DataMember = "PA_reporteinv1";
            this.pAreporteinv1BindingSource.DataSource = this.dataSetInventario;
            // 
            // pA_reporteinv1TableAdapter
            // 
            this.pA_reporteinv1TableAdapter.ClearBeforeFill = true;
            // 
            // Reporte_Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(1028, 615);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnfiltrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reporte_Inventario";
            this.Text = "Reporte_Inventario";
            this.Load += new System.EventHandler(this.Reporte_Inventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PA_reporteinv1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetInventarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pAreporteinv1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnfiltrar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource pAreporteinv1BindingSource;
        private DataSetInventario dataSetInventario;
        private System.Windows.Forms.BindingSource dataSetInventarioBindingSource;
        private DataSetInventarioTableAdapters.PA_reporteinv1TableAdapter pA_reporteinv1TableAdapter;
        private System.Windows.Forms.BindingSource PA_reporteinv1BindingSource;
        private System.Windows.Forms.TextBox textBox1;
    }
}