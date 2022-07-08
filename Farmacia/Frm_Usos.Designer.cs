
namespace Farmacia
{
    partial class Frm_Usos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Usos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcionUsos = new System.Windows.Forms.TextBox();
            this.btnEliminarUsos = new System.Windows.Forms.Button();
            this.btnModificarUsos = new System.Windows.Forms.Button();
            this.btnRegistrarUsos = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.rbBucarPorCodigoUsos = new System.Windows.Forms.RadioButton();
            this.rbBuscarPorNombreUsos = new System.Windows.Forms.RadioButton();
            this.txtBuscarUsos = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pbBuscarUsos = new System.Windows.Forms.PictureBox();
            this.dgvUsos = new System.Windows.Forms.DataGridView();
            this.txtCodigoUsos = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProviderUsos = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarUsos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsos)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Location = new System.Drawing.Point(45, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "USOS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(76, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Descripción:";
            // 
            // txtDescripcionUsos
            // 
            this.txtDescripcionUsos.Font = new System.Drawing.Font("Sitka Small", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionUsos.Location = new System.Drawing.Point(81, 178);
            this.txtDescripcionUsos.MaxLength = 30;
            this.txtDescripcionUsos.Multiline = true;
            this.txtDescripcionUsos.Name = "txtDescripcionUsos";
            this.txtDescripcionUsos.Size = new System.Drawing.Size(426, 70);
            this.txtDescripcionUsos.TabIndex = 2;
            this.txtDescripcionUsos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcionUsos_KeyPress);
            // 
            // btnEliminarUsos
            // 
            this.btnEliminarUsos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarUsos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnEliminarUsos.FlatAppearance.BorderSize = 0;
            this.btnEliminarUsos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnEliminarUsos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarUsos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsos.ForeColor = System.Drawing.Color.White;
            this.btnEliminarUsos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUsos.Location = new System.Drawing.Point(630, 206);
            this.btnEliminarUsos.Name = "btnEliminarUsos";
            this.btnEliminarUsos.Size = new System.Drawing.Size(152, 38);
            this.btnEliminarUsos.TabIndex = 77;
            this.btnEliminarUsos.Text = "Eliminar";
            this.btnEliminarUsos.UseVisualStyleBackColor = false;
            this.btnEliminarUsos.Click += new System.EventHandler(this.btnEliminarUsos_Click);
            // 
            // btnModificarUsos
            // 
            this.btnModificarUsos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarUsos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnModificarUsos.FlatAppearance.BorderSize = 0;
            this.btnModificarUsos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnModificarUsos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarUsos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarUsos.ForeColor = System.Drawing.Color.White;
            this.btnModificarUsos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarUsos.Location = new System.Drawing.Point(630, 161);
            this.btnModificarUsos.Name = "btnModificarUsos";
            this.btnModificarUsos.Size = new System.Drawing.Size(152, 38);
            this.btnModificarUsos.TabIndex = 75;
            this.btnModificarUsos.Text = "Modificar";
            this.btnModificarUsos.UseVisualStyleBackColor = false;
            this.btnModificarUsos.Click += new System.EventHandler(this.btnModificarUsos_Click);
            // 
            // btnRegistrarUsos
            // 
            this.btnRegistrarUsos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarUsos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnRegistrarUsos.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUsos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnRegistrarUsos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUsos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarUsos.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarUsos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarUsos.Location = new System.Drawing.Point(630, 116);
            this.btnRegistrarUsos.Name = "btnRegistrarUsos";
            this.btnRegistrarUsos.Size = new System.Drawing.Size(152, 38);
            this.btnRegistrarUsos.TabIndex = 72;
            this.btnRegistrarUsos.Text = "Registrar";
            this.btnRegistrarUsos.UseVisualStyleBackColor = false;
            this.btnRegistrarUsos.Click += new System.EventHandler(this.btnRegistrarUsos_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(600, 161);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 38);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 76;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(600, 206);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 38);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 74;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(600, 116);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 73;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(9, 9);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 80;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // rbBucarPorCodigoUsos
            // 
            this.rbBucarPorCodigoUsos.AutoSize = true;
            this.rbBucarPorCodigoUsos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBucarPorCodigoUsos.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.rbBucarPorCodigoUsos.Location = new System.Drawing.Point(516, 304);
            this.rbBucarPorCodigoUsos.Margin = new System.Windows.Forms.Padding(2);
            this.rbBucarPorCodigoUsos.Name = "rbBucarPorCodigoUsos";
            this.rbBucarPorCodigoUsos.Size = new System.Drawing.Size(200, 27);
            this.rbBucarPorCodigoUsos.TabIndex = 84;
            this.rbBucarPorCodigoUsos.Text = "Buscar por Código";
            this.rbBucarPorCodigoUsos.UseVisualStyleBackColor = true;
            // 
            // rbBuscarPorNombreUsos
            // 
            this.rbBuscarPorNombreUsos.AutoSize = true;
            this.rbBuscarPorNombreUsos.Checked = true;
            this.rbBuscarPorNombreUsos.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBuscarPorNombreUsos.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.rbBuscarPorNombreUsos.Location = new System.Drawing.Point(516, 276);
            this.rbBuscarPorNombreUsos.Margin = new System.Windows.Forms.Padding(2);
            this.rbBuscarPorNombreUsos.Name = "rbBuscarPorNombreUsos";
            this.rbBuscarPorNombreUsos.Size = new System.Drawing.Size(205, 27);
            this.rbBuscarPorNombreUsos.TabIndex = 83;
            this.rbBuscarPorNombreUsos.TabStop = true;
            this.rbBuscarPorNombreUsos.Text = "Buscar por Nombre";
            this.rbBuscarPorNombreUsos.UseVisualStyleBackColor = true;
            // 
            // txtBuscarUsos
            // 
            this.txtBuscarUsos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarUsos.Location = new System.Drawing.Point(125, 293);
            this.txtBuscarUsos.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscarUsos.MaxLength = 100;
            this.txtBuscarUsos.Name = "txtBuscarUsos";
            this.txtBuscarUsos.Size = new System.Drawing.Size(347, 27);
            this.txtBuscarUsos.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(45, 293);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 81;
            this.label2.Text = "Buscar:";
            // 
            // pbBuscarUsos
            // 
            this.pbBuscarUsos.Image = ((System.Drawing.Image)(resources.GetObject("pbBuscarUsos.Image")));
            this.pbBuscarUsos.Location = new System.Drawing.Point(476, 283);
            this.pbBuscarUsos.Margin = new System.Windows.Forms.Padding(2);
            this.pbBuscarUsos.Name = "pbBuscarUsos";
            this.pbBuscarUsos.Size = new System.Drawing.Size(31, 38);
            this.pbBuscarUsos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscarUsos.TabIndex = 97;
            this.pbBuscarUsos.TabStop = false;
            this.pbBuscarUsos.Click += new System.EventHandler(this.pbBuscarCli_Click);
            // 
            // dgvUsos
            // 
            this.dgvUsos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUsos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUsos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvUsos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsos.ColumnHeadersHeight = 30;
            this.dgvUsos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsos.EnableHeadersVisualStyles = false;
            this.dgvUsos.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvUsos.Location = new System.Drawing.Point(49, 365);
            this.dgvUsos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvUsos.Name = "dgvUsos";
            this.dgvUsos.ReadOnly = true;
            this.dgvUsos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvUsos.RowHeadersWidth = 51;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvUsos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvUsos.RowTemplate.Height = 24;
            this.dgvUsos.Size = new System.Drawing.Size(674, 184);
            this.dgvUsos.TabIndex = 98;
            this.dgvUsos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsos_CellClick);
            // 
            // txtCodigoUsos
            // 
            this.txtCodigoUsos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtCodigoUsos.Enabled = false;
            this.txtCodigoUsos.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoUsos.ForeColor = System.Drawing.Color.White;
            this.txtCodigoUsos.Location = new System.Drawing.Point(160, 94);
            this.txtCodigoUsos.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoUsos.Name = "txtCodigoUsos";
            this.txtCodigoUsos.Size = new System.Drawing.Size(23, 27);
            this.txtCodigoUsos.TabIndex = 101;
            this.txtCodigoUsos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(77, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 23);
            this.label10.TabIndex = 100;
            this.label10.Text = "Código:";
            // 
            // errorProviderUsos
            // 
            this.errorProviderUsos.ContainerControl = this;
            // 
            // Frm_Usos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(804, 592);
            this.Controls.Add(this.txtCodigoUsos);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dgvUsos);
            this.Controls.Add(this.pbBuscarUsos);
            this.Controls.Add(this.rbBucarPorCodigoUsos);
            this.Controls.Add(this.rbBuscarPorNombreUsos);
            this.Controls.Add(this.txtBuscarUsos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnEliminarUsos);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnModificarUsos);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegistrarUsos);
            this.Controls.Add(this.txtDescripcionUsos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Usos";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarUsos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderUsos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescripcionUsos;
        private System.Windows.Forms.Button btnEliminarUsos;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnModificarUsos;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegistrarUsos;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.RadioButton rbBucarPorCodigoUsos;
        private System.Windows.Forms.RadioButton rbBuscarPorNombreUsos;
        private System.Windows.Forms.TextBox txtBuscarUsos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbBuscarUsos;
        private System.Windows.Forms.DataGridView dgvUsos;
        private System.Windows.Forms.TextBox txtCodigoUsos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProviderUsos;
    }
}