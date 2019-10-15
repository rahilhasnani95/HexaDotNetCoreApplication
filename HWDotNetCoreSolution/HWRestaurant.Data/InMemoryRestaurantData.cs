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
                new Restaurant{ID=3, Name="Chicken", Location="Dallas", Cuisine= CuisineType.Italian},
                new Restaurant{ID=4, Name="Burger", Location="California", Cuisine= CuisineType.None}

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

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.ID == updatedRestaurant.ID);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
            return newRestaurant;
        }
    }
}
