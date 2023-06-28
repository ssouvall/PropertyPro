using Core.Entities;

namespace Core.Specifications
{
    public class PropertiesWithTypesSpecification : BaseSpecification<Property>
    {
        public PropertiesWithTypesSpecification()
        {
        }

        public PropertiesWithTypesSpecification(int id)
            : base(x => x.Id == id)
        {
        }
    }
}