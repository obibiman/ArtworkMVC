using System;

namespace Artist.UI.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MimeType { get; set; }
        public byte[] Image { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}