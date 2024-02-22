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
    public partial class CustomMsgBtn : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize; 
        #endregion
        public CustomMsgBtn()
        {
            InitializeComponent();

            #region Font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;  
            #endregion
        }

        private void CustomMsgBtn_Load(object sender, EventArgs e)
        {

        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start.
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;


            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            btnOK.Font = new Font(btnOK.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOK.Font.Style);
            ResumeLayout();
            ////font end
        }
        static CustomMsgBtn MsgBtn; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption, string btnOK)
        {
            MsgBtn = new CustomMsgBtn();
            MsgBtn.label1.Text = Text.ToUpper();
            MsgBtn.btnOK.Text = btnOK.ToUpper();
            //MsgBox.btnCancel.Text = btnCancel;
            MsgBtn.ShowDialog();
            return result;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; MsgBtn.Close();
        }
    }
}
