using System;
using System.Collections.Generic;
using Artist.DAO.EntityFrameWork;


namespace Artist.UI.ViewModels
{
    public class CustomerGridViewModel
    {
        // Constructor
        public CustomerGridViewModel()
        {
            // Define any default values here...
            PageSize = 10;
            NumericPageCount = 10;
        }

        // Data properties
        public IEnumerable<Customer> Customers { get; set; }

        // Paging-related properties
        public int CurrentPageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalRecordCount { get; set; }

        public int PageCount
        {
            get { return Math.Max(TotalRecordCount/PageSize, 1); }
        }

        public int NumericPageCount { get; set; }
    }
}