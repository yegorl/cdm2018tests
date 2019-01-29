using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data.Entity;

namespace BD_UnitTest
{
    public static class MockContextHelper
    {
        public static Mock<DbSet<T>> CreateMock<T>(List<T> data) where T : class
        {

            /*
                * membership = new List<aspnet_Member>
                {
                    new aspnet_Member { Email = "user@email.com", UserId = userGuid
                },
                new aspnet_Member { Email = "manager@email.com", UserId = managerGuid
                }
            };
                **/
            var mockData = new Mock<DbSet<T>>();
            var queryable = data.AsQueryable();

            mockData.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockData.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockData.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockData.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mockData;
        }
    }
        
}
