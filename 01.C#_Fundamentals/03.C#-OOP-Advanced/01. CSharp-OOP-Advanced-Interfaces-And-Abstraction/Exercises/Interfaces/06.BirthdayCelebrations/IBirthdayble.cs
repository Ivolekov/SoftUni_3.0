using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.BirthdayCelebrations
{
    interface IBirthdayble
    {
        string Birthdate { get; set; }

        bool isBirthday(string year);
    }
}
