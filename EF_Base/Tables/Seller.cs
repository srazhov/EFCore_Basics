namespace EF_Base.Tables
{
    using System.Collections.Generic;

    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
