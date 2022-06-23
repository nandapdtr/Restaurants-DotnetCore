using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
		[BindProperty]
		public Restaurant Restaurant { get; set; }
		public IEnumerable<SelectListItem> Cuisines { get; set; }
		private readonly IHtmlHelper htmlHelper;

		private readonly IRestaurantData restaurantData;

		public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
		{
			this.restaurantData = restaurantData;
			this.htmlHelper = htmlHelper;
		}
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetRestaurantById(restaurantId);
			if (Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
			return Page();
        }

		public void OnPost()
		{
			restaurantData.Update(Restaurant);
		}
    }
}
