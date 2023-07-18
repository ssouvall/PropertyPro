using API.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace API.Controllers
{
    public class CompanyOwnershipsController : BaseApiController
    {
        private IMapper _mapper;
        private IGenericRepository<CompanyOwnership> _companyOwnershipsRepo;
        public CompanyOwnershipsController(IGenericRepository<CompanyOwnership> companyOwnershipsRepo, IMapper mapper)
        {
            _companyOwnershipsRepo = companyOwnershipsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyOwnershipDto>>> GetCompanyOwnerships()
        {
            var companyOwnerships = await _companyOwnershipsRepo.ListAllAsync();
            var companyOwnershipsToReturn = _mapper.Map<IReadOnlyList<CompanyOwnership>, IReadOnlyList<CompanyOwnershipDto>>(companyOwnerships);
            return Ok(companyOwnershipsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwnershipDto>> GetCompanyOwnerShipById(int id)
        {
            var companyOwnership = await _companyOwnershipsRepo.GetByIdAsync(id);
            var companyOwnershipToReturn = _mapper.Map<CompanyOwnership, CompanyOwnershipDto>(companyOwnership);
            return Ok(companyOwnershipToReturn);
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