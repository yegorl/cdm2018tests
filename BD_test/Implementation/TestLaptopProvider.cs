﻿using BD_test.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD_test.Implementation
{
    public class TestLaptopProvider : ITestLaptopProvider
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        LaptopContext ctx;

        private TestLaptopProvider()
        {

        }

        public TestLaptopProvider(LaptopContext context)
        {
            ctx = context;
        }
        public void AddLaptop(Laptop laptop)
        {
            using (LaptopContext db = new LaptopContext())
            {
                try
                {
                    db.Laptops.Add(laptop);
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool DeleteLaptop(Laptop laptop)
        {
            try
            {
                ctx.Laptops.Remove(laptop);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Laptop GetLaptop(int code)
        {
            throw new NotImplementedException();
        }

        public List<LaptopModel> GetLaptops()
        {
            List<LaptopModel> Laptop_ = new List<LaptopModel>();
            try
            {
                    var Lap = ctx.Laptops;
                    var Prod = ctx.Products;
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
                
                    logger.Debug("debug message");
                
            }
            catch (Exception e)
            {
                logger.Debug(e);
            }
            return Laptop_;
        }
    }
}
