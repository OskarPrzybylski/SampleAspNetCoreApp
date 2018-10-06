using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleAspNetCoreApp.Models.Database;
using SampleAspNetCoreApp.Models.Interfaces;

namespace SampleAspNetCoreApp.Models.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
