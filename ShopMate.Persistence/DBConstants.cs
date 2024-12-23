namespace ShopMate.Persistence
{
    public class DbConstants
    {
        public static string DateTimeType = "datetime";
        public static string DefaultDateTimeFunc = "GETUTCDATE()";

        public class Tables
        {
            public static string Users = nameof(Users);
            public static string Addresses = nameof(Addresses);

            public static string Categories = nameof(Categories);
            public static string Products = nameof(Products);

            public static string ShoppingCarts = nameof(ShoppingCarts);
            public static string CartItems = nameof(CartItems);

            public static string OrderItems = nameof(OrderItems);
            public static string Orders = nameof(Orders);
            public static string Payments = nameof(Payments);
        }
    }
}
