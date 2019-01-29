using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlTypes;
using Dapper;
using System.Data.Entity;
using BD_test.EFProvider;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace BD_test.Implementation
{
    //[Table("Laptop")]
    public class Laptop
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int code { get; set; }
        public string model { get; set; }
        public Int16 speed { get; set; }
        public Int16 ram { get; set; }
        public Single DiscSize { get; set; }
        public decimal price { get; set; }
        public byte screen { get; set; }
    }
    //[Table("Product")]
    public class Product
    {
        public string maker { get; set; }
        [Key]
        public string model { get; set; }
        public string type { get; set; }
    }
    public class LaptopContext : DbContext
    {
        public LaptopContext()
            : base("BD_test")
        {
            Database.SetInitializer<LaptopContext>(null);
        }
        
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>().ToTable("Laptop");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Laptop>().Property(p => p.DiscSize).HasColumnName("hd");
            modelBuilder.Entity<Laptop>().HasKey(p => p.code);
        }

    }
    public class EFCodeFirst : ILaptopProvider
    {
        public List<LaptopModel> GetLaptops()
        {
            List<LaptopModel> Laptop_ = new List<LaptopModel>();
            try
            {
                using (LaptopContext db = new LaptopContext())
                {
                    var Lap = db.Laptops;
                    var Prod = db.Products;
                    var LP = Lap.Join(Prod,
                         a => a.model,
                         b => b.model,
                         (a, b) => new LaptopModel()
                            {
                             ProductMaker = b.maker,
                             Model = a.model,
                             CpuSpeed = a.speed,
                             RamSize = a.ram,
                             DiscSize = a.DiscSize,
                             Price = a.price,
                             ScreenSize = a.screen
                            }
                    );
                   

                             Laptop_ = LP.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            return Laptop_;
        }

        public static void RemoveLaptop(string model)
        {
            try
            {
                using (LaptopContext db = new LaptopContext())
                {
                    var Laptop = db.Laptops.FirstOrDefault(m => m.model.Equals(model));
                    db.Laptops.Remove(Laptop);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}
