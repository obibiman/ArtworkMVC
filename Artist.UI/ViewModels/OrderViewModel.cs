using System;

namespace Artist.UI.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}