using BD_test.Interfaces;
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
                try
                {
                    ctx.Laptops.Add(laptop);
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    logger.Debug(e);
                    throw;
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
                logger.Debug(e);
                return false;
            }
        }

        public Laptop GetLaptop(int code)
        {
            Laptop laptop;
            try
            {
                laptop = ctx.Laptops.FirstOrDefault(x => x.code == code);
            }
            catch(Exception e)
            {
                logger.Debug(e);
                throw e;
            }
            return laptop;
        }

        public List<Laptop> GetLaptops()
        {
            List<Laptop> Laptop_ = new List<Laptop>();
            try
            {

                return ctx.Laptops.ToList();
            }
            catch (Exception e)
            {
                logger.Debug(e);
            }
            return Laptop_;
        }
    }
}
