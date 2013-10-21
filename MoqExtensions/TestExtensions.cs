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


        public class SetupWrapper<TRepo, TEntity>
            where TRepo : class
            where TEntity : class
        {
            public Mock<TRepo> repo;
            public ISetup<TRepo, IQueryable<TEntity>> setup;
        }



        public static SetupWrapper<TRepo, TEntity> WhereEntity<TRepo, TEntity>(this Mock<TRepo> source,
            Expression<Func<TRepo, IQueryable<TEntity>>> expr)
            where TRepo : class
            where TEntity : class
        {
            var wrapper = new SetupWrapper<TRepo, TEntity>();
            wrapper.repo = source;
            wrapper.setup = wrapper.repo.Setup(expr);
            return wrapper;
        }


        #region ReturnsMockWith

        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue>(this SetupWrapper<TRepo, TEntity> where,
            Expression<Func<TEntity, TValue>> expr, TValue value)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(expr).Returns(value);

            where.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return where.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2>(this SetupWrapper<TRepo, TEntity> where,
            Expression<Func<TEntity, TValue>> expr1, TValue value1,
            Expression<Func<TEntity, TValue2>> expr2, TValue2 value2)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(expr1).Returns(value1);
            mockEntity.Setup(expr2).Returns(value2);

            where.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return where.repo;
        }

        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3>(this SetupWrapper<TRepo, TEntity> where,
            Expression<Func<TEntity, TValue>> expr1, TValue value1,
            Expression<Func<TEntity, TValue2>> expr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> expr3, TValue3 value3)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(expr1).Returns(value1);
            mockEntity.Setup(expr2).Returns(value2);
            mockEntity.Setup(expr3).Returns(value3);

            where.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return where.repo;
        }


        public static Mock<TRepo> ReturnsMockWith<TRepo, TEntity, TValue, TValue2, TValue3, TValue4>(this SetupWrapper<TRepo, TEntity> where,
            Expression<Func<TEntity, TValue>> expr1, TValue value1,
            Expression<Func<TEntity, TValue2>> expr2, TValue2 value2,
            Expression<Func<TEntity, TValue3>> expr3, TValue3 value3,
            Expression<Func<TEntity, TValue4>> expr4, TValue4 value4)
            where TRepo : class
            where TEntity : class
        {
            var mockEntity = GetMock<TEntity>();
            mockEntity.Setup(expr1).Returns(value1);
            mockEntity.Setup(expr2).Returns(value2);
            mockEntity.Setup(expr3).Returns(value3);
            mockEntity.Setup(expr4).Returns(value4);

            where.setup.Returns(mockEntity.AsEnumerable().AsQueryable());

            return where.repo;
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


}
