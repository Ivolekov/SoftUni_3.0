namespace CarDealer.Services
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Models.ViewModels;
    using AutoMapper;
    using Models.BindingModels;

    public class SalesService : Service
    {
        //private CarDealerContext db = new CarDealerContext();

        public SalesService(CarDealerContext context):base(context)
        {

        }

        public List<Sale> GetAllSales()
        {
            return this.Context.Sales.ToList();
        }

        public List<Sale> GetDiscountSales(double? percent)
        {
            var withoutPercent = this.Context.Sales.Where(s => s.Discount != 0).ToList();
            var withPercent = this.Context.Sales.Where(s => s.Discount * 100 == percent && s.Discount != 0).ToList();
            if (percent == 0 || percent == null)
            {
                return withoutPercent;
            }
            return withPercent;
        }

        public AddSaleViewModel GetSalesViewModel()
        {
            AddSaleViewModel vm = new AddSaleViewModel();
            IEnumerable<Car> cars = this.Context.Cars;
            IEnumerable<Customer> customers = this.Context.Customers;

            IEnumerable<AddSaleCarViewModel> carVM = Mapper.Map<IEnumerable<Car>, IEnumerable<AddSaleCarViewModel>>(cars);
            IEnumerable<AddSaleCustomerViewModel> customerVM = Mapper.Map<IEnumerable<Customer>, IEnumerable<AddSaleCustomerViewModel>>(customers);

            List<int> discount = new List<int>();
            for (int i = 0; i <= 50; i+=5)
            {
                discount.Add(i);
            }

            vm.Cars = carVM;
            vm.Customers = customerVM;
            vm.Discounts = discount;

            return vm;
        }

        public AddSalesConfirmationViewModel GetSalesConfirmationViewModel(AddSaleBindingModel bind)
        {
            Car carModel = this.Context.Cars.Find(bind.CarId);
            Customer customerModel = this.Context.Customers.Find(bind.CustomerId);
            AddSalesConfirmationViewModel vm = new AddSalesConfirmationViewModel()
            {
                Discount = bind.Discount,
                CustomerId  = customerModel.Id,
                CarId = carModel.Id,
                CarPrice = (decimal)carModel.Parts.Sum(p=>p.Price).Value,
                CarRepresentation = $"{carModel.Make} {carModel.Model}"
            };

            vm.Discount += customerModel.IsYoungDriver ? 5 : 0;
            vm.FinalCarPrice += vm.CarPrice - vm.CarPrice * vm.Discount / 100;
            return vm;
        }

        public void AddSale(AddSaleBindingModel bind)
        {
            Car carModel = this.Context.Cars.Find(bind.CarId);
            Customer customerModel = this.Context.Customers.Find(bind.CustomerId);

            Sale sale = new Sale()
            {
                Customer = customerModel,
                Car = carModel,
                Discount = bind.Discount / 100
            };

            this.Context.Sales.Add(sale);
            this.Context.SaveChanges();
        }
    }
}
