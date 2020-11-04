namespace EF_Base.Tables
{
    using EF_Base.Tables.Many_to_Many;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        [Column("Money")]
        public decimal Price { get; set; }

        public Seller Seller { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<CartProduct> CartProducts { get; set; }

        public Product()
        {
            Comments = new List<Comment>();
            CartProducts = new List<CartProduct>();
        }
    }
}
