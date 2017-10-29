namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Data;
    using Models.ViewModels;
    using AutoMapper;
    using Models.BindingModels;

    public class SupplyerService : Service
    {
        public SupplyerService(CarDealerContext context) : base(context)
        {
        }
        public IEnumerable<SupplierViewModel> GetAllSuplyersByType(string supplyerType)
        {
            IEnumerable<Supplier> supplierWanted = GetSupplierModelByType(supplyerType);

            IEnumerable<SupplierViewModel> vm = Mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierViewModel>>(supplierWanted);
            return vm;
            
        }

        private IEnumerable<Supplier> GetSupplierModelByType(string supplyerType)
        {
            IEnumerable<Supplier> suppliersWanted;
            if (supplyerType == null)
            {
                suppliersWanted = this.Context.Suppliers;
            }
            else if (supplyerType.ToLower() == "local")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => !supplier.IsImporter);
            }
            else if (supplyerType.ToLower() == "importers")
            {
                suppliersWanted = this.Context.Suppliers.Where(supplier => supplier.IsImporter);
            }
            else
            {
                throw new ArgumentException("Invalid argument for the type of the supplier!");
            }

            return suppliersWanted;
        }

        public IEnumerable<SuplierAllViewModel> GetAllSupplierByTypeForUser(string supplyerType)
        {
            IEnumerable<Supplier> suppliersWanted = this.GetSupplierModelByType(supplyerType);

            IEnumerable<SuplierAllViewModel> viewModels =
               Mapper.Map<IEnumerable<Supplier>, IEnumerable<SuplierAllViewModel>>(suppliersWanted);

            return viewModels;
        }

        public void AddSupplier(AddSupplierBindingModel bind, int id)
        {
            Supplier supplier = Mapper.Map<AddSupplierBindingModel, Supplier>(bind);
            this.Context.Suppliers.Add(supplier);
            this.Context.SaveChanges();
            this.AddLog(id, OperationLog.Add, "suppliers");
        }

        public EditSupplierViewModel GetEditSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            EditSupplierViewModel model = Mapper.Map<Supplier, EditSupplierViewModel>(supplier);
            return model;
        }

        public void EditSupplier(EditSupplierBindingModel bind, int userId)
        {
            Supplier model = this.Context.Suppliers.Find(bind.Id);
            model.IsImporter = bind.IsImporter == "on";
            model.Name = bind.Name;
            this.Context.SaveChanges();

            this.AddLog(userId, OperationLog.Edit, "suppliers");
        }

        public DeleteSuplierViewModel GetDeleteSupplierVm(int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(id);
            DeleteSuplierViewModel vm = Mapper.Map<Supplier, DeleteSuplierViewModel>(supplier);
            return vm;
        }

        public void DeleteSupplier(DeleteSupplierBindingModel bind, int id)
        {
            Supplier supplier = this.Context.Suppliers.Find(bind.Id);
            this.Context.Suppliers.Remove(supplier);
            this.Context.SaveChanges();

            this.AddLog(id, OperationLog.Delete, "suppliers");
        }

        private void AddLog(int userId, OperationLog operation, string modifiedTable)
        {
            User loggedUser = this.Context.Users.Find(userId);
            Log log = new Log()
            {
                User = loggedUser,
                ModifiedAt = DateTime.Now,
                ModifiedTableName = modifiedTable,
                Operation = operation
            };

            this.Context.Logs.Add(log);
            this.Context.SaveChanges();
        }
    }
}
