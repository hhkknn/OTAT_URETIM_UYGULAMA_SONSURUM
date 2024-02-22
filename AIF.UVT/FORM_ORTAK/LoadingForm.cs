using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_ORTAK
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            //count = _count;
        }
        int count = 20;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //for (int i = 0; i <= count; i++)
            //{
            //    if (i == 20)
            //    {
            //        return;
            //    }
            //}
            timer1.Stop();
            Close();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
