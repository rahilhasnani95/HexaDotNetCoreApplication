using HWRestaurant.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HWRestaurant.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantByID(int id);
        Restaurant Update(Restaurant updateRestaurant);
        int Commit();

        Restaurant Add(Restaurant newRestaurant);

    }
}
