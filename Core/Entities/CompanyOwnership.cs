namespace Core.Entities
{
    public class CompanyOwnership : BaseOwnership
    {
        public int CompanyOwnerId { get; set; }
        public CompanyOwner CompanyOwner { get; set; }
    }
}