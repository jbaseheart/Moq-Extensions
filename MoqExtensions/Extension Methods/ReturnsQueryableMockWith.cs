using System;
using System.Linq;
using System.Linq.Expressions;
using Moq;

namespace MoqExtensions
{
    public static class ReturnsQueryableMockWith_Extension
    {


        // (EntityContext<TRepo, TEntity>, IQueryable<TEntity>) -> Mock<TRepo> 
        public static Mock<TRepo> ReturnsQueryableMockWith<TRepo, TEntity>(this EntityContext<TRepo, TEntity> entity, IQueryable<TEntity> queryableCollection)
            where TRepo : class
            where TEntity : class
        {
            entity.setup.Returns(queryableCollection);
            return entity.repo;
        }

        // (EntityContext<TRepo, TEntity>, Func<IQueryable<TEntity>>) -> Mock<TRepo>
        public static Mock<TRepo> ReturnsQueryableMockWith<TRepo, TEntity>(this EntityContext<TRepo, TEntity> entity, Func<IQueryable<TEntity>> queryableCollectionExpr)
            where TRepo : class
            where TEntity : class
        {
            entity.setup.Returns(queryableCollectionExpr);
            return entity.repo;
        }

        // (EntityContext<TRepo, TEntity>, QueryableContext<TEntity>) -> Mock<TRepo>
        public static Mock<TRepo> ReturnsQueryableMockWith<TRepo, TEntity>(this EntityContext<TRepo, TEntity> entity, QueryableContext<TEntity> queryableContext)
            where TRepo : class
            where TEntity : class
        {
            entity.setup.Returns(queryableContext.queryable);
            return entity.repo;
        }




        #region WithRow Extensions


        public static QueryableContext<TEntity> WithRow<TEntity, TValue>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3, TValue4>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3, TValue4, TValue5>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr5).Returns(value5);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr5).Returns(value5);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr5).Returns(value5);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);
            mockEntity.Setup(fieldSelectorExpr7).Returns(value7);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }



        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7,
            Expression<Func<TEntity, TValue8>> fieldSelectorExpr8, TValue8 value8)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr5).Returns(value5);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);
            mockEntity.Setup(fieldSelectorExpr7).Returns(value7);
            mockEntity.Setup(fieldSelectorExpr8).Returns(value8);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }

        #endregion




        #region WithRowStub Extensions


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3, TValue4>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3, TValue4, TValue5>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);;
            mockEntity.SetupProperty(fieldSelectorExpr5, value5);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);;
            mockEntity.SetupProperty(fieldSelectorExpr5, value5);;
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);;
            mockEntity.SetupProperty(fieldSelectorExpr5, value5);;
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);;
            mockEntity.SetupProperty(fieldSelectorExpr7, value7);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }



        public static QueryableContext<TEntity> WithRowStub<TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7,
            Expression<Func<TEntity, TValue8>> fieldSelectorExpr8, TValue8 value8)
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);;
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);;
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);;
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);;
            mockEntity.SetupProperty(fieldSelectorExpr5, value5);;
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);;
            mockEntity.SetupProperty(fieldSelectorExpr7, value7);;
            mockEntity.SetupProperty(fieldSelectorExpr8, value8);;

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }

        #endregion





    }
}
