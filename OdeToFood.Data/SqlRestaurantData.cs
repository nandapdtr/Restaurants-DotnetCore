using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OddToFoodDbContext db;

        public SqlRestaurantData(OddToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            db.Add(restaurant);
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            return from restaurant in db.Restaurants
                   where restaurant.Name.StartsWith(name) || String.IsNullOrEmpty(name)
                   orderby restaurant.Name
                   select restaurant;
        }

        public Restaurant Update(Restaurant restaurant)
        {
            var entity = db.Restaurants.Attach(restaurant);
            entity.State = EntityState.Modified;
            return restaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }
    }
}
