using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;

namespace logicPC.Parsers
{
    public class Parser
    {
        public Parser()
        {

        }

        /// <summary>
        /// split les données concaténées par des / (SHADERS/TMUs/ROPs)
        /// </summary>
        /// <param name="str">string à traiter</param>
        /// <returns></returns>
        public static string[] DeepSplit(string[] str)
        {
            string[] strOut = new string[10];
            string[] strTemp = str[7].Split('/');   // [7] contient des données de la forme .../.../... qui doivent être séparées
            str.CopyTo(strOut, 0);
            strTemp.CopyTo(strOut, 7);

            return strOut;
        }

        public static int ParseToIntNoSpace(string str)
        {
            int newInt = 0;
            bool success = false;
            bool hadDigits = str.Any(char.IsDigit);

            if (str == "HMB2")
                return 20;

            if (hadDigits)
            {
                success = Int32.TryParse(str, out newInt);

                if (!success)
                {
                    success = Int32.TryParse(str[1..], out newInt);

                    if (!success)
                    {
                        if (str.Equals("System Shared", StringComparison.InvariantCultureIgnoreCase))
                            return 0;
                        else if (!str.Contains(' ') || str.Split(' ')[0] == "") //pas d'espaces, seul cas : GDDR[nombre], on récupère ce nombre seul.
                        {
                            char c = str.Last();
                            newInt = (int)c - '0';
                        }
                        else
                        {

                            string[] strAR = str.Split(' ');
                            newInt = Int32.Parse(strAR[0]);

                            if (strAR[1].Equals("GHZ", StringComparison.InvariantCultureIgnoreCase) || strAR[1].Equals("GB", StringComparison.InvariantCultureIgnoreCase))
                                newInt *= 1000;
                            else if (strAR[1].Equals("HZ", StringComparison.InvariantCultureIgnoreCase) || strAR[1].Equals("B", StringComparison.InvariantCultureIgnoreCase))
                                newInt /= 1000;
                        }
                    }
                }
                return newInt;
            }
            else if (str == "HBM")
                return 20;  //the input doesn't contain any numbers because it's HBM2 memory (got cut to just HMB)
            else
                return -1; //unexcpected
        }

        public static DateTime StringToDate(string strIN)
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

                if (t <= 0 && r <= 0 && s <= 0 && n<= 0)
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
