using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyOwnershipsController : BaseApiController
    {
        private IGenericRepository<CompanyOwnership> _companyOwnershipsRepo;
        public CompanyOwnershipsController(IGenericRepository<CompanyOwnership> companyOwnershipsRepo)
        {
            _companyOwnershipsRepo = companyOwnershipsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyOwner>>> GetCompanyOwnerships()
        {
            var companyOwnerships = await _companyOwnershipsRepo.ListAllAsync();
            return Ok(companyOwnerships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwner>> GetCompanyOwnerShipById(int id)
        {
            var companyOwnership = await _companyOwnershipsRepo.GetByIdAsync(id);
            return Ok(companyOwnership);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompanyOwnership(CompanyOwnership companyOwnership)
        {
            await _companyOwnershipsRepo.Add(companyOwnership);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCompanyOwnership(int id, CompanyOwnership companyOwnership)
        {
            companyOwnership.Id = id;
            await _companyOwnershipsRepo.Update(companyOwnership);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyOwnership(int id)
        {
            await _companyOwnershipsRepo.Delete(id);
            return Ok();
        }   
    }
}