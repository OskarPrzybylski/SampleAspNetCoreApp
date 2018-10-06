using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SampleAspNetCoreApp.Models.Database;
using SampleAspNetCoreApp.Models.Interfaces;

namespace SampleAspNetCoreApp.Models.Repositories
{
    public class PropertyRepository : GenericRepository<Property>, IPropertyRepository
    {
        public IEnumerable<Property> GetPropertiesByType(PropertyType propertyType)
        {
            return this.DatabaseContext.Properties.Where(x => x.Type == propertyType);
        }

        public PropertyRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
