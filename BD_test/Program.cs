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
using BD_test.Implementation;
namespace BD_test
{
    class Program
    {
        static void Main(string[] args)
        {
            /*LaptopDataReader ILaptop = new LaptopDataReader();
            List<Laptop> Lap = new List<Laptop>();
            Lap = ILaptop.GetLaptops();

            foreach (Laptop i in Lap)
            {
                Console.WriteLine(i.Model);
            }

            LaptopDapper ILaptop_ = new LaptopDapper();
            List<Laptop> Lap_ = new List<Laptop>();
            Lap_ = ILaptop_.GetLaptops();

            foreach (Laptop i in Lap_)
            {
                Console.WriteLine(i.Model);
            }
            
            EFDBFirst ILaptop__ = new EFDBFirst();
            List<Laptop> Lap__ = new List<Laptop>();
            Lap__ = ILaptop__.GetLaptops();

            foreach (Laptop i in Lap__)
            {
                Console.WriteLine(i.Model);
            }
            */
            
            //TestProvider(new LaptopDataReader());
            //TestProvider(new LaptopDapper());
            //TestProvider(new EFDBFirst());
            TestProvider(new EFCodeFirst());
            var provider= new TestLaptopProvider();
            provider.AddLaptop(new Laptop()
            {
                code = 9,
                model = "1298",
                speed = 875,
                ram = 124,
                DiscSize = 10,
                price = 500,
                screen = 14,
            });


            Console.Read();
        }
        static void TestProvider(ILaptopProvider provider)
        {
            List<LaptopModel> laptops = provider.GetLaptops();
            foreach (var l in laptops)
            {
                Console.WriteLine($"{l.ProductMaker}\t{l.Model}\t{l.CpuSpeed}\t{l.RamSize}\t{l.DiscSize}\t{l.Price}\t{l.ScreenSize}");
            }
            Console.WriteLine();
        }
    }
}