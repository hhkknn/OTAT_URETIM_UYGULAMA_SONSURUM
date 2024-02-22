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
    public partial class UygunUygunDegil : Form
    {
        //font start
        public int initialWidth; 
        public int initialHeight;
        public float initialFontSize;
        //font end
        public UygunUygunDegil(DataGridView _dtgridParams = null)
        {
            dtgridParams = _dtgridParams;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = btnIptal.Font.Size;
            btnIptal.Resize += Form_Resize;
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Geçerli yazı tipi boyutunu hesaplar
            btnUygun.Font = new Font(btnUygun.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnUygun.Font.Style);

            btnUygunDegil.Font = new Font(btnUygunDegil.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnUygunDegil.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnIptal.Font.Style);

            ResumeLayout();
            //font end
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        private DataGridView dtgridParams = null;
        public static string dialogResultUygunDegil = "";
        private string durum = "";
        private void UygunUygunDegil_Load(object sender, EventArgs e)
        {

        }

        private void btnUygun_Click(object sender, EventArgs e)
        {
            dialogResultUygunDegil = "Ok";
            durum = "Uygun";
            dtgridParams.CurrentCell.Value = Convert.ToString(durum);

            Close();
        }

        private void btnUygunDegil_Click(object sender, EventArgs e)
        {
            dialogResultUygunDegil = "Ok";
            durum = "Uygun Değil";
            dtgridParams.CurrentCell.Value = Convert.ToString(durum);

            Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
