﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly HWRestaurant.Data.RestaurantDbContext _context;

        public IndexModel(HWRestaurant.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
