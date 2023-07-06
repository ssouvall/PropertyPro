using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class BaseOwnership : BaseEntity
    {
        public int PropertyId { get; set; }   
        public virtual Property Property { get; set; }     
        private int percentOwnership;

        [Range(0, 100, ErrorMessage = "Percent ownership must be between 0 and 100.")]
        public int PercentOwnership
        {
            get { return percentOwnership; }
            set
            {
                percentOwnership = value;
                ValidatePercentOwnership();
            }
        }

        private void ValidatePercentOwnership()
        {
            if (percentOwnership < 0 || percentOwnership > 100)
            {
                throw new ArgumentException("Percent ownership must be between 0 and 100.");
            }
        }
    }
}