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
    public partial class CustomMsgBox : Form
    {
        public CustomMsgBox()
        {
            InitializeComponent();
        }
        public static bool Value = false;
        private void btnOK_Click(object sender, EventArgs e)
        {
            Value = true;
            Close();
        }

        private void btnCANCEL_Click(object sender, EventArgs e)
        {
            Value = false;
            Close();
        }

        static CustomMsgBox MsgBox; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string Text, string Caption, string btnOK, string btnCancel)
        {
            MsgBox = new CustomMsgBox();
            MsgBox.label1.Text = Text.ToUpper();
            MsgBox.btnOK.Text = btnOK.ToUpper();
            MsgBox.btnCANCEL.Text = btnCancel.ToUpper();
            MsgBox.Text = Caption;
            result = MsgBox.ShowDialog();
            return result;

        }
    }
}
