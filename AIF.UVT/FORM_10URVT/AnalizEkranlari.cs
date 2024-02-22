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
    public partial class AnalizEkranlari : Form
    {
        public AnalizEkranlari()
        {
            InitializeComponent();
        }

        private void btnTelemeProTkp_Click(object sender, EventArgs e)
        {
            TelemeProsesTakip telemeProsesTakip = new TelemeProsesTakip(null, null, null, null, null, null, 0, 0, 0, null);
            telemeProsesTakip.ShowDialog();
        }

        private void btnMamulAnalz_Click(object sender, EventArgs e)
        {
            TelemeProsesTakip_2 telemeProsesTakip_2 = new TelemeProsesTakip_2(null, null, null, null, null, null, 0, null);
            telemeProsesTakip_2.ShowDialog();
        }

        private void btnLorProTkp_Click(object sender, EventArgs e)
        {
            LorProsesTakip lorProsesTakip = new LorProsesTakip(null, null, null, null, null, null, 0, null);
            lorProsesTakip.ShowDialog();
        }

        private void btnAyrnProTkp_1_Click(object sender, EventArgs e)
        {
            AyranProsesTakip_1 ayranProsesTakip_1 = new AyranProsesTakip_1(null, null, null, null, null, null, 0, null, null);
            ayranProsesTakip_1.ShowDialog();
        }

        private void btnYogrtProTkp_1_Click(object sender, EventArgs e)
        {
            YogurtProsesTakip_1 yogurtProsesTakip_1 = new YogurtProsesTakip_1(null, null, null, null, null, null, 0, null, null);
            yogurtProsesTakip_1.ShowDialog();
        }

        private void btnTostPeyProTkp_1_Click(object sender, EventArgs e)
        {
            TostPeynirProsesTakip_1 tostPeynirProsesTakip_1 = new TostPeynirProsesTakip_1(null, null, null, null, null, null, 0, 0, 0, null, null);
            tostPeynirProsesTakip_1.ShowDialog();
        }

        private void btnTostPeyProTkp_2_Click(object sender, EventArgs e)
        {
            TostPeynirProsesTakip_2 tostPeynirProsesTakip_2 = new TostPeynirProsesTakip_2(null, null, null, null, null, null, 0, 0, 0, null);
            tostPeynirProsesTakip_2.ShowDialog();
        }

        private void btnTazePeyProTkp_1_Click(object sender, EventArgs e)
        {
            TazePeynirProsesTakip_1 tazePeynirProsesTakip_1 = new TazePeynirProsesTakip_1(null, null, null, null, null, null, 0, 0, 0, null, null);
            tazePeynirProsesTakip_1.ShowDialog();
        }

        private void btnTazePeyProTkp_2_Click(object sender, EventArgs e)
        {
            TazePeynirProsesTakip_2 tazePeynirProsesTakip_2 = new TazePeynirProsesTakip_2(null, null, null, null, null, null, 0, 0, 0, null,null);
            tazePeynirProsesTakip_2.ShowDialog();
        }

        private void btnTereyagProTkp_1_Click(object sender, EventArgs e)
        {
            TereyagProsesTakip_1 tereyagProsesTakip_1 = new TereyagProsesTakip_1(null, null, null, null, null, null, 0, 0, 0, null, null);
            tereyagProsesTakip_1.ShowDialog();
        }

        private void btnTereyagProTkp_2_Click(object sender, EventArgs e)
        {
            TereyagProsesTakip_2 tereyagProsesTakip_2 = new TereyagProsesTakip_2(null, null, null, null, null, null, 0, 0, 0, null,null);
            tereyagProsesTakip_2.ShowDialog();
        }

        private void btnYogrtProTkp_2_Click(object sender, EventArgs e)
        {
            YogurtProsesTakip_2 yogurtProsesTakip_2 = new YogurtProsesTakip_2(null, null, 0, null);
            yogurtProsesTakip_2.ShowDialog();
        }

        private void btnAyrnProTkp_3_Click(object sender, EventArgs e)
        {
            AyranProsesTakip_3 ayranProsesTakip_3 = new AyranProsesTakip_3(null, null, null, null, 0, null);
            ayranProsesTakip_3.ShowDialog();
        }
    }
}