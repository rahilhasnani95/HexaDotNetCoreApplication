using System;
using System.Collections.Generic;
using System.Text;
using HWRestaurant.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HWRestaurant.Data
{
    public class SQLRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;
        public SQLRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantByID(id);
            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurantByID(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            //use using System.Linq;
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name)
                        || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updateRestaurant)
        {
            var entity = db.Restaurants.Attach(updateRestaurant);
            entity.State = EntityState.Modified;
            return updateRestaurant;
        }
        public int Commit()
        {
           return db.SaveChanges();
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }
    }
}
