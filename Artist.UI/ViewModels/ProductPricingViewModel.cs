using System;

namespace Artist.UI.ViewModels
{
    public class ProductPricingViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}