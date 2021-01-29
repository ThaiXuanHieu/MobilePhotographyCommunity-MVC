using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using MobilePhotographyCommunity.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Service
{
    public interface IUserService
    {
        void Add(User model);
        void Update(User user);
        void Delete(int id);
        User GetUser(string username, string passwordHash);
        User GetById(int id);
        bool CheckAccountExists(string username);
        IEnumerable<User> GetAll();
        IEnumerable<UserVm> GetAllPaging(int? pageIndex, int pageSize = 5);
        IEnumerable<UserVm> Search(string str);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(User user)
        {
            userRepository.Add(user);
            unitOfWork.Commit();
        }

        public bool CheckAccountExists(string username)
        {
            return userRepository.CheckAccountExists(username);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public IEnumerable<UserVm> GetAllPaging(int? pageIndex, int pageSize = 5)
        {
            var users = userRepository.GetAllPaging(pageIndex, pageSize);
            return users.Select(x => new UserVm
            {
                UserId = x.UserId,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Avatar = x.Avatar,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender
            }
            );
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetUser(string username, string passwordHash)
        {
            return userRepository.GetUser(username, passwordHash);
        }

        public IEnumerable<UserVm> Search(string str)
        {
            var users = userRepository.Search(str);
            return users.Select(x => new UserVm
            {
                UserId = x.UserId,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Avatar = x.Avatar,
                DateOfBirth = x.DateOfBirth,
                Gender = x.Gender
            }
            );
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}
