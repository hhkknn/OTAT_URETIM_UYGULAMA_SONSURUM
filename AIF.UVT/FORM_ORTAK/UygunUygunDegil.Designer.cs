
namespace AIF.UVT.FORM_ORTAK
{
    partial class UygunUygunDegil
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUygun = new System.Windows.Forms.Button();
            this.btnUygunDegil = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnUygun, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUygunDegil, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnIptal, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 150);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnUygun
            // 
            this.btnUygun.BackColor = System.Drawing.Color.LightGreen;
            this.btnUygun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUygun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUygun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUygun.Location = new System.Drawing.Point(3, 3);
            this.btnUygun.Name = "btnUygun";
            this.btnUygun.Size = new System.Drawing.Size(194, 99);
            this.btnUygun.TabIndex = 0;
            this.btnUygun.Text = "UYGUN";
            this.btnUygun.UseVisualStyleBackColor = false;
            this.btnUygun.Click += new System.EventHandler(this.btnUygun_Click);
            // 
            // btnUygunDegil
            // 
            this.btnUygunDegil.BackColor = System.Drawing.Color.Salmon;
            this.btnUygunDegil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUygunDegil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUygunDegil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUygunDegil.Location = new System.Drawing.Point(203, 3);
            this.btnUygunDegil.Name = "btnUygunDegil";
            this.btnUygunDegil.Size = new System.Drawing.Size(194, 99);
            this.btnUygunDegil.TabIndex = 1;
            this.btnUygunDegil.Text = "UYGUN DEĞİL";
            this.btnUygunDegil.UseVisualStyleBackColor = false;
            this.btnUygunDegil.Click += new System.EventHandler(this.btnUygunDegil_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.SystemColors.Info;
            this.tableLayoutPanel1.SetColumnSpan(this.btnIptal, 2);
            this.btnIptal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnIptal.Location = new System.Drawing.Point(3, 108);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(394, 39);
            this.btnIptal.TabIndex = 2;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // UygunUygunDegil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 150);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UygunUygunDegil";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UygunUygunDegil";
            this.Load += new System.EventHandler(this.UygunUygunDegil_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnUygun;
        private System.Windows.Forms.Button btnUygunDegil;
        private System.Windows.Forms.Button btnIptal;
    }
}