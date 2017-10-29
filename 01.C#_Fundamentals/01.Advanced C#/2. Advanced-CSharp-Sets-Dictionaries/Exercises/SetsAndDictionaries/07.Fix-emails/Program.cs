using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Fix_emails
{
    public class Program
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            string email = Console.ReadLine();
           
            Dictionary<string, string> data = new Dictionary<string, string>();

            while (name != "stop")
            {
                string[] emailDomain = email.Split('.');
                string domain = emailDomain[1].ToLower();

                if (!((domain == "us") || (domain == "uk")))
                {
                    if (!data.ContainsKey(name))
                    {
                        data[name] = null;
                    }
                    data[name] = email;
                }

                name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                email = Console.ReadLine();
            }

            foreach (var item in data)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
