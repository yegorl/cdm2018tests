﻿using System;
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
            Assert.Equals(1, laptops.Count);

        }

        [Test]
        public void DeleteItemFromDatabase()
        {
            
        }
    }
}
