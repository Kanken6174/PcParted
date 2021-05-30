using System;
using System.Globalization;
using System.Linq;

namespace logicPC.Parsers
{
    internal class DateParser
    {
        internal static DateTime StringToDate(string strIN)
        {
            DateTime dateSortie = default;

            if (strIN.Any(char.IsDigit))
            {
                string[] strTemp = strIN.Split(' ');
                string str = default;
                int t = 0, r = 0, n = 0, s = 0;

                if (strTemp.Length > 1)
                {
                    str = strTemp[1];
                }
                string dateTemp = default;
                if (str != null)
                {
                    t = str.IndexOf('t');   // XX th
                    r = str.IndexOf('r');   // 3rd
                    n = str.IndexOf('n');   // 2nd
                    s = str.IndexOf('s');   // 1st
                }
                else
                {
                    str = strTemp[0];
                }

                if (t <= 0 && r <= 0 && s <= 0 && n <= 0)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    string format = "yyyy";
                    dateSortie = DateTime.ParseExact(str, format, provider);
                }
                else
                {
                    if (s != -1)
                    {
                        dateTemp = str.Remove(s, 2);
                    }
                    else if (r != -1)
                    {
                        dateTemp = str.Remove(r, 2);
                    }
                    else if (n != -1)
                    {
                        dateTemp = str.Remove(n, 2);
                    }
                    else if (t != -1)
                    {
                        dateTemp = str.Remove(t, 2);
                    }

                    strTemp[1] = dateTemp;
                    str = string.Join(' ', strTemp);
                    dateSortie = DateTime.Parse(str);
                }
            }
            else
            {
                dateSortie = default;
            }
            return dateSortie;
        }
    }
}