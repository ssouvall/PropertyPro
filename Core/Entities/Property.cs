using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.Enums;

namespace Core.Entities
{
    public class Property : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public States State { get; set; }
        public string Zip { get; set; }
        public PropertyTypes PropertyType { get; set; }   
        public int? ManagementCompanyId { get; set; }
        public virtual ManagementCompany? ManagementCompany { get; set; }
        public virtual ICollection<PropertyFile> PropertyImages { get; set; } = new List<PropertyFile>();
        public ICollection<CompanyOwnership> CompanyOwnerships { get; set; } = new List<CompanyOwnership>();
        public ICollection<PrivateOwnership> PrivateOwnerships { get; set; } = new List<PrivateOwnership>();
        [NotMapped]
        public int TotalPercentOwnership
        {
            get
            {
                int totalPercentOwnership = 0;

                foreach (var privateOwnership in PrivateOwnerships)
                {
                    totalPercentOwnership += privateOwnership.PercentOwnership;
                }

                foreach (var companyOwnership in CompanyOwnerships)
                {
                    totalPercentOwnership += companyOwnership.PercentOwnership;
                }

                ValidateTotalPercentOwnership(totalPercentOwnership);

                return totalPercentOwnership;
            }
        }

        private void ValidateTotalPercentOwnership(int totalPercentOwnership)
        {
            if (totalPercentOwnership < 0 || totalPercentOwnership > 100)
            {
                throw new InvalidOperationException("Total ownership percentage must be between 0 and 100.");
            }
        }
    }
}