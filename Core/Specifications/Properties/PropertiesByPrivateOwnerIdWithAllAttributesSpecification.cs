using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesByPrivateOwnerIdWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesByPrivateOwnerIdWithAllAttributesSpecification(int privateOwnerId)
            : base(x => x.PrivateOwnerships
                .Any(po => po.PrivateOwnerId == privateOwnerId))
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.CompanyOwnerships);
            AddInclude(x => x.PrivateOwnerships);
        }
    }
}