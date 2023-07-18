using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PropertiesController : BaseApiController
    {
        private IPropertyService _propertyService;
        private IMapper _mapper;
        public PropertiesController(IPropertyService propertyService, IMapper mapper)
        {
            _propertyService = propertyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PropertyDto>>> GetProperties()
        {
            var properties = await _propertyService.GetProperties();
            var propertiesToReturn = _mapper.Map<IReadOnlyList<Property>, IReadOnlyList<PropertyDto>>(properties);
            return Ok(propertiesToReturn);
        }

        [HttpGet("propertiesByCompanyOwner/{companyOwnerId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByCompanyOwner(int companyOwnerId)
        {
            var properties = await _propertyService.GetPropertiesByCompanyOwner(companyOwnerId);
            var propertiesToReturn = _mapper.Map<IReadOnlyList<Property>, IReadOnlyList<PropertyDto>>(properties);
            return Ok(propertiesToReturn);
        }

        [HttpGet("propertiesByPrivateOwner/{privateOwnerId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByPrivateOwner(int privateOwnerId)
        {
            var properties = await _propertyService.GetPropertiesByPrivateOwner(privateOwnerId);
            var propertiesToReturn = _mapper.Map<IReadOnlyList<Property>, IReadOnlyList<PropertyDto>>(properties);
            return Ok(propertiesToReturn);
        }

        [HttpGet("propertiesByManagementCompany/{managementCompanyId}")]
        public async Task<ActionResult<List<Property>>> GetPropertiesByManagementCompany(int managementCompanyId)
        {
            var properties = await _propertyService.GetPropertiesByManagementCompany(managementCompanyId);
            var propertiesToReturn = _mapper.Map<IReadOnlyList<Property>, IReadOnlyList<PropertyDto>>(properties);
            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyById(id);
            var propertyToReturn = _mapper.Map<Property, PropertyDto>(property);
            return Ok(propertyToReturn);
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