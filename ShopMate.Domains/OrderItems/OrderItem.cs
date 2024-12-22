using ShopMate.Domains.Orders;
using ShopMate.Domains.Products;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.OrderItems
{
    public class OrderItem : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; } //Price of the product at the time of order

        public decimal TotalPrice { get; set; } //Total price for the item (Price * Quantity)

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
