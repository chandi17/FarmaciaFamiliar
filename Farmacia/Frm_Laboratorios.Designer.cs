﻿
namespace Farmacia
{
    partial class Frm_Laboratorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Laboratorios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtBuscarLab = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreLab = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEliminarLab = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.btnModificarLab = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRegistrarLab = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoLab = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.rbBucarPorCodigoLab = new System.Windows.Forms.RadioButton();
            this.rbBuscarPorNombreLab = new System.Windows.Forms.RadioButton();
            this.pbBuscarLab = new System.Windows.Forms.PictureBox();
            this.dgvLaboratorios = new System.Windows.Forms.DataGridView();
            this.errorProviderLaboratorios = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarLab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratorios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLaboratorios)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(24, 33);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(31, 38);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 88;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click_1);
            // 
            // txtBuscarLab
            // 
            this.txtBuscarLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarLab.Location = new System.Drawing.Point(100, 309);
            this.txtBuscarLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBuscarLab.MaxLength = 30;
            this.txtBuscarLab.Name = "txtBuscarLab";
            this.txtBuscarLab.Size = new System.Drawing.Size(203, 27);
            this.txtBuscarLab.TabIndex = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label2.Location = new System.Drawing.Point(20, 314);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 84;
            this.label2.Text = "Buscar:";
            // 
            // txtNombreLab
            // 
            this.txtNombreLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreLab.Location = new System.Drawing.Point(86, 219);
            this.txtNombreLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombreLab.MaxLength = 30;
            this.txtNombreLab.Name = "txtNombreLab";
            this.txtNombreLab.Size = new System.Drawing.Size(319, 27);
            this.txtNombreLab.TabIndex = 83;
            this.txtNombreLab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreLab_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(86, 183);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 23);
            this.label3.TabIndex = 82;
            this.label3.Text = "Nombre:";
            // 
            // btnEliminarLab
            // 
            this.btnEliminarLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminarLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnEliminarLab.FlatAppearance.BorderSize = 0;
            this.btnEliminarLab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnEliminarLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarLab.ForeColor = System.Drawing.Color.White;
            this.btnEliminarLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarLab.Location = new System.Drawing.Point(597, 250);
            this.btnEliminarLab.Name = "btnEliminarLab";
            this.btnEliminarLab.Size = new System.Drawing.Size(152, 39);
            this.btnEliminarLab.TabIndex = 81;
            this.btnEliminarLab.Text = "Eliminar";
            this.btnEliminarLab.UseVisualStyleBackColor = false;
            this.btnEliminarLab.Click += new System.EventHandler(this.btnEliminarLab_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(567, 206);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(31, 39);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 80;
            this.pictureBox5.TabStop = false;
            // 
            // btnModificarLab
            // 
            this.btnModificarLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificarLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnModificarLab.FlatAppearance.BorderSize = 0;
            this.btnModificarLab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnModificarLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarLab.ForeColor = System.Drawing.Color.White;
            this.btnModificarLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarLab.Location = new System.Drawing.Point(597, 206);
            this.btnModificarLab.Name = "btnModificarLab";
            this.btnModificarLab.Size = new System.Drawing.Size(152, 39);
            this.btnModificarLab.TabIndex = 79;
            this.btnModificarLab.Text = "Modificar";
            this.btnModificarLab.UseVisualStyleBackColor = false;
            this.btnModificarLab.Click += new System.EventHandler(this.btnModificarLab_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(567, 250);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 39);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 78;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(567, 162);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // btnRegistrarLab
            // 
            this.btnRegistrarLab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegistrarLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnRegistrarLab.FlatAppearance.BorderSize = 0;
            this.btnRegistrarLab.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnRegistrarLab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarLab.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarLab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarLab.Location = new System.Drawing.Point(597, 162);
            this.btnRegistrarLab.Name = "btnRegistrarLab";
            this.btnRegistrarLab.Size = new System.Drawing.Size(152, 39);
            this.btnRegistrarLab.TabIndex = 76;
            this.btnRegistrarLab.Text = "Registrar";
            this.btnRegistrarLab.UseVisualStyleBackColor = false;
            this.btnRegistrarLab.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.label4.Location = new System.Drawing.Point(68, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(202, 32);
            this.label4.TabIndex = 74;
            this.label4.Text = "LABORATORIO";
            // 
            // txtCodigoLab
            // 
            this.txtCodigoLab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.txtCodigoLab.Enabled = false;
            this.txtCodigoLab.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoLab.ForeColor = System.Drawing.Color.White;
            this.txtCodigoLab.Location = new System.Drawing.Point(282, 125);
            this.txtCodigoLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCodigoLab.Name = "txtCodigoLab";
            this.txtCodigoLab.Size = new System.Drawing.Size(37, 27);
            this.txtCodigoLab.TabIndex = 101;
            this.txtCodigoLab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(82, 127);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(196, 23);
            this.label10.TabIndex = 100;
            this.label10.Text = "Código Laboratorio:";
            // 
            // rbBucarPorCodigoLab
            // 
            this.rbBucarPorCodigoLab.AutoSize = true;
            this.rbBucarPorCodigoLab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBucarPorCodigoLab.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.rbBucarPorCodigoLab.Location = new System.Drawing.Point(348, 323);
            this.rbBucarPorCodigoLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbBucarPorCodigoLab.Name = "rbBucarPorCodigoLab";
            this.rbBucarPorCodigoLab.Size = new System.Drawing.Size(200, 27);
            this.rbBucarPorCodigoLab.TabIndex = 103;
            this.rbBucarPorCodigoLab.Text = "Buscar por Código";
            this.rbBucarPorCodigoLab.UseVisualStyleBackColor = true;
            // 
            // rbBuscarPorNombreLab
            // 
            this.rbBuscarPorNombreLab.AutoSize = true;
            this.rbBuscarPorNombreLab.Checked = true;
            this.rbBuscarPorNombreLab.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBuscarPorNombreLab.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.rbBuscarPorNombreLab.Location = new System.Drawing.Point(348, 296);
            this.rbBuscarPorNombreLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbBuscarPorNombreLab.Name = "rbBuscarPorNombreLab";
            this.rbBuscarPorNombreLab.Size = new System.Drawing.Size(205, 27);
            this.rbBuscarPorNombreLab.TabIndex = 102;
            this.rbBuscarPorNombreLab.TabStop = true;
            this.rbBuscarPorNombreLab.Text = "Buscar por Nombre";
            this.rbBuscarPorNombreLab.UseVisualStyleBackColor = true;
            // 
            // pbBuscarLab
            // 
            this.pbBuscarLab.Image = ((System.Drawing.Image)(resources.GetObject("pbBuscarLab.Image")));
            this.pbBuscarLab.Location = new System.Drawing.Point(308, 299);
            this.pbBuscarLab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbBuscarLab.Name = "pbBuscarLab";
            this.pbBuscarLab.Size = new System.Drawing.Size(31, 38);
            this.pbBuscarLab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBuscarLab.TabIndex = 104;
            this.pbBuscarLab.TabStop = false;
            this.pbBuscarLab.Click += new System.EventHandler(this.pbBuscarCli_Click);
            // 
            // dgvLaboratorios
            // 
            this.dgvLaboratorios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLaboratorios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLaboratorios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLaboratorios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.dgvLaboratorios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLaboratorios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaboratorios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLaboratorios.ColumnHeadersHeight = 30;
            this.dgvLaboratorios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLaboratorios.EnableHeadersVisualStyles = false;
            this.dgvLaboratorios.GridColor = System.Drawing.Color.SteelBlue;
            this.dgvLaboratorios.Location = new System.Drawing.Point(31, 379);
            this.dgvLaboratorios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvLaboratorios.Name = "dgvLaboratorios";
            this.dgvLaboratorios.ReadOnly = true;
            this.dgvLaboratorios.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaboratorios.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLaboratorios.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLaboratorios.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLaboratorios.RowTemplate.Height = 24;
            this.dgvLaboratorios.Size = new System.Drawing.Size(750, 206);
            this.dgvLaboratorios.TabIndex = 105;
            this.dgvLaboratorios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaboratorios_CellClick);
            // 
            // errorProviderLaboratorios
            // 
            this.errorProviderLaboratorios.ContainerControl = this;
            // 
            // Frm_Laboratorios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(66)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(804, 592);
            this.Controls.Add(this.dgvLaboratorios);
            this.Controls.Add(this.rbBucarPorCodigoLab);
            this.Controls.Add(this.rbBuscarPorNombreLab);
            this.Controls.Add(this.pbBuscarLab);
            this.Controls.Add(this.txtCodigoLab);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.txtBuscarLab);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreLab);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEliminarLab);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.btnModificarLab);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegistrarLab);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Laboratorios";
            this.Text = "Laboratorio";
            this.Load += new System.EventHandler(this.Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBuscarLab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratorios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderLaboratorios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtBuscarLab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreLab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEliminarLab;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button btnModificarLab;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnRegistrarLab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoLab;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbBucarPorCodigoLab;
        private System.Windows.Forms.RadioButton rbBuscarPorNombreLab;
        private System.Windows.Forms.PictureBox pbBuscarLab;
        private System.Windows.Forms.DataGridView dgvLaboratorios;
        private System.Windows.Forms.ErrorProvider errorProviderLaboratorios;
    }
}