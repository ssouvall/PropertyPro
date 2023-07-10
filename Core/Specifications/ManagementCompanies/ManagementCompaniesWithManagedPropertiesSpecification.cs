using Core.Entities;

namespace Core.Specifications.ManagementCompanies
{
    public class ManagementCompaniesWithManagedPropertiesSpecification : BaseSpecification<ManagementCompany>
    {
        public ManagementCompaniesWithManagedPropertiesSpecification()
        {
            AddInclude(x => x.ManagedProperties);
        }

        public ManagementCompaniesWithManagedPropertiesSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ManagedProperties);
        }
    }
}