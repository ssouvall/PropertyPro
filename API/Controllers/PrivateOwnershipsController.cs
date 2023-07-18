using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PrivateOwnershipsController : BaseApiController
    {
        private IGenericRepository<PrivateOwnership> _privateOwnershipsRepo;
        private IMapper _mapper;
        public PrivateOwnershipsController(IGenericRepository<PrivateOwnership> privateOwnershipsRepo,
            IMapper mapper)
        {
            _privateOwnershipsRepo = privateOwnershipsRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PrivateOwnershipDto>>> GetPrivateOwnerships()
        {
            var privateOwnerships = await _privateOwnershipsRepo.ListAllAsync();
            var privateOwnershipsToReturn = _mapper.Map<IReadOnlyList<PrivateOwnership>, IReadOnlyList<PrivateOwnershipDto>>(privateOwnerships);
            return Ok(privateOwnershipsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateOwnershipDto>> GetPrivateOwnerShipById(int id)
        {
            var privateOwnership = await _privateOwnershipsRepo.GetByIdAsync(id);
            var privateOwnershipToReturn = _mapper.Map<PrivateOwnership, PrivateOwnershipDto>(privateOwnership);
            return Ok(privateOwnershipToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrivateOwnership(PrivateOwnership privateOwnership)
        {
            await _privateOwnershipsRepo.Add(privateOwnership);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPrivateOwnership(int id, PrivateOwnership privateOwnership)
        {
            privateOwnership.Id = id;
            await _privateOwnershipsRepo.Update(privateOwnership);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivateOwnership(int id)
        {
            await _privateOwnershipsRepo.Delete(id);
            return Ok();
        } 
    }
}