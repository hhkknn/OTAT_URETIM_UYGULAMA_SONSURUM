using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AIF.UVT
{
    public class parseNumber
    {
        private static CultureInfo _parsCult;
        public static T parservalues<T>(string val) where T : struct
        {

            object returnvals = 0;
            try
            {
                if (string.IsNullOrEmpty(val)) return (T)Convert.ChangeType(returnvals, typeof(T));

                val = Regex.Replace(val, @"[^0-9.,]+", "").Trim();

                CultureInfo parser = parsCult;
                if (new Regex("^(?!0|\\.00)[0-9]+(,\\d{3})*([.][0-9]{0,9})$").IsMatch(val))
                {
                    parser = System.Globalization.CultureInfo.InvariantCulture;
                }

                if (typeof(T) == typeof(decimal))
                {
                    returnvals = decimal.Parse(val, parser);
                }
                else if (typeof(T) == typeof(double))
                {
                    returnvals = double.Parse(val, parser);
                }

                else if (typeof(T) == typeof(float))
                {
                    returnvals = float.Parse(val, parser);
                }
                else if (typeof(T) == typeof(int))
                {
                    returnvals = (int)decimal.Parse(val, parser);
                }
            }
            catch (Exception ex)
            {
            }

            return (T)returnvals;

        }

        private static CultureInfo parsCult
        {
            get
            {
                if (_parsCult == null)
                {
                    CultureInfo ci = CultureInfo.InvariantCulture;
                    _parsCult = (CultureInfo)ci.Clone();

                    _parsCult.NumberFormat.CurrencyDecimalSeparator = ",";
                    _parsCult.NumberFormat.NumberDecimalSeparator = ",";
                    _parsCult.NumberFormat.PercentDecimalSeparator = ",";
                    _parsCult.NumberFormat.CurrencyGroupSeparator = ".";
                    _parsCult.NumberFormat.NumberGroupSeparator = ".";
                    _parsCult.NumberFormat.PercentGroupSeparator = ".";
                }

                return _parsCult;

            }
        }
    }
}
