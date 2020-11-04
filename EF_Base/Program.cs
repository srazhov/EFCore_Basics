namespace EF_Base
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using static DecisionMaker;

    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Началось");

            PopulateDefault(true);

            ShowResultsInDebugg();
            DisplayOrders("Rinat");
            DisplayComments();
        }

        private static void DisplayOrders(string CustomerName)
        {
            using var db = new ShopContext();

            if(!db.Customer.Any(c => c.Name == CustomerName))
            {
                throw new ArgumentException($"Could not find customer '{CustomerName}'");
            }

            var customer = (from c in db.Customer
                            where c.Name == CustomerName
                            select c).First();

            var result = from o in db.Order
                         where o.Customer == customer
                         orderby o.PurchaseDate
                         select o;

            foreach (var res in result)
            {
                Console.WriteLine($"{res.Id}. Customer {res.Customer.Name} had bought a product in {res.PurchaseDate}");
            }
        }

        private static void DisplayComments()
        {
            using var db = new ShopContext();

            var pros = (from p in db.Product.Include(c => c.Seller).Include(c => c.Comments)
                        where p.Comments.Count != 0
                        select p).Distinct();

            foreach (var pro in pros)
            {
                Console.WriteLine($"{pro.Id}. {pro.Seller.Name} sells product named {pro.Name} by price {pro.Price} tenge. And it has {pro.Comments.Count} comments");
            }
        }
    }
}
