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
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
				Restaurant = restaurantData.GetRestaurantById(restaurantId.Value);
            }else
            {
				Restaurant = new Restaurant();
			}
			if (Restaurant == null)
			{
				return RedirectToPage("./NotFound");
			}
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
			return Page();
        }

		public IActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
                if (Restaurant.Id > 0)
                {
					restaurantData.Update(Restaurant);
                }else
                {
					restaurantData.Add(Restaurant);
				}
				//This temp data will be cleared on reloading the page
				TempData["Message"] = "Restaurant Saved!!";
				return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
			}
			Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
			return Page();
		}
    }
}
