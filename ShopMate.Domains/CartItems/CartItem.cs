using ShopMate.Domains.Products;
using ShopMate.Domains.Interfaces;
using ShopMate.Domains.ShoppingCarts;

namespace ShopMate.Domains.CartItems
{
    public class CartItem : IEntity
    {
        public Guid Id { get; set; }

        public string CartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public string ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
