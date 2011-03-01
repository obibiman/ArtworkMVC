using System.Collections.Generic;
using System.Web.Mvc;

namespace Artist.UI.ViewModels
{
    public class CustomerDropdownViewModel
    {
        public string SelectedCustomer { get; set; }
        public IEnumerable<SelectListItem> SelectedCustomers { get; set; }
    }
}