namespace Core.Entities
{
    public class CompanyOwner : Company
    {
        public ICollection<CompanyOwnership> CompanyOwnerships { get; } = new List<CompanyOwnership>();
    }
}