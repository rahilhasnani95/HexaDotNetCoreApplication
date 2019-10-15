using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HWRestaurant.Web.Pages.Restaurants
{
    public class DetailsModel : PageModel
    {
        [TempData]
        public string Message { get; set; }

        private readonly IRestaurantData restaurantData;
        public Restaurant Restaurant { get; set; }

        public DetailsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public ActionResult OnGet(int restaurantId)
        {
            //Restaurant = new Restaurant();
            //Restaurant.ID = restaurantId;

            Restaurant = restaurantData.GetRestaurantByID(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}