using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropertiesController : BaseApiController
    {
        private IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Property>>> GetProperties()
        {
            var properties = await _propertyService.GetProperties();
            return Ok(properties);
        }

        [HttpGet("propertiesByCompanyOwner/{companyOwnerId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByCompanyOwner(int companyOwnerId)
        {
            var properties = await _propertyService.GetPropertiesByCompanyOwner(companyOwnerId);
            return Ok(properties);
        }

        [HttpGet("propertiesByPrivateOwner/{privateOwnerId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByPrivateOwner(int privateOwnerId)
        {
            var properties = await _propertyService.GetPropertiesByPrivateOwner(privateOwnerId);
            return Ok(properties);
        }

        [HttpGet("propertiesByManagementCompany/{managementCompanyId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByManagementCompany(int managementCompanyId)
        {
            var properties = await _propertyService.GetPropertiesByManagementCompany(managementCompanyId);
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyById(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProperty(Property property)
        {
            await _propertyService.CreateProperty(property);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProperty(int id, Property property)
        {
            property.Id = id;
            await _propertyService.UpdateProperty(property);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeleteProperty(id);
            return Ok();
        }
    }
}