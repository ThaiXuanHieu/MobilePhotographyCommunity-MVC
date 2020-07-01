using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MobilePhotographyCommunity.Data.Repositories;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Service;
using MobilePhotographyCommunity.Data.DomainModel;

namespace MobilePhotographyCommunity.Test.ServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserRepository> mockRepository;
        private Mock<IUnitOfWork> mockUnitOfWork;
        private UserService userService;
        private User user = new User();

        [TestInitialize]
        public void Initialize()
        {
            mockRepository = new Mock<IUserRepository>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            userService = new UserService(mockRepository.Object, mockUnitOfWork.Object);
        }

        [TestMethod]
        public void GetUserTest()
        {
            string username = "thaixuanhieu";
            string passwordHash = "e10adc3949ba59abbe56e057f20f883e";
            mockRepository.Setup(m => m.GetUser(username, passwordHash)).Returns(user);
            var result = userService.GetUser(username, passwordHash);
            Assert.IsNotNull(result);
            Assert.AreEqual(user.UserName, result.UserName);
        }
    }
}
