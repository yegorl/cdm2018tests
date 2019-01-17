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

namespace BD_test.Implementation
{
    class LaptopDapper : ILaptopProvider
    {
        public List<LaptopModel> GetLaptops()
        {
            List<LaptopModel> Laptop_ = new List<LaptopModel>();
            using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["BD_test"].ConnectionString))
            {
                return db.Query<LaptopModel>("SELECT maker as ProductMaker, Laptop.model as Model, speed as CpuSpeed, ram as RamSize, hd as DiscSize, price as Price, screen as ScreenSize " +
                            "FROM Laptop " +
                            "INNER JOIN Product " +
                            "ON Laptop.model=Product.model").ToList();             
            }
        }
    }
}
