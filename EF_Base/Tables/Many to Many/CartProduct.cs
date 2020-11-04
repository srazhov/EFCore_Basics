namespace EF_Base.Tables.Many_to_Many
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
