using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications.Ownerships
{
    public class CompanyOwnershipsWithCompanyOwnerSpecification : BaseSpecification<CompanyOwnership>
    {
        public CompanyOwnershipsWithCompanyOwnerSpecification()
        {
            AddInclude(x => x.CompanyOwner);
        }

        public CompanyOwnershipsWithCompanyOwnerSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.CompanyOwner);
        }
    }
}