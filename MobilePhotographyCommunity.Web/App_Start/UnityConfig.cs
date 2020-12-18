using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using MobilePhotographyCommunity.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MobilePhotographyCommunity.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IDatabaseFactory, DatabaseFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICategoryRepository, CategoryRepository>();
            container.RegisterType<IChallengeService, ChallengeService>();
            container.RegisterType<IChallengeRepository, ChallengeRepository>();
            container.RegisterType<IPostService, PostService>();
            container.RegisterType<IPostRepository, PostRepository>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ILikeService, LikeService>();
            container.RegisterType<ILikeRepository, LikeRepository>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}