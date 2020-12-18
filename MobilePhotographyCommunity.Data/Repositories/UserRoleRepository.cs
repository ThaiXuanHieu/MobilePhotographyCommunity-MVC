using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IUserRoleRepository : IRepository<UserRole>
    {
        IEnumerable<UserRole> GetByUserId(int userId);
    }

    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public IEnumerable<UserRole> GetByUserId(int userId)
        {
            return Context.UserRoles.Where(x => x.UserId == userId).ToList();
        }
    }
}
