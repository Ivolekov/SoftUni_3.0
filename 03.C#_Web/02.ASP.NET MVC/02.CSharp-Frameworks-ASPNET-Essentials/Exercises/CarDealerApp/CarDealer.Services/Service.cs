namespace CarDealer.Services
{
    using Data;
    using AutoMapper;
    using Models;
    using Models.BindingModels;
    using Models.ViewModels;

    public abstract class Service
    {
        public Service(CarDealerContext context)
        {
            this.Context = context;
            ConfigAutomapper();
        }
        protected CarDealerContext Context { get; }

        private static void ConfigAutomapper()
        {
            Mapper.Initialize(config =>
           {
               config.CreateMap<AddCarBindingModel, Car>().ForMember(car => car.Parts, configurationExpression => configurationExpression.Ignore());
               config.CreateMap<Supplier, SupplierViewModel>().ForMember(vm=>vm.NumberOfPartsToSupply, cofigurationExppresion => cofigurationExppresion.MapFrom(s=>s.Parts.Count));
               config.CreateMap<AddCustomerBindingModel, Customer>();
               config.CreateMap<EditCustomerBindingModel, Customer>();
               config.CreateMap<Customer, EditCustomerBindingModel>();
               config.CreateMap<AddPartBindingModel, Part>();
               config.CreateMap<Part, AllPartViewModel>();
               config.CreateMap<Part, DeletePartViewModel>();
               config.CreateMap<Part, EditPartViewModel>();
               config.CreateMap<RegisterUserBindingModel, User>();
               config.CreateMap<Car, AddSaleCarViewModel>();
               config.CreateMap<Customer, AddSaleCustomerViewModel>();
               config.CreateMap<Supplier, SupplierViewModel>();
               config.CreateMap<Supplier, SuplierAllViewModel>();
               config.CreateMap<AddSupplierBindingModel, Supplier>();
               config.CreateMap<Supplier, EditSupplierViewModel>();
               config.CreateMap<Supplier, DeleteSuplierViewModel>();
           });


           //}); );
           // Mapper.Initialize(config => );
           // Mapper.Initialize(config => );
           // Mapper.Initialize(config => );
           // Mapper.Initialize(config => );
           // //Mapper.Initialize(config => config.CreateMap<AddCarBindingModel, Car>());
           // Mapper.Initialize(config => );
           // Mapper.Initialize(config => );
            
        } 
    }
}