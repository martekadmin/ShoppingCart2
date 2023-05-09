using System.Data.SqlClient;
using System.Data;

namespace ASP.NET.CoreRazorAPP.Pages
{
    public class ProductModel
    {
        List<Product> products = new List<Product>();

        public ProductModel()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    ProductName = "Apple",
                    ProductCode = 123,
                    Price = 140
                },
                new Product()
                {
                    Id = 2,
                    ProductName = "Laptop",
                    ProductCode = 123,
                    Price = 80
                },
                new Product()
                {
                    Id = 3,
                    ProductName = "MacBook",
                    ProductCode = 123,
                    Price = 160
                },
                  new Product()
                {
                    Id = 4,
                    ProductName = "HP",
                    ProductCode = 123,
                    Price = 80
                }
            };
        }


        public List<Product> AllProducts()
        {
            return products;
        }

        public static Product findProduct(int id)
        {
            string conStr = "Server=13.48.68.168;Database=ProductDB;User ID=sa;Password=Yukutu-123;MultipleActiveResultSets=true";
            Product urun = new Product();
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string sql = "SELECT * FROM Product_TBL WHERE Id = @ParamId";
                SqlParameter ParamId = new SqlParameter();
                ParamId.ParameterName = "@ParamId"; // Defining Name  
                ParamId.SqlDbType = SqlDbType.Int; // Defining DataType  
                ParamId.Direction = ParameterDirection.Input; // Setting the direction  
                ParamId.Value = id;

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(ParamId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {

                            urun.Id = reader.GetInt32(0);
                            urun.ProductName = reader.GetString(2);
                            urun.ProductCode = reader.GetInt32(1);
                            urun.Price = reader.GetDecimal(3);
                            urun.Color = reader.GetString(4);

                        }
                    }
                }
            }

            return urun;
        }

        public Product find(int id)
        {
            return products.Where(x => x.Id == id).FirstOrDefault();
        }
    }
    

}
