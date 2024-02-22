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
    public partial class KaymakPeynirAnalizGiris : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end

        public KaymakPeynirAnalizGiris(string _type, string _kullaniciid, int _row, int _width, int _height)
        {
            kullaniciid = _kullaniciid;
            type = _type;
            row = _row;

            InitializeComponent();

            initialWidth = _width;
            initialHeight = _height;
        }
        string type = "";
        string kullaniciid = "";
        int row = 0;
        private void KaymakPeynirAnalizGiris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight);
            banaAitİsler.Show();
            Close();
        }
    }
}
