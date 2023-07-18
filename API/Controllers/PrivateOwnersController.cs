using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PrivateOwnersController : BaseApiController
    {
        private IGenericRepository<PrivateOwner> _privateOwnersRepo;
        private IMapper _mapper;
        public PrivateOwnersController(IGenericRepository<PrivateOwner> privateOwnersRepo, IMapper mapper)
        {
            _privateOwnersRepo = privateOwnersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PrivateOwnerDto>>> GetPrivateOwners()
        {
            var privateOwners = await _privateOwnersRepo.ListAllAsync();
            var privateOwnersToReturn = _mapper.Map<IReadOnlyList<PrivateOwner>, IReadOnlyList<PrivateOwnerDto>>(privateOwners);
            return Ok(privateOwnersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateOwnerDto>> GetPrivateOwnerById(int id)
        {
            var privateOwner = await _privateOwnersRepo.GetByIdAsync(id);
            var privateOwnerToReturn = _mapper.Map<PrivateOwner, PrivateOwnerDto>(privateOwner);
            return Ok(privateOwnerToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrivateOwner(PrivateOwner privateOwner)
        {
            await _privateOwnersRepo.Add(privateOwner);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPrivateOwner(int id, PrivateOwner privateOwner)
        {
            privateOwner.Id = id;
            await _privateOwnersRepo.Update(privateOwner);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrivateOwner(int id)
        {
            await _privateOwnersRepo.Delete(id);
            return Ok();
        }
    }
}