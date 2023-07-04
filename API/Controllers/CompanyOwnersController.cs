using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyOwnersController : BaseApiController
    {
        private IGenericRepository<CompanyOwner> _companyOwnersRepo;
        public CompanyOwnersController(IGenericRepository<CompanyOwner> companyOwnersRepo)
        {
            _companyOwnersRepo = companyOwnersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyOwner>>> GetCompanyOwners()
        {
            var companyOwners = await _companyOwnersRepo.ListAllAsync();
            return Ok(companyOwners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwner>> GetCompanyOwnerById(int id)
        {
            var companyOwner = await _companyOwnersRepo.GetByIdAsync(id);
            return Ok(companyOwner);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyOwner(CompanyOwner companyOwner)
        {
            await _companyOwnersRepo.Add(companyOwner);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompanyOwner(int id, CompanyOwner companyOwner)
        {
            companyOwner.Id = id;
            await _companyOwnersRepo.Update(companyOwner);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyOwner(int id)
        {
            await _companyOwnersRepo.Delete(id);
            return Ok();
        }
    }
}