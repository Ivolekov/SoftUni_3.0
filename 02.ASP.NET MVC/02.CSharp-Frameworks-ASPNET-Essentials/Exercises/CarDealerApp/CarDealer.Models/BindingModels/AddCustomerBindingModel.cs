using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models.BindingModels
{
    public class AddCustomerBindingModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}