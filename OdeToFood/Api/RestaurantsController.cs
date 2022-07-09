using AutoMapper;
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
        private readonly IMapper mapper;

        public RestaurantsController(IRestaurantData restaurantData, IMapper mapper)
        {
            this.restaurantData = restaurantData;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            try
            {
                var restaurants = restaurantData.GetAll();
                return Ok(mapper.Map<IEnumerable<RestaurantModel>>(restaurants));
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
                    return Ok(mapper.Map<RestaurantModel>(restaurant));
                }
            }
            catch
            {
                return BadRequest();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddRestaurant([FromBody] RestaurantModel restaurant)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var newRestaurant = mapper.Map<Restaurant>(restaurant);
                restaurantData.Add(newRestaurant);
                restaurantData.Commit();
                var model = mapper.Map<RestaurantModel>(newRestaurant);
                return CreatedAtAction(nameof(GetRestaurantById), new { id = model.RestaurantId }, model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateRestaurant([FromBody] RestaurantModel restaurant)
        {
            try
            {
                //Need to verify the error happening here
                //var res = restaurantData.GetRestaurantById(restaurant.Id);
                //if (res == null)
                //{
                //    return NotFound();
                //}
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var updatingRestaurant = mapper.Map<Restaurant>(restaurant);
                restaurantData.Update(updatingRestaurant);
                restaurantData.Commit();
                var model = mapper.Map<RestaurantModel>(updatingRestaurant);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
                    return Ok(mapper.Map<RestaurantModel>(res));
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
