using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private IGenericRepository<Property> _propertiesRepo;
        public PropertyService(IGenericRepository<Property> propertiesRepo)
        {
            _propertiesRepo = propertiesRepo;
        }

        public async Task<IReadOnlyList<Property>> GetPropertiesByCompanyOwner(int companyOwnerId)
        {
            var spec = new PropertiesByCompanyOwnerIdWithAllAttributesSpecification(companyOwnerId);
            return await _propertiesRepo.ListAsync(spec);
        }

        public async Task<IReadOnlyList<Property>> GetPropertiesByManagementCompany(int managementCompanyId)
        {
            var spec = new PropertiesByManagementCompanyIdWithAllAttributesSpecification(managementCompanyId);
            return await _propertiesRepo.ListAsync(spec);
        }

        public async Task<IReadOnlyList<Property>> GetPropertiesByPrivateOwner(int privateOwnerId)
        {
            var spec = new PropertiesByPrivateOwnerIdWithAllAttributesSpecification(privateOwnerId);
            return await _propertiesRepo.ListAsync(spec);
        }

        public async Task<Property> GetPropertyById(int propertyId)
        {
            var spec = new PropertiesWithAllAttributesSpecification(propertyId);
            return await _propertiesRepo.GetEntityWithSpec(spec);
        }

        public async Task CreateProperty(Property property)
        {
            await _propertiesRepo.Add(property);
        }

        public async Task UpdateProperty(Property property)
        {
           await _propertiesRepo.Update(property);
        }

        public async Task DeleteProperty(int propertyId)
        {
            await _propertiesRepo.Delete(propertyId);
        }
    }
}