﻿
namespace AIF.UVT.FORM_010OTATURVT
{
    partial class GramajKontrol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.dtgGramajKontrol = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgGramajKontrol)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(27, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(582, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "GRAMAJ KONTROL TABLOSU";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dtgGramajKontrol
            // 
            this.dtgGramajKontrol.AllowUserToAddRows = false;
            this.dtgGramajKontrol.AllowUserToDeleteRows = false;
            this.dtgGramajKontrol.AllowUserToResizeColumns = false;
            this.dtgGramajKontrol.AllowUserToResizeRows = false;
            this.dtgGramajKontrol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgGramajKontrol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgGramajKontrol.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtgGramajKontrol.Location = new System.Drawing.Point(27, 100);
            this.dtgGramajKontrol.Name = "dtgGramajKontrol";
            this.dtgGramajKontrol.RowHeadersVisible = false;
            this.dtgGramajKontrol.RowTemplate.Height = 30;
            this.dtgGramajKontrol.Size = new System.Drawing.Size(582, 155);
            this.dtgGramajKontrol.TabIndex = 8;
            this.dtgGramajKontrol.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgGramajKontrol_CellClick);
            // 
            // GramajKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtgGramajKontrol);
            this.Name = "GramajKontrol";
            this.Text = "GramajKontrol";
            this.Load += new System.EventHandler(this.GramajKontrol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgGramajKontrol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dtgGramajKontrol;
    }
}