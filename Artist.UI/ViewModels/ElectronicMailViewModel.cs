using System;

namespace Artist.UI.ViewModels
{
    public class ElectronicMailViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}