using ASP.NET.CoreRazorAPP.Pages;

namespace ASP.NET.CoreRazorAPP.Models
{
    public class Item
    {
        // public Product urun { get; set; }
        public int Id { get; set; }
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int quantity { get; set; }


    }
}
