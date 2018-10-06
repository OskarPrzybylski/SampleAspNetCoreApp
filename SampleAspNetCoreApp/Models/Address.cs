﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAspNetCoreApp.Models
{
    public class Address : GenericModel
    {
        public string Street { get; set; }
        public string City { get; set; }
    }
}
