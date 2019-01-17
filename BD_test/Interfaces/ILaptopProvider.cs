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
    public interface ILaptopProvider
    {
        List<LaptopModel> GetLaptops();
    }
}
