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

namespace BD_test.Implementation
{
    public class EFDBFirst : ILaptopProvider
    {
        public List<LaptopModel> GetLaptops()
        {
            List<LaptopModel> Laptop_ = new List<LaptopModel>();
            using (computers db = new computers())
            {
                var Laptops = db.Laptop;
                var Products = db.Product;
                /*var LP = from a in Laptops
                         join b in Products on a.model equals b.model
                         select new Laptop(){ ProductMaker = b.maker, Model = a.model, CpuSpeed = a.speed, RamSize = a.ram, DiscSize = a.hd, Price = a.price, ScreenSize = a.screen };
                         */
                //var count = Laptops.ToList().Count;
                var LP = Laptops.Join(Products,
             a => a.model, 
             b => b.model, 
             (a, b) => new LaptopModel(){
                 ProductMaker = b.maker,
                 Model = a.model,
                 CpuSpeed = a.speed,
                 RamSize = a.ram,
                 DiscSize = a.hd,
                 Price = a.price.Value,
                 ScreenSize = a.screen }); // результат
             
                Laptop_ = LP.ToList();
            }
            return Laptop_;
            
        }
    }
}
