using OdeToFood.Core;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedResturant);
        Restaurant Add(Restaurant newResturant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }
}
