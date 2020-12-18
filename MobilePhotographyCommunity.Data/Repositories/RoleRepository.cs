using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        IEnumerable<Role> GetByName(string roleName);
    }

    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(IDatabaseFactory databaseFactory): base(databaseFactory)
        {

        }

        public IEnumerable<Role> GetByName(string roleName)
        {
            return Context.Roles.Where(x => x.RoleName.Equals(roleName)).ToList();
        }
    }
}
