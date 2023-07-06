using Core.Entities;

namespace Core.Interfaces
{
    public interface IPropertyService
    {
        Task<IReadOnlyList<Property>> GetProperties();
        Task<IReadOnlyList<Property>> GetPropertiesByManagementCompany(int managementCompanyId);
        Task<IReadOnlyList<Property>> GetPropertiesByCompanyOwner(int companyOwnerId);
        Task<IReadOnlyList<Property>> GetPropertiesByPrivateOwner(int privateOwnerId);
        Task<Property> GetPropertyById(int propertyId);
        Task CreateProperty(Property property);
        Task UpdateProperty(Property property);
        Task DeleteProperty(int propertyId);
    }
}