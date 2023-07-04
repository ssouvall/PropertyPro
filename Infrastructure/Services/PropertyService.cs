using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;

namespace Infrastructure.Services
{
    public class PropertyService : IPropertyService
    {
        private IGenericRepository<Property> _propertiesRepo;
        private IGenericRepository<PropertyOwnershipStructure> _propertyOwnershipStructureRepo;
        public PropertyService(IGenericRepository<Property> propertiesRepo,
            IGenericRepository<PropertyOwnershipStructure> propertyOwnershipStructureRepo)
        {
            _propertiesRepo = propertiesRepo;
            _propertyOwnershipStructureRepo = propertyOwnershipStructureRepo;
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
        public async Task SavePropertyOwnershipStructure(int propertyId, PropertyOwnershipStructure propertyOwnershipStructure)
        {
            var property = await _propertiesRepo.GetByIdAsync(propertyId);
            property.PropertyOwnershipStructure = propertyOwnershipStructure;
            _propertiesRepo.Update(property);
        }

        public async Task<Property> GetPropertyById(int propertyId)
        {
            var spec = new PropertiesWithAllAttributesSpecification(propertyId);
            return await _propertiesRepo.GetEntityWithSpec(spec);
        }

        public async Task CreateProperty(Property property)
        {
            _propertiesRepo.Add(property);
        }

        public async Task UpdateProperty(Property property)
        {
           _propertiesRepo.Update(property);
        }

        public async Task DeleteProperty(int propertyId)
        {
            _propertiesRepo.Delete(propertyId);
        }
    }
}