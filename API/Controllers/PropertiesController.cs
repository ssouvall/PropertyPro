using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private IGenericRepository<Property> _propertiesRepo;
        public PropertiesController(IGenericRepository<Property> propertiesRepo)
        {
            _propertiesRepo = propertiesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Property>>> GetProperties()
        {
            var spec = new PropertiesWithTypesSpecification();
            var properties = await _propertiesRepo.ListAsync(spec);

            return Ok(properties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var spec = new PropertiesWithTypesSpecification(id);
            return Ok(await _propertiesRepo.GetEntityWithSpec(spec));
        }
    }
}