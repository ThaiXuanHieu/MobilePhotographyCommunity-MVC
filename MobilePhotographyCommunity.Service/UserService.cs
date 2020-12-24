﻿using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
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
        User GetUser(string username, string passwordHash);
        User GetById(int id);
        bool CheckAccountExists(string username);
        IEnumerable<User> GetAll();
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

        public IEnumerable<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return userRepository.GetById(id);
        }

        public User GetUser(string username, string passwordHash)
        {
            return userRepository.GetUser(username, passwordHash);
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }
    }
}
