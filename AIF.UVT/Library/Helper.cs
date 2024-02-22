using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.Library
{
    public class Helper
    {
        //Helper
        public void SetAllControlsFont(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                //if (ctrl.AccessibilityObject.Role == AccessibleRole.StaticText)
                //    ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size - 4, FontStyle.Bold);
                //else if (ctrl.AccessibilityObject.Role == AccessibleRole.Text)
                //    ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size, FontStyle.Bold);
                //else
                //    ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size - 2, FontStyle.Bold);

                ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size);

            }
        }
        public Tuple<DateTime, DateTime> SaatDuzenle(string baslangicSaati, string bitisSaati)
        {
            DateTime dtBaslangic = DateTime.Now;
            DateTime dtBitis = DateTime.Now;

            if (Convert.ToInt32(baslangicSaati.Replace(":", "")) > Convert.ToInt32(bitisSaati.Replace(":", "")))
            {
                TimeSpan time = new TimeSpan(1, Convert.ToInt32(bitisSaati.Substring(0, 2)), Convert.ToInt32(bitisSaati.Substring(3, 2)), 0);

                dtBitis = dtBitis.Date + time;

                time = new TimeSpan(0, Convert.ToInt32(baslangicSaati.Substring(0, 2)), Convert.ToInt32(baslangicSaati.Substring(3, 2)), 0);

                dtBaslangic = dtBaslangic.Date + time;
            }
            else
            {
                TimeSpan time = new TimeSpan(0, Convert.ToInt32(bitisSaati.Substring(0, 2)), Convert.ToInt32(bitisSaati.Substring(3, 2)), 0);

                dtBitis = dtBitis.Date + time;

                time = new TimeSpan(0, Convert.ToInt32(baslangicSaati.Substring(0, 2)), Convert.ToInt32(baslangicSaati.Substring(3, 2)), 0);

                dtBaslangic = dtBaslangic.Date + time;
            }

            return Tuple.Create(dtBaslangic, dtBitis);
        }
    }


}
