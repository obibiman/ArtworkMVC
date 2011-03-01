using System;

namespace Artist.UI.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? LineItemTotal { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}