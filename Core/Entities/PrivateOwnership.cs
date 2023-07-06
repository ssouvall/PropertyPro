namespace Core.Entities
{
    public class PrivateOwnership : BaseOwnership
    {
        public int PrivateOwnerId { get; set; }
        public virtual PrivateOwner PrivateOwner { get; set; }
    }
}