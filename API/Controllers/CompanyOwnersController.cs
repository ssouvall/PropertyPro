using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyOwnersController : BaseApiController
    {
        private IGenericRepository<CompanyOwner> _companyOwnersRepo;
        private IMapper _mapper;
        public CompanyOwnersController(IGenericRepository<CompanyOwner> companyOwnersRepo,
            IMapper mapper)
        {
            _companyOwnersRepo = companyOwnersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyOwnerDto>>> GetCompanyOwners()
        {
            var companyOwners = await _companyOwnersRepo.ListAllAsync();
            var companyOwnersToReturn = _mapper.Map<IReadOnlyList<CompanyOwner>, IReadOnlyList<CompanyOwnerDto>>(companyOwners);
            return Ok(companyOwners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwnerDto>> GetCompanyOwnerById(int id)
        {
            var companyOwner = await _companyOwnersRepo.GetByIdAsync(id);
            var companyOwnerToReturn = _mapper.Map<CompanyOwner, CompanyOwnerDto>(companyOwner);
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