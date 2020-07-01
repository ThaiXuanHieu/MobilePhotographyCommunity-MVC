using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(string username, string passwordHash);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public User GetUser(string username, string passwordHash)
        {
            return Context.Users.Where(u => u.UserName.Equals(username) && u.PasswordHash.Equals(passwordHash)).FirstOrDefault();
        }
    }
}
