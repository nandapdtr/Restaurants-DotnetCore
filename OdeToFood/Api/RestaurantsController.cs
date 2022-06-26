using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OddToFoodDbContext context;

        public RestaurantsController(OddToFoodDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return context.Restaurants;
        }
    }
}
