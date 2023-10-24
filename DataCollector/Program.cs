using DataCollector.Collector;
using DataCollector.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataCollector
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Data collector =  new Data();
            using (var db = new CoinContext())
            {
                try
                {
                    collector.GetCoinsAsync().Wait();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("There was an exception, {0}", ex.ToString());
                    Console.Read();
                }
                //await foreach (var coin in items)
                //{
                //   Console.Write(coin.ToString());
                //}
                // Create and save a new Blog
                //Console.Write("Enter a name for a new Coin: ");
                //var id = Console.ReadLine();
                //Console.Write("Enter a price for a new Coin: ");
                //var price = Console.ReadLine();

                //var coin = new Coin { id = id, priceUsd = price };
                //db.Coins.Add(coin);
                //db.SaveChanges();

                //// Display all Blogs from the database
                //var query = from b in db.Coins
                //            orderby b.id
                //            select b;

                //Console.WriteLine("All COINS in the database:");
                //foreach (var item in query)
                //{
                //    Console.WriteLine(item.id,":", item.priceUsd);
                //}

               

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }
        public string DisplayName { get; set; }
    }

    public class CoinContext : DbContext
    {
        public DbSet<Coin> Coins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.DisplayName)
                .HasColumnName("display_name");
        }
    }
}