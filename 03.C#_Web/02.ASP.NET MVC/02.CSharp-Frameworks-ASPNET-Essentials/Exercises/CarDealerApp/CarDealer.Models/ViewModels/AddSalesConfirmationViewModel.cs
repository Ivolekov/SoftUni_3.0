﻿namespace CarDealer.Models.ViewModels
{
    public class AddSalesConfirmationViewModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int CarId { get; set; }

        public string CarRepresentation { get; set; }

        public decimal Discount { get; set; }

        public decimal CarPrice { get; set; }

        public decimal FinalCarPrice { get; set; }
    }
}
