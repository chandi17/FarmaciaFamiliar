
namespace Farmacia
{
    partial class reporteventa
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
            this.dtreporteventas = new System.Windows.Forms.DateTimePicker();
            this.btnverreporteventas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtreporteventas
            // 
            this.dtreporteventas.Location = new System.Drawing.Point(212, 123);
            this.dtreporteventas.Name = "dtreporteventas";
            this.dtreporteventas.Size = new System.Drawing.Size(200, 20);
            this.dtreporteventas.TabIndex = 0;
            // 
            // btnverreporteventas
            // 
            this.btnverreporteventas.Location = new System.Drawing.Point(269, 212);
            this.btnverreporteventas.Name = "btnverreporteventas";
            this.btnverreporteventas.Size = new System.Drawing.Size(75, 23);
            this.btnverreporteventas.TabIndex = 1;
            this.btnverreporteventas.Text = "Ver Reporte";
            this.btnverreporteventas.UseVisualStyleBackColor = true;
            this.btnverreporteventas.Click += new System.EventHandler(this.btnverreporteventas_Click);
            // 
            // reporteventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 363);
            this.Controls.Add(this.btnverreporteventas);
            this.Controls.Add(this.dtreporteventas);
            this.Name = "reporteventa";
            this.Text = "reporteventa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtreporteventas;
        private System.Windows.Forms.Button btnverreporteventas;
    }
}