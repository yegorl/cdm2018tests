using System;
using NUnit.Framework;
using Moq;
using BD_test.Implementation;
using System.Collections.Generic;
using System.Data.Entity;
using BD_test;

namespace BD_UnitTest
{
    [TestFixture]
    public class LaptopUnitTest
    {
        private Mock<LaptopContext> mockLaptopContext;
        private Mock<DbSet<Laptop>> mockLaptopDbSet;
        private List<Laptop> laptops;

        [SetUp]
        public void Init()
        {
            laptops = new List<Laptop>();
            mockLaptopContext = new Mock<LaptopContext>();
            mockLaptopDbSet = MockContextHelper.CreateMock(laptops);
            mockLaptopDbSet.Setup(x => x.Remove(It.IsAny<Laptop>())).Throws(new Exception());
            mockLaptopContext.Setup(x => x.Laptops).Returns(mockLaptopDbSet.Object);
        }

        [Test]
        public void TestMethod1()
        {
            TestLaptopProvider sut = new TestLaptopProvider(mockLaptopContext.Object);
            var result = sut.GetLaptops();
            Assert.NotNull(result);
            Assert.AreEqual(0, result.Count);
        }
        [Test]
        public void ReturnFalse()
        {
            var result = false;

            Assert.IsFalse(result, "1 should not be prime");
        }
<<<<<<< .mine

        [Test]
        public void TestGetLaptops()
        {

            TestLaptopProvider sut = new TestLaptopProvider(mockLaptopContext.Object);
            var result = sut.GetLaptops();
            var laptop = new Laptop()
            {
                code = 1,
                model = "",
                speed = 1,
                ram = 1,
                DiscSize = 1,
                price = 100,
                screen = 1
            };
            laptops.Add(laptop);
            laptops.Add(laptop);
            laptops.Add(laptop);
            Assert.NotNull(result);
            Assert.Equals(3, result.Count);
        }

























=======

        [Test]
        public void AddItemToDatabase()
        {
            TestLaptopProvider laptopProvider = new TestLaptopProvider(mockLaptopContext.Object);
            Laptop laptop = new Laptop()
            {
                model = "12311",
                code = 1,
                DiscSize = 1,
                price = 100,
                ram = 1,
                screen = 1,
                speed = 1
            };
            laptopProvider.AddLaptop(laptop);

            mockLaptopContext.Verify( x => x.SaveChanges(), Times.Once);

        }

        [Test]
        public void DeleteItemFromDatabase()
        {
            
        }

        [Test]
        public void GetLaptopFromDatabase()
        {
            TestLaptopProvider laptopProvider = new TestLaptopProvider(mockLaptopContext.Object);
            Laptop laptop = new Laptop()
            {
                model = "12311",
                code = 1235,
                DiscSize = 1,
                price = 100,
                ram = 1,
                screen = 1,
                speed = 1
            };
            laptops.Add(laptop);

            var result = laptopProvider.GetLaptop(1235);

            Assert.NotNull(result);
            Assert.AreEqual(result, laptop);
        }
>>>>>>> .theirs
    }
}
