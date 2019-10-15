﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HWRestaurant.Core
{
    //public class Restaurant
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //    public string Location { get; set; }
    //    public CuisineType Cuisine { get; set; }

    //}

    public class Restaurant
    {
        public int ID { get; set; }

        [Required, StringLength(80)]
        public string Name { get; set; }

        [Required, StringLength(80)]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }
    }
}
