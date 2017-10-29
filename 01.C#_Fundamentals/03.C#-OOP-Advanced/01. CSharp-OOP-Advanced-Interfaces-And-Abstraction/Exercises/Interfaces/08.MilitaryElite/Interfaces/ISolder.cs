using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MilitaryElite.Interfaces
{
    public interface ISolder
    {
        string Id { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
