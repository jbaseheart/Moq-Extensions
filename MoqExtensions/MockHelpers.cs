using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace MoqExtensions
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


   public static class MockHelpers
    {


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


    public static class MockObject
    {
        public static Mock<TEntity> Of<TEntity>()
        where TEntity : class
        {
            return new Mock<TEntity>();
        }
    }


    public static class MockQueryable
    {

        public static MoqExtensions.QueryableContext<TEntity> Of<TEntity>()
        where TEntity : class
        {
            var context = new QueryableContext<TEntity>();
            context.collection = new List<TEntity>();
            context.queryable = () => context.collection.AsQueryable();
            return context;
        }
    }



}
