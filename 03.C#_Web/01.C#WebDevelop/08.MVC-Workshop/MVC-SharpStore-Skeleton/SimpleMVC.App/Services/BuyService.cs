namespace SimpleMVC.App.Services
{
    using System;
    using SimpleMVC.App.BindingModels;
    using SimpleMVC.App.Data;
    using SimpleMVC.App.Models;

    public class BuyService : Service
    {
        public BuyService(SharpStoreContext context) : base(context)
        {
        }

        public void AddPurchise(PurchaseViewModel purchaseViewModel)
        {
            Purchase purchase = new Purchase();
            purchase.BuyerName = purchaseViewModel.BuyerName;
            purchase.DeliveryType = (DeliveryType) Enum.Parse(typeof(DeliveryType), purchaseViewModel.DeliveryType);
            purchase.BuyerAddress = purchaseViewModel.BuyerAddress;
            purchase.BuyerPhone = purchaseViewModel.BuyerPhone;

            this.context.Purchases.Add(purchase);
            this.context.SaveChanges();
        }
    }
}
