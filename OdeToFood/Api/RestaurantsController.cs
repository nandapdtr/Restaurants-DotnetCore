using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantsController(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            try
            {
                var restaurants = restaurantData.GetAll();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return BadRequest($"BAd request {ex}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            try
            {
                var restaurant = restaurantData.GetRestaurantById(id);
                if (restaurant != null)
                {
                    return Ok(restaurant);
                }
            }
            catch
            {
                return BadRequest();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                restaurantData.Add(restaurant);
                restaurantData.Commit();
                return CreatedAtAction(nameof(GetRestaurantById), new { id = restaurant.Id }, restaurant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateRestaurant([FromBody] Restaurant restaurant)
        {
            try
            {
                //Need to verify the error happening here
                //var res = restaurantData.GetRestaurantById(restaurant.Id);
                //if (res == null)
                //{
                //    return NotFound();
                //}
                restaurantData.Update(restaurant);
                restaurantData.Commit();
                return Ok(restaurant);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteRestaurant(int id)
        {
            try
            {
                var res = restaurantData.Delete(id);
                if (res != null)
                {
                    restaurantData.Commit();
                    return Ok(res);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return NotFound();
        }
    }
}
