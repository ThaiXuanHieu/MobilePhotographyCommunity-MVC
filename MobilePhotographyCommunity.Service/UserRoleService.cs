using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using System.Collections.Generic;

namespace MobilePhotographyCommunity.Service
{
    public interface IUserRoleService
    {
        void Add(UserRole userRole);
        IEnumerable<UserRole> GetByUserId(int userId);
    }

    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserRoleService(IUserRoleRepository userRoleRepository, IUnitOfWork unitOfWork)
        {
            this.userRoleRepository = userRoleRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(UserRole userRole)
        {
            userRoleRepository.Add(userRole);
        }

        public IEnumerable<UserRole> GetByUserId(int userId)
        {
            return userRoleRepository.GetByUserId(userId);
        }
    }
}
