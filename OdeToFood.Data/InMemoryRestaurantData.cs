using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> Restaurants;
        public InMemoryRestaurantData()
        {
            Restaurants = new List<Restaurant>
            {
                new Restaurant(){Id = 1,  Name = "Scott's Pizza",Location = "MaryLand",Cuisine = CuisineType.Italian},
                new Restaurant(){Id = 2,  Name = "Cinnamon Club",Location = "London",Cuisine = CuisineType.Mexican},
                new Restaurant(){Id = 3,  Name = "La Costa",Location = "California",Cuisine = CuisineType.Indian},
            };
        }
        public Restaurant GetById(int id)
        {
            return Restaurants.SingleOrDefault(x => x.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(x => x.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            Restaurants.Add(newRestaurant);
            newRestaurant.Id = Restaurants.Max(x => x.Id) + 1;
            return newRestaurant;
        }
        public Restaurant Delete(int id)
        {
            var resutarant = Restaurants.FirstOrDefault(x => x.Id == id);
            if(resutarant != null)
                Restaurants.Remove(resutarant);
            return resutarant;
        }
        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public int GetCountOfRestaurants()
        {
            return Restaurants.Count;
        }
    }
}
