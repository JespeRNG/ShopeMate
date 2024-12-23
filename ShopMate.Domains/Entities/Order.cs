using ShopMate.Contracts.Enums;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Entities
{
    public class Order : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalPrice { get; set; }

        public string ShippingAddress { get; set; }

        public string BillingAddress { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
    }
}
