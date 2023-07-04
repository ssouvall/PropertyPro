using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PrivateOwnershipsController : BaseApiController
    {
        private IGenericRepository<PrivateOwnership> _privateOwnershipsRepo;
        public PrivateOwnershipsController(IGenericRepository<PrivateOwnership> privateOwnershipsRepo)
        {
            _privateOwnershipsRepo = privateOwnershipsRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrivateOwner>>> GetPrivateOwnerships()
        {
            var privateOwnerships = await _privateOwnershipsRepo.ListAllAsync();
            return Ok(privateOwnerships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateOwner>> GetPrivateOwnerShipById(int id)
        {
            var privateOwnership = await _privateOwnershipsRepo.GetByIdAsync(id);
            return Ok(privateOwnership);
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