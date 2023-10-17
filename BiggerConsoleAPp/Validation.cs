
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Validation
    {

        // yalniz herflerden ibaret olmagini check edir.
        public bool CheckOnlyChar(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {

                if (!Char.IsLetter(value[i]))
                {
                    return false;
                }

            }
            return true;
        }

        /* min. 2 soz olmagini ve min. her sozun 3 herfden ibaret olmagini check edir.
      ve elece yalniz char olmagini da check edir. */
        public virtual bool CheckWords(string value)
        {
            string[] wordArr = value.Split(new string[] { " " }, StringSplitOptions.None);

            if (wordArr.Length >= 2)
            {
                foreach (var item in wordArr)
                {
                    if (item.Length < 3 || !CheckOnlyChar(item))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;

        }


        // do-while - int uchun yalniz reqem daxil etmeyini check edir.
        public void doWhileChecker_int(string consoleText, ref string valueStr, ref int value)
        {
            do
            {
                Console.Write(consoleText);
                valueStr = Console.ReadLine();
            }
            while (!int.TryParse(valueStr, out value));
        }

        // do-while - double uchun yalniz reqem daxil etmeyini check edir.
        public void doWhileChecker_double(string consoleText, ref string valueStr, ref double value)
        {
            do
            {
                Console.Write(consoleText);
                valueStr = Console.ReadLine();
            }
            while (!double.TryParse(valueStr, out value));
        }
    }
}
