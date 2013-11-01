using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace MoqExtensions
{

    public static class MockHelpers
    {


        #region Context Wrappers


        public class EntityContext<TRepo, TEntity>
            where TRepo : class
            where TEntity : class
        {
            public Mock<TRepo> repo;
            public ISetup<TRepo, IQueryable<TEntity>> setup;
        }


        public class QueryableContext<TEntity>
            where TEntity : class
        {
            public ICollection<TEntity> collection;
            public Func<IQueryable<TEntity>> queryable;
        }
        

        #endregion


        public static EntityContext<TRepo, TEntity> WhereEntity<TRepo, TEntity>(this Mock<TRepo> repo,
            Expression<Func<TRepo, IQueryable<TEntity>>> expr)
            where TRepo : class
            where TEntity : class
        {
            var context = new EntityContext<TRepo, TEntity>();
            context.repo = repo;
            context.setup = context.repo.Setup(expr);
            return context;
        }


        #region ReturnsMockWith

        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr, TValue value)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr).Returns(value);
            
            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }

        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr5).Returns(value5);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);
            mockEntity.Setup(fieldSelectorExpr7).Returns(value7);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6,
            Expression<Func<TEntity, TValue7>> fieldSelectorExpr7, TValue7 value7,
            Expression<Func<TEntity, TValue8>> fieldSelectorExpr8, TValue8 value8)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);
            mockEntity.Setup(fieldSelectorExpr2).Returns(value2);
            mockEntity.Setup(fieldSelectorExpr3).Returns(value3);
            mockEntity.Setup(fieldSelectorExpr4).Returns(value4);
            mockEntity.Setup(fieldSelectorExpr6).Returns(value6);
            mockEntity.Setup(fieldSelectorExpr7).Returns(value7);
            mockEntity.Setup(fieldSelectorExpr8).Returns(value8);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }

        #endregion


        #region ReturnsQueryableMockWith

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



        public static QueryableContext<TEntity> WithRow<TEntity, TValue>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1)
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(fieldSelectorExpr1).Returns(value1);

            queryableContext.collection.Add(mockEntity.Object);

            return queryableContext;
        }


        public static QueryableContext<TEntity> WithRow<TEntity, TValue, TValue2>(this QueryableContext<TEntity> queryableContext,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2)
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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
            var mockEntity = GetMock<TEntity>();
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



        /// <summary>Usage:
        /// var a = MockHelpers.GetMock&lt;TEntity&gt;().WithValue(t => t.idField, 1234).WithValue(t => t.stringField, "name")
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public static Mock<TEntity> GetMock<TEntity>() where TEntity : class
        {
            return new Mock<TEntity>();
        }

        public static Mock<TEntity> WithValue<TEntity, TValue>(this Mock<TEntity> source, System.Linq.Expressions.Expression<Func<TEntity, TValue>> expr, TValue value) where TEntity : class
        {
            source.Setup(expr).Returns(value);
            return source;
        }

        public static IEnumerable<TEntity> AsEnumerable<TEntity>(this Mock<TEntity> source) where TEntity : class
        {
            yield return source.Object;
        }


        public static IEnumerable<TEntity> GetEnumerableFake<TEntity, TValue>(Expression<Func<TEntity, TValue>> expr, TValue value)
            where TEntity : class
        {
            return GetMock<TEntity>().WithValue(expr, value).AsEnumerable();
        }

    }




    public static class MockQueryable
    {

        public static MoqExtensions.MockHelpers.QueryableContext<TEntity> Of<TEntity>()
        where TEntity : class
        {
            var context = new MockHelpers.QueryableContext<TEntity>();
            context.collection = new List<TEntity>();
            context.queryable = () => context.collection.AsQueryable();
            return context;
        }
    }



}
