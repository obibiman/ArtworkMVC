using System;

namespace Artist.UI.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MI { get; set; }
        public string LastName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CustomerName { get; set; }
    }
}