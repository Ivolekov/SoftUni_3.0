namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarDealer.Data;
    using Models.BindingModels;
    using Models;
    using AutoMapper;
    using Models.ViewModels;

    public class PartsService : Service
    {
        public PartsService(CarDealerContext context) : base(context)
        {
        }

        public IEnumerable<AllPartViewModel> GetAllParts()
        {
            IEnumerable<Part> parts = this.Context.Parts;
            IEnumerable<AllPartViewModel> partVm = Mapper.Map<IEnumerable<Part>, IEnumerable<AllPartViewModel>>(parts);
            return partVm;
        }

        public void AddPart(AddPartBindingModel addPartBindingModel)
        {
            Part part = Mapper.Map<AddPartBindingModel, Part>(addPartBindingModel);
            Supplier wantedSupplier = this.Context.Suppliers.Find(addPartBindingModel.SupplierId);
            part.Supplier = wantedSupplier;
            if (part.Quantity == 0)
            {
                part.Quantity = 1;
            }
            this.Context.Parts.Add(part);
            this.Context.SaveChanges();
        }

        public IEnumerable<AddPartSupplierViewModel> GetAddVM()
        {
            return this.Context.Suppliers.Select(s => new AddPartSupplierViewModel()
            {
                Id = s.Id,
                Name = s.Name
            });
        }

        public DeletePartViewModel GetDeleteVm(int id)
        {
            Part part = this.Context.Parts.Find(id);
            DeletePartViewModel dpvm = Mapper.Map<Part, DeletePartViewModel>(part);
            return dpvm;
        }

        public EditPartViewModel GetEditVm(int id)
        {
            Part part = this.Context.Parts.Find(id);
            EditPartViewModel vm = Mapper.Map<Part, EditPartViewModel>(part);
            return vm;
        }

        public void EditPart(EditPartBindingModel bind)
        {
            Part part = this.Context.Parts.Find(bind.Id);
            part.Quantity = bind.Quantity;
            part.Price = bind.Price;

            this.Context.SaveChanges();
        }

        public void DeletePartBm(DeletePartBindingModel bind)
        {
            Part part = this.Context.Parts.Find(bind.PartId);
            this.Context.Parts.Remove(part);
            this.Context.SaveChanges();
        }
    }
}
