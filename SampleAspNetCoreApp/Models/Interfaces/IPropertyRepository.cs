﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAspNetCoreApp.Models.Interfaces
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetPropertiesByType(PropertyType propertyType);
    }
}
