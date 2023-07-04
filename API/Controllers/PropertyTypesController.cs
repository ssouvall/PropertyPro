using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropertyTypesController : BaseApiController
    {
        private IGenericRepository<PropertyType> _propertyTypesRepo;
        public PropertyTypesController(IGenericRepository<PropertyType> propertyTypesRepo)
        {
            _propertyTypesRepo = propertyTypesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyType>>> GetPropertyTypes()
        {
            var propertyTypes = await _propertyTypesRepo.ListAllAsync();
            return Ok(propertyTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyType>> GetPropertyTypeById(int id)
        {
            var propertyType = await _propertyTypesRepo.GetByIdAsync(id);
            return Ok(propertyType);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePropertyType(PropertyType propertyType)
        {
            await _propertyTypesRepo.Add(propertyType);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPropertyType(int id, PropertyType propertyType)
        {
            propertyType.Id = id;
            await _propertyTypesRepo.Update(propertyType);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePropertyType(int id)
        {
            await _propertyTypesRepo.Delete(id);
            return Ok();
        }
    }
}