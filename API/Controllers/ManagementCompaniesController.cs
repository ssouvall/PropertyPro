using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ManagementCompaniesController : BaseApiController
    {
        private IGenericRepository<ManagementCompany> _managementCompaniesRepo;
        private IMapper _mapper;
        public ManagementCompaniesController(IGenericRepository<ManagementCompany> managementCompaniesRepo,
            IMapper mapper)
        {
            _managementCompaniesRepo = managementCompaniesRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ManagementCompanyDto>>> GetManagementCompanies()
        {
            var managementCompanies = await _managementCompaniesRepo.ListAllAsync();
            var managementCompaniesToReturn = _mapper.Map<IReadOnlyList<ManagementCompany>, IReadOnlyList<ManagementCompanyDto>>(managementCompanies);
            return Ok(managementCompaniesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ManagementCompanyDto>> GetManagementCompanyById(int id)
        {
            var managementCompany = await _managementCompaniesRepo.GetByIdAsync(id);
            var managementCompanyToReturn = _mapper.Map<ManagementCompany, ManagementCompanyDto>(managementCompany);
            return Ok(managementCompanyToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateManagementCompany(ManagementCompany managementCompany)
        {
            await _managementCompaniesRepo.Add(managementCompany);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditManagementCompany(int id, ManagementCompany managementCompany)
        {
            managementCompany.Id = id;
            await _managementCompaniesRepo.Update(managementCompany);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagementCompany(int id)
        {
            await _managementCompaniesRepo.Delete(id);
            return Ok();
        }

        public override bool Equals(object? obj)
        {
            return obj is ManagementCompaniesController controller &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, controller._mapper);
        }
    }
}