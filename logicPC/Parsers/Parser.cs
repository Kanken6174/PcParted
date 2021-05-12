using System;
using System.Linq;

namespace logicPC.Parsers
{
    public class Parser : DateParser
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

        /// <summary>
        /// Methode responsable de la conversion en int des strings, selon leur format.
        /// </summary>
        /// <param name="str">string à traiter</param>
        /// <returns>int du string traité</returns>
        public static int ParseToIntNoSpace(string str)
        {
            int newInt = 0;
            bool success = false;
            bool hadDigits = str.Any(char.IsDigit);
            bool isBitrate = str.Contains("bit");

            if (str == "HMB2")
                return 20;

            if (isBitrate)
            {
                string[] strAR = str.Split(' ');
                newInt = Int32.Parse(strAR[1]);
                return newInt;
            }

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
                            string strClean = strAR[0].Split('.')[0];
                            newInt = Int32.Parse(strClean);

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
    }
}