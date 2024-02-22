using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_10URVT
{
    public partial class UretimSarfiyatPartiValidasyon : Form
    {
        public UretimSarfiyatPartiValidasyon(DataGridView _dtgridParams)
        {
            InitializeComponent();

            dtgridParams = _dtgridParams;
        }
        private DataGridView dtgridParams = null;
        private void UretimSarfiyatPartiValidasyon_Load(object sender, EventArgs e)
        {
            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            #endregion MKOD İle Background Değişimi

            try
            {
                if (dtgridParams != null)
                {
                    dtgPartiValidasyon.DataSource = dtgridParams.DataSource;

                    dtgPartiValidasyon.Columns.Add("GirilenParti", "Girilen Parti");
                    //var current= dtgPartiValidasyon.Rows[0].Cells["GirilenParti"].getc;
                    //dtgPartiValidasyon.CurrentCell = kolon;
                    dtgPartiValidasyon.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgPartiValidasyon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
