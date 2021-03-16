using System;
using System.Linq;
using System.Text;

namespace PaymentGateway.Common
{
    public static class Obfuscator
    {
        /// <summary>
        /// Obfuscates the passed string with the <see cref="letters"/> parameter providing the last n letters to be revealed.
        /// For example,
        /// <para>"Hello", and 3 will return "**llo</para>
        /// </summary>
        public static string Obfuscate(this string str, int letters)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            var stringBuilder = new StringBuilder();
            var charArray = str.ToArray();

            for (var i = 0; i < charArray.Length; i++)
            {
                if (i < Math.Max(0, charArray.Length - letters))
                {
                    stringBuilder.Append("*");
                }
                else
                {
                    stringBuilder.Append(charArray[i]);
                }
            }

            return string.Join("", stringBuilder.ToString());
        }
    }
}
