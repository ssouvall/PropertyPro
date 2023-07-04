namespace Core.Entities
{
    public class ManagementCompany : Company
    {
        public ICollection<Property> ManagedProperties { get; set; } = new List<Property>();
    }
}