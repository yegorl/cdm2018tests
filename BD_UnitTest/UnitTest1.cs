using System;
using NUnit.Framework;
using Moq;
using BD_test.Implementation;
using System.Collections.Generic;
using BD_test;

namespace BD_UnitTest
{
    [TestFixture]
    public class LaptopUnitTest
    {
        private Mock<LaptopContext> mockLaptopContext;
        private List<Laptop> laptops;

        [SetUp]
        public void Init()
        {
            laptops = new List<Laptop>();
            mockLaptopContext = new Mock<LaptopContext>();
            mockLaptopContext.Setup(x => x.Laptops).Returns(MockContextHelper.CreateMock(laptops).Object);
        }

        [Test]
        public void TestMethod1()
        {
            TestLaptopProvider sut = new TestLaptopProvider(mockLaptopContext.Object);
            var result = sut.GetLaptops();
            Assert.NotNull(result);
            Assert.Equals(0, result.Count);
        }
        [Test]
        public void ReturnFalse()
        {
            var result = false;

            Assert.IsFalse(result, "1 should not be prime");
        }

        [Test]
        public void AddItemToDatabase()
        {
            TestLaptopProvider laptopProvider = new TestLaptopProvider(mockLaptopContext.Object);
            LaptopModel laptop = new LaptopModel()
            {
                Model = "12345",
                CpuSpeed = 1,
                DiscSize = 1,
                Price = 100,
                ProductMaker = "A",
                RamSize = 2,
                ScreenSize = 2
            };
            var result = laptopProvider.AddLaptop(laptop);
        }
    }
}
