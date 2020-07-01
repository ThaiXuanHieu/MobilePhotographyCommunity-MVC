using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private MPCDbContext context;
        private readonly IDbSet<T> dbSet;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected MPCDbContext Context
        {
            get { return context ?? (context = DatabaseFactory.Init()); }
        }

        public RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbSet = Context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = dbSet.Where<T>(predicate).AsEnumerable();
            foreach(T entity in entities)
            {
                dbSet.Remove(entity);
            }
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).ToList();
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }
    }
}
