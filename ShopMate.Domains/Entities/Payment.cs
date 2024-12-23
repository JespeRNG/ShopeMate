using ShopMate.Contracts.Enums;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Entities
{
    public class Payment : IEntity
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } //Date and time when payment was made

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
