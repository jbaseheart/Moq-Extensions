using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using MoqExtensions;

namespace PipeFire2.Core.Tests
{
    [TestFixture]
    public class TestExtensionFixture
    {

        [Test]
        public void Test_FluentInterface()
        {

            var repo = GetFakeRepository()
                .WhereEntity(r => r.Office)
                    .ReturnsMockWith(ofc => ofc.OfficeId, 4444,
                                     ofc => ofc.OfficeName, "AdventureWorks")
                .WhereEntity(r => r.Order)
                    .ReturnsMockWith(o => o.OrderId, 1234, o => o.OfficeId, 4444);

            Assert.That(repo.Object.Order.First().OrderId, Is.EqualTo(1234));
            Assert.That(repo.Object.Order.First().OfficeId, Is.EqualTo(4444));
            Assert.That(repo.Object.Office.First().OfficeId, Is.EqualTo(4444));
            Assert.That(repo.Object.Office.First().OfficeName, Is.EqualTo("AdventureWorks"));
        }




        [Test]
        public void Test_GetEnumerableFake()
        {
            var oe = MockHelpers.GetEnumerableFake<OrderEntity, int>(o => o.OrderId, 1234);
            Assert.That(oe.First().OrderId, Is.EqualTo(1234));
        }


        private Mock<ITestRepository> GetFakeRepository()
        {
            return new Mock<ITestRepository>();
        }

    }


    #region Test Entities

    public interface ITestRepository
    {
        IQueryable<OrderEntity> Order { get; }
        IQueryable<OfficeEntity> Office { get; }
    }

    public class OrderEntity
    {
        public virtual int OrderId { get; set; }
        public virtual int OfficeId { get; set; }
    }

    public class OfficeEntity
    {
        public virtual int OfficeId { get; set; }
        public virtual string OfficeName { get; set; }
    }

    public class EmployeeEntity
    {
        public virtual int EmployeeId { get; set; }
        public virtual string EmployeeName { get; set; }
        public virtual int OfficeId { get; set; }
    }


    #endregion

}
