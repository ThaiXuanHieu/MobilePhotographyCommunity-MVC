using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Common
{
    public class StringHelper
    {
        public static string VNDecode(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            s = s.Trim();
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            temp = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
            return Regex.Replace(temp, "[^0-9a-zA-Z]+", "-").ToLower();
        }
    }
}
