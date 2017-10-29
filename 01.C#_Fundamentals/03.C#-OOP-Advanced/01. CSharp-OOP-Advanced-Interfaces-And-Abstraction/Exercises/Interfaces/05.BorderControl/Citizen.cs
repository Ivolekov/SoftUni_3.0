using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BorderControl
{
    class Citizen : IIdentifible
    {
        private string id;
        private string nameOrModel;

        public Citizen(string nameOrModel, string id)
        {
            this.ID = id;
            this.NameOrModel = nameOrModel;
        }

        public string ID { get; set; }
        public string NameOrModel { get; set; }


        public bool isFakeId(string fakeId)
        {
            if (this.ID.EndsWith(fakeId))
            {
                return true;
            }
            return false;
        }
    }
}
