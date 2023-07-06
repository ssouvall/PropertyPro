using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesByManagementCompanyIdWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesByManagementCompanyIdWithAllAttributesSpecification(int managementCompanyId)
            : base(x => x.ManagementCompanyId == managementCompanyId)
        {
            AddInclude(x => x.CompanyOwnerships);
            AddInclude(x => x.PrivateOwnerships);
        }
    }
}