using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhotographyCommunity.Data.DomainModel;

namespace MobilePhotographyCommunity.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        MPCDbContext context;

        public MPCDbContext Init()
        {
            return context ?? (context = new MPCDbContext());
        }

        protected override void DisposeCore()
        {
            if (context == null)
                context.Dispose();
        }
    }
}
