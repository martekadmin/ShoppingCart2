using ASP.NET.CoreRazorAPP.Helpers;
using ASP.NET.CoreRazorAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;


namespace ASP.NET.CoreRazorAPP.Pages
{
    public class SepetModel : PageModel
    {

        public double total { get; set; }

        public List<Item> cart { get; set; }

        //public void OnGet()
        //{
        //    var x = 1;

        //}

        public IActionResult OnGet()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                total = (double)cart.Sum(x => x.Price * x.quantity);
            }

            return Page();
        }

        public IActionResult OnGetBuy(int id)
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                total = (double)cart.Sum(x => x.Price * x.quantity);
            }

            if (cart == null)
            {
                cart = new List<Item>();

                ProductModel urunModel = new ProductModel();

                var urun = urunModel.find(id);
                if(urun is null) return RedirectToPage("/ErrorPage");
                var torba = new Item();

                torba.quantity = 1;
                torba.ProductName = urun.ProductName;
                torba.ProductCode = urun.ProductCode;
                torba.Price = urun.Price;
                torba.Id = id;

                cart.Add(torba);

                // cart.Add(new Item { Id = id, Price = urun.Price, ProductName = urun.ProductName, ProductCode = urun.ProductCode, quantity = 1 });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);



            }
            else
            {
               var urun = ProductModel.findProduct(id);
               cart.Add(new Item { Id = id, quantity = 1, Price = urun.Price, ProductName = urun.ProductName, ProductCode = urun.ProductCode });

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToPage("/ProductPage");

        }

        public IActionResult OnGetDelete(int id)
        {

            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            int index = cart.Count;

            for (int i = 0; i < index; i++)
            {
                if (cart[i].Id == id)
                {
                    cart.RemoveAt(i);
                    break;
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return Page();
        }


        

        public IActionResult OnPost(int[] quantities)
        {

            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                int index = cart.Count;

                for (int i = 0; i < index; i++)
                {
                    cart[i].quantity = quantities[i];
                }

                total = (double)cart.Sum(x => x.Price * x.quantity);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            
            
                return Page();
            
        }

       


    }

}
