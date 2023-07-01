namespace Core.Entities
{
    public class CompanyOwnership : BaseOwnership
    {
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}