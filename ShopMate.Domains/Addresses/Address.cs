using ShopMate.Domains.Users;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Addresses
{
    public class Address : IEntity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
