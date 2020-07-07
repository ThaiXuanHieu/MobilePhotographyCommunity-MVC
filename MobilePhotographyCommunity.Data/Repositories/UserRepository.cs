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
        bool CheckAccountExists(string username);
    }

    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {

        }

        public bool CheckAccountExists(string username)
        {
            var user = Context.Users.Where(x => x.UserName.Equals(username)).FirstOrDefault();
            if (user == null)
                return true;
            return false;
        }

        public User GetUser(string username, string passwordHash)
        {
            return Context.Users.Where(u => u.UserName.Equals(username) && u.PasswordHash.Equals(passwordHash)).FirstOrDefault();
        }
    }
}
