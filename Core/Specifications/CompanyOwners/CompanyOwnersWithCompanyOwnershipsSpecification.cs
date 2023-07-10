using Core.Entities;

namespace Core.Specifications.CompanyOwners
{
    public class CompanyOwnersWithCompanyOwnershipsSpecification : BaseSpecification<CompanyOwner>
    {
        public CompanyOwnersWithCompanyOwnershipsSpecification()
        {
            AddInclude(x => x.CompanyOwnerships);
        }

        public CompanyOwnersWithCompanyOwnershipsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.CompanyOwnerships);
        }
    }
}