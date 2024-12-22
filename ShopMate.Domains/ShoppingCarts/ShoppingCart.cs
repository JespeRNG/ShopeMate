﻿using ShopMate.Domains.Users;
using ShopMate.Domains.CartItems;
using ShopMate.Domains.Interfaces;

namespace ShopMate.Domains.ShoppingCarts
{
    public class ShoppingCart : IEntity, ISoftDeletable
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}