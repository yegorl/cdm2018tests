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

namespace BD_test
{
    public class LaptopModel
    {
        public string ProductMaker { get; set; }
        public string Model { get; set; }
        public Int16 CpuSpeed { get; set; }
        public Int16 RamSize { get; set; }
        public Single DiscSize { get; set; }
        public decimal Price { get; set; }
        public byte ScreenSize { get; set; }
    }
}
