using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleAspNetCoreApp.Models;
using SampleAspNetCoreApp.Models.Database;
using SampleAspNetCoreApp.Models.Interfaces;
using SampleAspNetCoreApp.Models.UnitOfWork;

namespace SampleAspNetCoreApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Property")]
    public class PropertyController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public PropertyController(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }

        [HttpGet("[action]")]
        public IActionResult GetProperties()
        {
            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                return new JsonResult(unitOfWork.PropertyRepository.GetAll());
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetProperty(int id)
        {
            if (id < 0)
            {
                return BadRequest("id cannot be less then 0");
            }

            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                return new JsonResult(unitOfWork.PropertyRepository.Get(id));
            }
        }

        [HttpPost("[action]")]
        public IActionResult AddProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var owner = unitOfWork.OwnerRepository.Get(property.OwnerId);
                if (owner == null)
                {
                    return NotFound("Cannot find owner with provided id");
                }

                var address = unitOfWork.AddressRepository.Get(property.AddressId);
                if (address == null)
                {
                    return NotFound("Cannot find address with provided id");
                }
                unitOfWork.PropertyRepository.Add(property);
                unitOfWork.Save();
                return new JsonResult(property.Id);
            }
        }

        [HttpPost("[action]")]
        public IActionResult UpdateProperty([FromBody] Property property)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                unitOfWork.PropertyRepository.Update(property);
                unitOfWork.Save();
                return new JsonResult(property.Id);
            }
        }

        [HttpGet("[action]")]
        public IActionResult DeleteProperty(int id)
        {
            if (id < 0)
            {
                return BadRequest("Id cannot be less then 0");
            }

            using (var unitOfWork = new UnitOfWork(this._databaseContext))
            {
                var property = unitOfWork.PropertyRepository.Get(id);
                if (property == null)
                {
                    return NotFound("Property not found");
                }
                unitOfWork.PropertyRepository.Remove(property);
                unitOfWork.Save();
                return new JsonResult(id);
            }
        }
    }
}