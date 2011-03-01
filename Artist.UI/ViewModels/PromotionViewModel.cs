using System;

namespace Artist.UI.ViewModels
{
    public class PromotionViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime? SalesStartDate { get; set; }
        public DateTime? SalesEndDate { get; set; }
        public decimal? PercentDiscount { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}