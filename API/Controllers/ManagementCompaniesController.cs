using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ManagementCompaniesController : BaseApiController
    {
        private IGenericRepository<ManagementCompany> _managementCompaniesRepo;
        public ManagementCompaniesController(IGenericRepository<ManagementCompany> managementCompaniesRepo)
        {
            _managementCompaniesRepo = managementCompaniesRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyOwner>>> GetManagementCompanies()
        {
            var managementCompanies = await _managementCompaniesRepo.ListAllAsync();
            return Ok(managementCompanies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwner>> GetManagementCompanyById(int id)
        {
            var managementCompany = await _managementCompaniesRepo.GetByIdAsync(id);
            return Ok(managementCompany);
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
    }
}