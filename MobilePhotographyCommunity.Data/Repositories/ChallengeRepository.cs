using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IChallengeRepository : IRepository<Challenge>
    {

    }

    public class ChallengeRepository : RepositoryBase<Challenge>, IChallengeRepository
    {
        public ChallengeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
