namespace Core.Entities
{
    public class ManagementCompany : Company
    {
        public virtual ICollection<Property> ManagedProperties { get; set; } = new List<Property>();
    }
}