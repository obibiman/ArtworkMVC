using System;

namespace Artist.UI.ViewModels
{
    public class TelephoneViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}