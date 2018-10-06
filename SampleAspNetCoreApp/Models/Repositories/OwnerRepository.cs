using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SampleAspNetCoreApp.Models.Database;
using SampleAspNetCoreApp.Models.Interfaces;

namespace SampleAspNetCoreApp.Models.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public IEnumerable<Property> GetOwnerProperties(int id)
        {
            return this.DatabaseContext.Properties.Where(x => x.OwnerId == id).ToList();
        }
    }
}
