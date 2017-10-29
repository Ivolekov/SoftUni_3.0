using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BorderControl
{
    interface IIdentifible
    {
        string ID { get; set; }
        string NameOrModel { get; set; }

        bool isFakeId(string fakeId);
    }
}
