using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory databaseFactory;
        private MPCDbContext context;

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            this.databaseFactory = databaseFactory;
        }

        protected MPCDbContext Context
        {
            get { return context ?? (context = databaseFactory.Init()); }
        }

        public void Commit()
        {
            Context.SaveChanges();
        }
    }
}
