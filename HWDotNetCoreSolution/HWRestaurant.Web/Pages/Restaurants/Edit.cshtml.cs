using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HWRestaurant.Core;
using HWRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HWRestaurant.Web.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }
        private readonly IHtmlHelper htmlHelper;

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        //public ActionResult OnGet(int restaurantId)
        //{
        //    Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();

        //    Restaurant = restaurantData.GetRestaurantByID(restaurantId);
        //    if (Restaurant == null)
        //    {
        //        return RedirectToPage("./NotFound");
        //    }
        //    return Page();
        //}

        public ActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantByID(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            //if (ModelState.IsValid)
            //{
            //    restaurantData.Update(Restaurant);
            //    restaurantData.Commit();
            //    return RedirectToPage("./Details", new { restaurantId = Restaurant.ID });
            //}
            ////just to keep/show the data inside the list or textbox in the UI, can be removed also
            //Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            //return Page();

            ////return RedirectToPage("./List");
            ///
            if(!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if(Restaurant.ID > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Add(Restaurant);
            }
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Details", new { restaurantId = Restaurant.ID });
        }
    }
}