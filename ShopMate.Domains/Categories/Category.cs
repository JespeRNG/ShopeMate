using ShopMate.Domains.Products;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.Categories
{
    public class Category : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}