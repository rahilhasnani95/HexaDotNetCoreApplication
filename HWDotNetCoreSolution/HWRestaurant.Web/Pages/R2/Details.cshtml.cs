using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HWRestaurant.Core;
using HWRestaurant.Data;

namespace HWRestaurant.Web.Pages.R2
{
    public class DetailsModel : PageModel
    {
        private readonly HWRestaurant.Data.RestaurantDbContext _context;

        public DetailsModel(HWRestaurant.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.ID == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
