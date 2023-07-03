using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesByCompanyOwnerIdWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesByCompanyOwnerIdWithAllAttributesSpecification(int companyOwnerId)
            : base(x => x.PropertyOwnershipStructure.CompanyOwnerships
                .Any(co => co.CompanyOwnerId == companyOwnerId))
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.PropertyOwnershipStructure);
            AddInclude(x => x.PropertyType);
        }
    }
}