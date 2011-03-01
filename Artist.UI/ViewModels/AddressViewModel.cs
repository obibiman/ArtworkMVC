using System;

namespace Artist.UI.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Addr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}