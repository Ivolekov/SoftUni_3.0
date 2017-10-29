using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models.BindingModels
{
    public class AddCarBindingModel
    {
        public string Make { get; set; }

        public string CarModel { get; set; }

        public long TravelledDistance { get; set; }

        public string Parts { get; set; }
    }
}
