using System;
using NUnit.Framework;
using Moq;
using BD_test.Implementation;
using System.Collections.Generic;

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
    }
}
