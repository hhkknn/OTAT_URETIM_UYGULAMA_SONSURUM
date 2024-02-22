using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_ORTAK
{
    public partial class Yukleniyor : Form
    {
        //int increment = 1;
        //int radius = 4;
        //int n = 8;
        //int next = 0;
        //Timer timer;

        public Action Worker { get; set; }
        public Yukleniyor(int _count)
        {
            InitializeComponent();

            //timer = new Timer();
            //this.Size = new Size(100, 100);
            //timer.Tick += (s, e) => this.Invalidate();
            //if (!DesignMode)
            //    timer.Enabled = true;
            //SetStyle(ControlStyles.AllPaintingInWmPaint |
            //         ControlStyles.OptimizedDoubleBuffer |
            //         ControlStyles.ResizeRedraw | ControlStyles.UserPaint |
            //         ControlStyles.SupportsTransparentBackColor, true);

            //if (worker == null)
            //    throw new ArgumentNullException();
            //Worker = worker;
            count = _count;
        }
        int count = 0;
        protected override void OnLoad(EventArgs e)
        {
            //base.OnLoad(e);
            //Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void Yukleniyor_Load(object sender, EventArgs e)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;

            for (int i = 0; i <= count; i++)
            {
                progressBar1.Value = i;
            }
            Close();
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
             
            //if (Parent != null && this.BackColor == Color.Transparent)
            //{
            //    using (var bmp = new Bitmap(Parent.Width, Parent.Height))
            //    {
            //        Parent.Controls.Cast<Control>()
            //              .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
            //              .Where(c => c.Bounds.IntersectsWith(this.Bounds))
            //              .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
            //              .ToList()
            //              .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));

            //        e.Graphics.DrawImage(bmp, -Left, -Top);
            //    }
            //}
            //e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            //int length = Math.Min(Width, Height);
            //PointF center = new PointF(length / 2, length / 2);
            //int bigRadius = length / 2 - radius - (n - 1) * increment;
            //float unitAngle = 360 / n;
            //if (!DesignMode)
            //    next++;
            //next = next >= n ? 0 : next;
            //int a = 0;
            //for (int i = next; i < next + n; i++)
            //{
            //    int factor = i % n;
            //    float c1X = center.X + (float)(bigRadius * Math.Cos(unitAngle * factor * Math.PI / 180));
            //    float c1Y = center.Y + (float)(bigRadius * Math.Sin(unitAngle * factor * Math.PI / 180));
            //    int currRad = radius + a * increment;
            //    PointF c1 = new PointF(c1X - currRad, c1Y - currRad);
            //    e.Graphics.FillEllipse(Brushes.Black, c1.X, c1.Y, 2 * currRad, 2 * currRad);
            //    using (Pen pen = new Pen(Color.White, 2))
            //        e.Graphics.DrawEllipse(pen, c1.X, c1.Y, 2 * currRad, 2 * currRad);
            //    a++;
            //}
        }
        protected override void OnVisibleChanged(EventArgs e)
        {
            //timer.Enabled = Visible;
            //base.OnVisibleChanged(e);
        }
    }
} 
