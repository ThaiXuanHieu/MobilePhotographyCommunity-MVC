using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface ILikeRepository : IRepository<Like>
    {
        IEnumerable<Like> GetByPostId(int id);
    }

    public class LikeRepository : RepositoryBase<Like>, ILikeRepository
    {
        public LikeRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public IEnumerable<Like> GetByPostId(int id)
        {
            return Context.Likes.Where(x => x.PostId == id);
        }
    }
}
