using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> restaurants { get; set; }
        public InMemoryRestaurantData()
        {
            this.restaurants = new List<Restaurant>()
            {
                new Restaurant(){Id=1, Name="Kritunga", Location="India", Cuisine = CuisineType.Indian},
                new Restaurant(){Id=2, Name="Some Italian", Location="Italy", Cuisine = CuisineType.Italian},
                new Restaurant(){Id=1, Name="Some Mexican", Location="Mexico", Cuisine = CuisineType.Mexican},
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where String.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
