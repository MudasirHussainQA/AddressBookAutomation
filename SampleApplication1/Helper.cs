using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication1
{
    public class Helper
    {
        public static string RandomString(int length)
        {
            const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string alphaNumeric = chars + @"0123456789";

            string randomString = Randomize(length - 1, alphaNumeric);

            ///Force charater at the Beginning of the Random String.
            randomString = Randomize(1, chars) + randomString;

            return randomString;
        }
        public static string RandomInt(int len)
        {
            const string Numeral = "123456789";
            string randomString1 = Randomize(len - 1, Numeral);
            randomString1 = Randomize(1, randomString1);
            return randomString1;

        }

        static Random randomize = new Random();
        private static string Randomize(int length, string alphaNumeric)
        {
            string randomString = new string(Enumerable.Repeat(alphaNumeric, length)
              .Select(s => s[randomize.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}
