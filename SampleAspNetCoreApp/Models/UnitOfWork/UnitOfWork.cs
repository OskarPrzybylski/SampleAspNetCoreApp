using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SampleAspNetCoreApp.Models.Database;
using SampleAspNetCoreApp.Models.Interfaces;
using SampleAspNetCoreApp.Models.Repositories;

namespace SampleAspNetCoreApp.Models.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        #region Fields
        private readonly DatabaseContext _databaseContext;
        private PropertyRepository _propertyRepository;
        private OwnerRepository _ownerRepository;
        private AddressRepository _addressRepository;
        private bool disposed = false;
        #endregion
        #region Constructors
        public UnitOfWork(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        #endregion
        #region Properties
        public PropertyRepository PropertyRepository
        {
            get
            {
                if (this._propertyRepository == null)
                {
                    this._propertyRepository = new PropertyRepository(_databaseContext);
                }

                return _propertyRepository;
            }
        }

        public OwnerRepository OwnerRepository
        {
            get
            {
                if (this._ownerRepository == null)
                {
                    this._ownerRepository = new OwnerRepository(this._databaseContext);
                }

                return this._ownerRepository;
            }
        }

        public AddressRepository AddressRepository
        {
            get
            {
                if (this._addressRepository == null)
                {
                    this._addressRepository = new AddressRepository(this._databaseContext);
                }

                return this._addressRepository;
            }
        }
        #endregion
        #region Methods
        public void Save() => this._databaseContext.SaveChanges();

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _databaseContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
