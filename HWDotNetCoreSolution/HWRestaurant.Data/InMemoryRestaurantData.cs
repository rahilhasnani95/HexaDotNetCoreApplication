using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;

namespace HWRestaurant.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1, Name="Pizza", Location="Houston", Cuisine= CuisineType.Indian},
                new Restaurant{ID=2, Name="Burger", Location="Atlanta", Cuisine= CuisineType.Mexican},
                new Restaurant{ID=3, Name="Chicken", Location="Dallas", Cuisine= CuisineType.Italian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   select r;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantByID(int id)
        {
            return restaurants.SingleOrDefault(r => r.ID == id);
        }
    }
}
