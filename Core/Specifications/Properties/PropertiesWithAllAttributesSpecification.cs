using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesWithAllAttributesSpecification()
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.PrivateOwnerships);
            AddInclude(x => x.CompanyOwnerships);
            AddInclude($"{nameof(Property.CompanyOwnerships)}.{nameof(CompanyOwnership.CompanyOwner)}");
        }

        public PropertiesWithAllAttributesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.CompanyOwnerships);
            AddInclude($"{nameof(Property.CompanyOwnerships)}.{nameof(CompanyOwnership.CompanyOwner)}");
            AddInclude(x => x.PrivateOwnerships);
        }
    }
}