﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DistrictVM
    {
        public int id { get; set; }
        public string DistrictName { get; set; }
        public int CityId { get; set; }
    }
}