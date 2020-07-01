using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        MPCDbContext Init();
    }
}
