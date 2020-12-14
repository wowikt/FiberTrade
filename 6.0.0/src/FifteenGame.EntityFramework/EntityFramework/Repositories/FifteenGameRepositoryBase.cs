using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace FifteenGame.EntityFramework.Repositories
{
    public abstract class FifteenGameRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<FifteenGameDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected FifteenGameRepositoryBase(IDbContextProvider<FifteenGameDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class FifteenGameRepositoryBase<TEntity> : FifteenGameRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected FifteenGameRepositoryBase(IDbContextProvider<FifteenGameDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
