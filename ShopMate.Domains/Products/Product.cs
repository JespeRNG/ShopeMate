using ShopMate.Domains.Categories;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Products
{
    public class Product : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}