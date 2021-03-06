﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BD_test;
using BD_test.Implementation;


namespace WepApi_Test.Controllers
{
    public class LaptopController : ApiController
    {
        TestLaptopProvider laptopProvider;

        public LaptopController()
        {
            laptopProvider = new TestLaptopProvider(new LaptopContext());
        }

        [HttpGet]
        public IEnumerable<Laptop> Get()
        {
            return laptopProvider.GetLaptops();
        }

        [HttpGet]
        [Route()]
        public Laptop GetLaptop([FromUri]int code)
        {
            return laptopProvider.GetLaptop(code);
        }

        [HttpPost]
        public void Post(Laptop laptop)
        {
            laptopProvider.AddLaptop(laptop);
        }

         
        public void Delete(int id)
        {
            laptopProvider.DeleteLaptop(laptopProvider.GetLaptop(id));
        }

    }
}
