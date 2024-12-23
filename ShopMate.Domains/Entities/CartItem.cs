using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Entities
{
    public class CartItem : IEntity
    {
        public Guid Id { get; set; }

        public Guid CartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
