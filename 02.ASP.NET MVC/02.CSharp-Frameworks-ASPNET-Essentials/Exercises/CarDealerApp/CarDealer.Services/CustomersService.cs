namespace CarDealer.Services
{
    using AutoMapper;
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.BindingModels;
    using System.Data.Entity.Migrations;

    public class CustomersService : Service
    {
       // private CarDealerContext db = new CarDealerContext();

        public CustomersService(CarDealerContext context):base(context)
        {

        }
        public List<Customer> OrderCustomers(string order)
        {
            if (order == "ascending")
            {
                return this.Context.Customers.OrderBy(c => c.BirthDate).ThenBy(c => c.IsYoungDriver).ToList();
            }
            else if (order == "descending")
            {
                return this.Context.Customers.OrderByDescending(c => c.BirthDate).ThenBy(c => c.IsYoungDriver).ToList();
            }
            else
            {
                throw new ArgumentException("Choose between ascending and descending order!!!!");
            }
            
        }

        public void AddCustomer(AddCustomerBindingModel addCustomerBindingModel)
        {
            Customer customer = Mapper.Map<AddCustomerBindingModel, Customer>(addCustomerBindingModel);
            customer.IsYoungDriver = DateTime.Now.Year - customer.BirthDate.Year < 21;
            this.Context.Customers.Add(customer);
            this.Context.SaveChanges();
        }

        public EditCustomerBindingModel GetEditCustomer(int? id)
        {
            Customer customer = this.Context.Customers.Find(id);
            EditCustomerBindingModel model = Mapper.Map<Customer, EditCustomerBindingModel>(customer);
            return model;
        }

        public void EditCustomer(EditCustomerBindingModel model)
        {
            var entiyCustomer = this.Context.Customers.Find(model.Id);
            if (entiyCustomer != null)
            {
                entiyCustomer.Name = model.Name;
                entiyCustomer.BirthDate = model.BirthDate;
            }
            this.Context.SaveChanges();
        }
    }
}
