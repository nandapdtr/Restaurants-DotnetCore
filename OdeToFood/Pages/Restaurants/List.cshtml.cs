using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        private IRestaurantData restaurantData { get; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        //The below method will be called when this page is requested in the browser
        public void OnGet()
        {
            Message = "Hello World!";
            Restaurants = restaurantData.GetAll();
        }
    }
}
