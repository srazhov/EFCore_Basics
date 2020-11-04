namespace EF_Base.Tables
{
    using System;
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        
        public Customer Customer { get; set; }
    }
}
