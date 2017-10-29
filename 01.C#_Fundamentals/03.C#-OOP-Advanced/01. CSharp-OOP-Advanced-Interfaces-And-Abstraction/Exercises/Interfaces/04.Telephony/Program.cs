using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {

            Smartphone smartPhone = new Smartphone();

            string[] phoneInput = Console.ReadLine().Split();

            string[] urlInput = Console.ReadLine().Split();

            for (int i = 0; i < phoneInput.Length; i++)
            {
                Console.WriteLine(smartPhone.Calling(phoneInput[i]));
            }

            for (int i = 0; i < urlInput.Length; i++)
            {
                Console.WriteLine(smartPhone.Browsing(urlInput[i]));
            }
        }
    }
}
