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
        public void Test_NestedMocks()
        {
            var repo = GetFakeRepository()
                .WhereEntity(r => r.Order)
                    .ReturnsMockWith(o => o.Office, MockObject.Of<OfficeEntity>()
                                                    .WithValue(o => o.OfficeId, 4444)
                                                    .WithValue(o => o.OfficeName, "My Office")
                                                    .Object);

            var order = repo.Object.Order.First();

            Assert.That(order.Office, Is.Not.Null);
            Assert.That(order.Office.OfficeId, Is.EqualTo(4444));
            Assert.That(order.Office.OfficeName, Is.EqualTo("My Office"));
        }

        [Test]
        public void Test_NestedQueryableMocks()
        {
            var repo = GetFakeRepository()
                .WhereEntity(r => r.Order)
                    .ReturnsMockWith(o => o.Offices, MockQueryable.Of<OfficeEntity>()
                                                        .WithRow(ofc => ofc.OfficeId, 4444, ofc => ofc.OfficeName, "My Office 1")
                                                        .WithRow(ofc => ofc.OfficeId, 5555, ofc => ofc.OfficeName, "My Office 2")
                                                        .collection
                                                        );

            var order = repo.Object.Order.First();

            Assert.That(order.Offices.ToArray()[0], Is.Not.Null);
            Assert.That(order.Offices.ToArray()[1], Is.Not.Null);

            Assert.That(order.Offices.ToArray()[0].OfficeId, Is.EqualTo(4444));
            Assert.That(order.Offices.ToArray()[1].OfficeId, Is.EqualTo(5555));

            Assert.That(order.Offices.ToArray()[0].OfficeName, Is.EqualTo("My Office 1"));
            Assert.That(order.Offices.ToArray()[1].OfficeName, Is.EqualTo("My Office 2"));
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
        public void Test_Stubs()
        {
            var fakeRepo = GetFakeRepository()
                .WhereEntity(r => r.Order)
                    .ReturnsStubWith(o => o.OrderId, 1234, o => o.OfficeId, 1111);



            var order = fakeRepo.Object.Order.FirstOrDefault(o => o.OrderId == 1234);
            order.OfficeId = 2222;

            Assert.That(fakeRepo.Object.Order.FirstOrDefault(o => o.OrderId == 1234).OfficeId, Is.EqualTo(2222));
        }


        [Test]
        public void Test_QueryableStubs()
        {
            var fakeRepo = GetFakeRepository()
                .WhereEntity(r => r.Office)
                    .ReturnsQueryableMockWith(MockQueryable.Of<OfficeEntity>()
                        .WithRowStub(ofc => ofc.OfficeId, 1, ofc => ofc.OfficeName, "Office 1")
                        .WithRowStub(ofc => ofc.OfficeId, 2, ofc => ofc.OfficeName, "Office 2")
                        .WithRowStub(ofc => ofc.OfficeId, 3, ofc => ofc.OfficeName, "Office 3")
                        .WithRowStub(ofc => ofc.OfficeId, 4, ofc => ofc.OfficeName, "Office 4")
                        .WithRowStub(ofc => ofc.OfficeId, 5, ofc => ofc.OfficeName, "Office 5")
                    );

            fakeRepo.Object.Office.Where(ofc => ofc.OfficeId == 2).First().OfficeName = "Modified Office 2";
            fakeRepo.Object.Office.Where(ofc => ofc.OfficeId == 4).First().OfficeName = "Modified Office 4";

            var evens = fakeRepo.Object.Office.Where(ofc => ofc.OfficeId % 2 == 0).Select(ofc => ofc.OfficeName);
            Assert.That(evens.ToArray(), Is.EqualTo(new[] { "Modified Office 2", "Modified Office 4" }));
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
        public virtual OfficeEntity Office { get; set; }
        public virtual IEnumerable<OfficeEntity> Offices { get; set; }
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
