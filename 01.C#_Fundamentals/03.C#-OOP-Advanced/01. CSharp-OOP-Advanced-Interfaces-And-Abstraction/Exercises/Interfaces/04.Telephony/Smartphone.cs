using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Telephony
{
    class Smartphone : ICollable, IBrowseble
    {
        public string Calling(string phoneNumber)
        {
            bool validNumber = true;

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit(phoneNumber[i]))
                {
                    validNumber = false;
                }
            }

            if (!validNumber)
            {
                return "Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }

        public string Browsing(string website)
        {
            bool validUrl = true;

            for (int i = 0; i < website.Length; i++)
            {
                if (char.IsDigit(website[i]))
                {
                    validUrl = false;
                }
            }

            if (!validUrl)
            {
                return "Invalid URL!";
            }

            return $"Browsing: {website}!";
        }
    }
}
