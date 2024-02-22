namespace AIF.UVT
{
    partial class ProgressBar
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
            //this.circularProgressBar1 = new CircularProgressBar.CircularProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // circularProgressBar1
            // 
            //this.circularProgressBar1.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            //this.circularProgressBar1.AnimationSpeed = 500;
            //this.circularProgressBar1.BackColor = System.Drawing.Color.Transparent;
            //this.circularProgressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.circularProgressBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.circularProgressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            //this.circularProgressBar1.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            //this.circularProgressBar1.InnerMargin = 2;
            //this.circularProgressBar1.InnerWidth = 0;
            //this.circularProgressBar1.Location = new System.Drawing.Point(3, 3);
            //this.circularProgressBar1.MarqueeAnimationSpeed = 2000;
            //this.circularProgressBar1.Name = "circularProgressBar1";
            //this.circularProgressBar1.OuterColor = System.Drawing.Color.Gray;
            //this.circularProgressBar1.OuterMargin = -25;
            //this.circularProgressBar1.OuterWidth = 8;
            //this.circularProgressBar1.ProgressColor = System.Drawing.Color.Gold;
            //this.circularProgressBar1.ProgressWidth = 13;
            //this.circularProgressBar1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            //this.circularProgressBar1.Size = new System.Drawing.Size(174, 174);
            //this.circularProgressBar1.StartAngle = 270;
            //this.circularProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            //this.circularProgressBar1.SubscriptColor = System.Drawing.Color.Gray;
            //this.circularProgressBar1.SubscriptMargin = new System.Windows.Forms.Padding(0);
            //this.circularProgressBar1.SubscriptText = "";
            //this.circularProgressBar1.SuperscriptColor = System.Drawing.Color.Gray;
            //this.circularProgressBar1.SuperscriptMargin = new System.Windows.Forms.Padding(0);
            //this.circularProgressBar1.SuperscriptText = "";
            //this.circularProgressBar1.TabIndex = 0;
            //this.circularProgressBar1.Text = "Yükleniyor..";
            //this.circularProgressBar1.TextMargin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            //this.circularProgressBar1.Value = 60;
            // 
            // ProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AIF.UVT.Properties.Resources.OTAT_UVT_ArkaPlanV3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(180, 180);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressBar";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private CircularProgressBar.CircularProgressBar circularProgressBar1;
    }
}