namespace Core.Entities
{
    public class PropertyOwnershipStructure : BaseEntity
    {
        public ICollection<CompanyOwnership> CompanyOwnerships { get; set; } = new List<CompanyOwnership>();
        public ICollection<PrivateOwnership> PrivateOwnerships { get; set; } = new List<PrivateOwnership>();
        public int PropertyId { get; set; }
        public Property Property { get; set; }
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