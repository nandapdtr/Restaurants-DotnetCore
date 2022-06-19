using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        //The below method will be called when this page is requested in the browser
        public void OnGet()
        {
            Message = "Hello World!";
        }
    }
}
