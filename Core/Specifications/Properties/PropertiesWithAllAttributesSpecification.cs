using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesWithAllAttributesSpecification()
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.CompanyOwnerships);
            AddInclude(x => x.PrivateOwnerships);
        }

        public PropertiesWithAllAttributesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.CompanyOwnerships);
            AddInclude(x => x.PrivateOwnerships);
        }
    }
}