using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PrivateOwnersController : BaseApiController
    {
        private IGenericRepository<PrivateOwner> _privateOwnersRepo;
        public PrivateOwnersController(IGenericRepository<PrivateOwner> privateOwnersRepo)
        {
            _privateOwnersRepo = privateOwnersRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrivateOwner>>> GetPrivateOwners()
        {
            var privateOwners = await _privateOwnersRepo.ListAllAsync();
            return Ok(privateOwners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateOwner>> GetPrivateOwnerById(int id)
        {
            var privateOwner = await _privateOwnersRepo.GetByIdAsync(id);
            return Ok(privateOwner);
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