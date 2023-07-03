using Core.Entities;

namespace Core.Interfaces
{
    public interface IPropertyService
    {
        Task<IReadOnlyList<Property>> GetPropertiesByManagementCompany(int managementCompanyId);
        Task<IReadOnlyList<Property>> GetPropertiesByCompanyOwner(int companyOwnerId);
        Task<IReadOnlyList<Property>> GetPropertiesByPrivateOwner(int privateOwnerId);
        Task<Property> GetPropertyById(int propertyId);
        Task CreatePropertyOwnershipStructure(int propertyId, PropertyOwnershipStructure propertyOwnershipStructure);
        Task UpdatePropertyOwnershipStructure(int propertyId, PropertyOwnershipStructure propertyOwnershipStructure);
    }
}