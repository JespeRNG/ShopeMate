using ShopMate.Contracts.Enums;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Entities
{
    public class User : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Phone { get; set; }

        public UserRole Role { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
