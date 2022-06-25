using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
