using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace MoqExtensions.Tests
{
    [TestFixture]
    public class MockHelpersFixture
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
        public void Test_SetupCollections()
        {
            var fakeRepo = new Mock<ITestRepository>();
            fakeRepo.Setup(r => r.Office)
                .Returns(() => 
                    new List<OfficeEntity>(new[] { 
                        new OfficeEntity() { OfficeId = 1, OfficeName = "Office 1" } ,
                        new OfficeEntity() { OfficeId = 2, OfficeName = "Office 2" } ,
                        new OfficeEntity() { OfficeId = 3, OfficeName = "Office 3" } ,
                        new OfficeEntity() { OfficeId = 4, OfficeName = "Office 4" } ,
                        new OfficeEntity() { OfficeId = 5, OfficeName = "Office 5" } ,
                    }).AsQueryable()
                );

            var evens = fakeRepo.Object.Office.Where(ofc => ofc.OfficeId % 2 == 0).Select(ofc => ofc.OfficeName);
            Assert.That(evens.ToArray(), Is.EqualTo(new[] { "Office 2", "Office 4" }));

        }


        [Test]
        public void Test_QueryableMocks()
        {
            var fakeRepo = GetFakeRepository()
                .WhereEntity(r => r.Office)
                    .ReturnsQueryableMockWith(MockQueryable.Of<OfficeEntity>()
                        .WithRow(ofc => ofc.OfficeId, 1, ofc => ofc.OfficeName, "Office 1")
                        .WithRow(ofc => ofc.OfficeId, 2, ofc => ofc.OfficeName, "Office 2")
                        .WithRow(ofc => ofc.OfficeId, 3, ofc => ofc.OfficeName, "Office 3")
                        .WithRow(ofc => ofc.OfficeId, 4, ofc => ofc.OfficeName, "Office 4")
                        .WithRow(ofc => ofc.OfficeId, 5, ofc => ofc.OfficeName, "Office 5")
                    );

            var evens = fakeRepo.Object.Office.Where(ofc => ofc.OfficeId % 2 == 0).Select(ofc => ofc.OfficeName);
            Assert.That(evens.ToArray(), Is.EqualTo(new[] { "Office 2", "Office 4" }));
        }


        [Test]
        public void Test_QueryableMocksWithExternalList()
        {
            //create an external list
            var list = new List<OfficeEntity>(new[] { 
                        new OfficeEntity() { OfficeId = 1, OfficeName = "Office 1" } ,
                        new OfficeEntity() { OfficeId = 2, OfficeName = "Office 2" } ,
                        new OfficeEntity() { OfficeId = 3, OfficeName = "Office 3" } ,
                        new OfficeEntity() { OfficeId = 4, OfficeName = "Office 4" } ,
                        new OfficeEntity() { OfficeId = 5, OfficeName = "Office 5" } ,
                    }).AsQueryable();
            

            var fakeRepo = GetFakeRepository()
                .WhereEntity(r => r.Office)
                    .ReturnsQueryableMockWith(list);  //use the list as the queryable source

            var evens = fakeRepo.Object.Office.Where(ofc => ofc.OfficeId % 2 == 0).Select(ofc => ofc.OfficeName);
            Assert.That(evens.ToArray(), Is.EqualTo(new[] { "Office 2", "Office 4" }));
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
