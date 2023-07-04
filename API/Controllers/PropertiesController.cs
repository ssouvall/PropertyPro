using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private IPropertyService _propertyService;
        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
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
        public async Task<IActionResult> EditProperty(Property property)
        {
            return Ok(_propertyService.UpdateProperty(property));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            return Ok(_propertyService.DeleteProperty(id));
        }
    }
}