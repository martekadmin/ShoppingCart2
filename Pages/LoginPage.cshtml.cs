using ASP.NET.CoreRazorAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET.CoreRazorAPP.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        public LoginModel login { get; set; }

        public string Msg { get; set; }

        


        public IActionResult OnPost()
        {
            string user = login.username;
            string password = login.password;
            

            if(user == "osman" && password == "1234")
            {
                return RedirectToPage("/ProductPage");
            }
            Msg = "Hatalý þifre!!";
            return Page(); 
        }
        

    }
}
