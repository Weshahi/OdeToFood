using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext Context;

        public SqlRestaurantData(OdeToFoodDbContext context)
        {
            Context = context;
        }


        public Restaurant Add(Restaurant newResturant)
        {
            Context.Restaurants.Add(newResturant);
            return newResturant;
        }

        public int Commit()
        {
            return Context.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = Context.Restaurants.FirstOrDefault(x => x.Id == id);
            if (restaurant != null)
                Context.Restaurants.Remove(restaurant);
            return restaurant;

        }

        public Restaurant GetById(int id)
        {
            return Context.Restaurants.FirstOrDefault(x => x.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return Context.Restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from res in Context.Restaurants
                        where res.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby res.Name
                        select res;


            return query;
        }

        public Restaurant Update(Restaurant updatedResturant)
        {
            var entity = Context.Restaurants.Attach(updatedResturant);
            entity.State = EntityState.Modified;
            return updatedResturant;

        }
    }
}
