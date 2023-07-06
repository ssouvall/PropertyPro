namespace Core.Entities
{
    public class CompanyOwnership : BaseOwnership
    {
        public int CompanyOwnerId { get; set; }
        public virtual CompanyOwner CompanyOwner { get; set; }
    }
}