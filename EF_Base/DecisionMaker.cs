namespace EF_Base
{
    using EF_Base.Tables;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class DecisionMaker
    {
        public static Seller CreateSellers(string name)
        {
            using var db = new ShopContext();

            var seller = new Seller { Name = name};
            db.Add(seller);

            db.SaveChanges();
            Console.WriteLine("Объекты Seller добавлены");

            return db.Seller.First(s => s.Name == name);
        }

        public static Product CreateProducts(string name, decimal price, Seller seller)
        {
            using var db = new ShopContext();

            db.Attach(seller);
            var pro = new Product { Price = price, Name = name, Seller = seller };

            db.Add(pro);
            db.SaveChanges();

            Console.WriteLine("Объекты Product добавлены");
            return db.Product.First(p => p.Name == name && p.Seller == seller);
        }

        public static Cart CreateCart(Product[] products)
        {
            using var db = new ShopContext();

            db.Add(new Cart());
            db.SaveChanges();
            Console.WriteLine("Объект Cart добавлен");

            var cart = (from s in db.Cart
                    where s.Id == db.Cart.Max(c => c.Id)
                    select s).Single();

            db.AttachRange(products);
            for (int i = 0; i < products.Length; i++)
            {
                products[i].CartProducts.Add(new Tables.Many_to_Many.CartProduct { Cart = cart });
            }

            db.SaveChanges();
            return (from s in db.Cart where s.Id == db.Cart.Max(c => c.Id) select s).Single();
        }

        public static Order CreateOrder(Cart cart)
        {
            using var db = new ShopContext();

            var order = new Order { PurchaseDate = DateTime.Now };
            db.Add(order);
            db.SaveChanges();

            db.Attach(cart);
            order = (from o in db.Order
                    where o.Id == db.Order.Max(c => c.Id)
                    select o).Single();

            cart.Order = order;
            db.Update(cart);
            db.SaveChanges();

            return (from o in db.Order where o.Id == db.Order.Max(c => c.Id) select o).Single();
        }

        public static Customer CreateCustomer(string customerName, Order[] orders)
        {
            using var db = new ShopContext();

            db.AttachRange(orders);
            db.Add(new Customer { Name = customerName, Orders = orders }); ;
            db.SaveChanges();

            Console.WriteLine("Объект Customer добавлен");

            return (from c in db.Customer where c.Id == db.Customer.Max(cust => cust.Id) select c).Single();
        }

        public static Comment CreateComment(Comment comment, string ProductName)
        {
            using var db = new ShopContext();

            var product = db.Product.FirstOrDefault(p => p.Name == ProductName);
            
            if (product == null)
            {
                throw new NullReferenceException("Data not found");
            }

            db.Attach(comment);
            var date = DateTime.Now;
            comment.Date = date;
            var text = comment.CommentText;

            if (product.Comments == null)
            {
                product.Comments = new List<Comment>() { comment };
            }
            else
            {
                product.Comments.Add(comment);
            }

            db.SaveChanges();

            Console.WriteLine("Объект Comment добавлен");

            return db.Comment.First(c => c.Date == date && c.CommentText == text);
        }

        public static void TruncateData()
        {
            using var db = new ShopContext();

            var objs = new List<object>();

            objs.AddRange((from s in db.Seller select s).ToList());
            objs.AddRange((from s in db.Product select s).ToList());
            objs.AddRange((from s in db.Cart select s).ToList());
            objs.AddRange((from s in db.Order select s).ToList());
            objs.AddRange((from s in db.Customer select s).ToList());
            objs.AddRange((from s in db.Comment select s).ToList());

            db.RemoveRange(objs);
            db.SaveChanges();
        }

        /// <summary>
        /// Use this method in Debug mode to know if data has been added to the tables
        /// </summary>
        public static void ShowResultsInDebugg()
        {
            using var db = new ShopContext();

            var sellerTest = (from a in db.Seller select a).ToList();
            var CustomerTest = (from a in db.Customer select a).ToList();
            var ProductTest = (from a in db.Product select a).ToList();
            var cartTest = (from a in db.Cart select a).ToList();
            var orderTest = (from a in db.Order select a).ToList();
            var commentTest = (from a in db.Comment select a).ToList();
        }

        public static void PopulateDefault(bool TruncateOld)
        {
            if (TruncateOld)
            {
                TruncateData();
            }

            var sellers = new Seller[] { CreateSellers("Vasya"), CreateSellers("Peter") };
            var products = new Product[]
            {
                CreateProducts("Head and Shoulders", 1090M, sellers[0]),
                CreateProducts("Coca Cola", 490.90M, sellers[0]),
                CreateProducts("Gilette", 1990.90M, sellers[0]),
                CreateProducts("Milk To the bright Future", 380M, sellers[1]),
                CreateProducts("Doshirak", 90M, sellers[1]),
                CreateProducts("Kinder surprise BIG", 2100, sellers[1])
            };

            var cart1 = CreateCart(products.Where(p => p.Name != "Gilette" && p.Price < 2000).ToArray());
            var cart2 = CreateCart(products.Where(p => p.Price >= 990).ToArray());
            var Orders = new Order[] { CreateOrder(cart1), CreateOrder(cart2) };

            var customer = CreateCustomer("Rinat", Orders);

            var comments = new Comment[]
            {
                new Comment { CommentText = "Кола как всегда хороша", Customer = customer },
                new Comment { CommentText = "Пользуюсь только им и доволен", Customer = customer },
                new Comment { CommentText = "Купил еще раз, чтобы еще раз не приходить сюда", Customer = customer },
                new Comment { CommentText = "Доширак - вкусен очень дешёв. Но жаль что после него в туалете долго сидишь", Customer = customer }
            };

            var productNames = new string[]
            {
                "Coca Cola", "Head and Shoulders", "Head and Shoulders", "Doshirak"
            };

            for (int i = 0; i < comments.Length; i++)
            {
                CreateComment(comments[i], productNames[i]);
            }
        }
    }
}
