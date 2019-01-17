using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD_test.Implementation;

namespace BD_test.Interfaces
{

    public interface ITestLaptopProvider
    {
        List<LaptopModel> GetLaptops();
        void AddLaptop(Laptop laptop);
        bool DeleteLaptop(Laptop laptop);
        Laptop GetLaptop(int code);
    }
}
