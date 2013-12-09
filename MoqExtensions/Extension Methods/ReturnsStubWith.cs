using System;
using System.Linq;
using System.Linq.Expressions;
using Moq;

namespace MoqExtensions
{
    public static class ReturnsStubWith_Extension
    {


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr, TValue value)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr, value);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);
            mockEntity.SetupProperty(fieldSelectorExpr5, value5);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6>(this EntityContext<TRepo, TEntity> entity,
            Expression<Func<TEntity, TValue>> fieldSelectorExpr1, TValue value1,
            Expression<Func<TEntity, TValue2>> fieldSelectorExpr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> fieldSelectorExpr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> fieldSelectorExpr4, TValue4 value4,
            Expression<Func<TEntity, TValue5>> fieldSelectorExpr5, TValue5 value5,
            Expression<Func<TEntity, TValue6>> fieldSelectorExpr6, TValue6 value6)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7>(this EntityContext<TRepo, TEntity> entity,
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
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);
            mockEntity.SetupProperty(fieldSelectorExpr7, value7);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }


        public static Mock<TRepo> ReturnsStubWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4, TValue5, TValue6, TValue7, TValue8>(this EntityContext<TRepo, TEntity> entity,
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
            var mockEntity = MockHelpers.GetMock<TEntity>();
            mockEntity.SetupProperty(fieldSelectorExpr1, value1);
            mockEntity.SetupProperty(fieldSelectorExpr2, value2);
            mockEntity.SetupProperty(fieldSelectorExpr3, value3);
            mockEntity.SetupProperty(fieldSelectorExpr4, value4);
            mockEntity.SetupProperty(fieldSelectorExpr6, value6);
            mockEntity.SetupProperty(fieldSelectorExpr7, value7);
            mockEntity.SetupProperty(fieldSelectorExpr8, value8);

            entity.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return entity.repo;
        }



    }
}
