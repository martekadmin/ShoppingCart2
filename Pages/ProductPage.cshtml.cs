using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace ASP.NET.CoreRazorAPP.Pages
{
    public class ProductPageModel : PageModel
    {
        public List<Product> productList { get; set; }

        public void OnGet()
        {
           /* ProductModel productModel = new ProductModel();

            productList = productModel.AllProducts();
           */

            string conStr = "Server=13.48.68.168;Database=ProductDB;User ID=sa;Password=Yukutu-123;MultipleActiveResultSets=true";

         using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string sql = "SELECT * FROM Product_TBL";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        productList = new List<Product>();
                        while (reader.Read())
                        {
                            Product urun = new Product();
                            urun.Id = reader.GetInt32(0);
                            urun.ProductName = reader.GetString(2);
                            urun.ProductCode = reader.GetInt32(1);
                            urun.Price = reader.GetDecimal(3);
                            urun.Color = reader.GetString(4);
                            productList.Add(urun);
                        }
                    }
                }
            }
        }
    }
}
