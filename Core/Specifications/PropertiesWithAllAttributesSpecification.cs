using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesWithAllAttributesSpecification : BaseSpecification<Property>
    {
        public PropertiesWithAllAttributesSpecification()
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.PropertyOwnershipStructure);
            AddInclude(x => x.PropertyType);
        }

        public PropertiesWithAllAttributesSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ManagementCompany);
            AddInclude(x => x.PropertyOwnershipStructure);
            AddInclude(x => x.PropertyType);
        }
    }
}