namespace Core.Entities
{
    public class CompanyOwner : Company
    {
        public virtual ICollection<CompanyOwnership> CompanyOwnerships { get; } = new List<CompanyOwnership>();
    }
}