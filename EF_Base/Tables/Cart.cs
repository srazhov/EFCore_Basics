namespace EF_Base.Tables
{
    using EF_Base.Tables.Many_to_Many;
    using System.Collections.Generic;
    
    public class Cart
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
    }
}
