using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class TereyagAnalizGiris : Form
    {
        public TereyagAnalizGiris(string _type, string _kullaniciid, int _row)
        {
            kullaniciid = _kullaniciid;
            type = _type;
            row = _row;
            InitializeComponent();
        }

        string type = "";
        string kullaniciid = "";
        int row = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row);
            banaAitİsler.Show();
            Close();
        }
    }
}
