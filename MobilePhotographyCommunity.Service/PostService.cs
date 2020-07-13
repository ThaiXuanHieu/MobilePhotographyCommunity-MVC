using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Service
{
    public interface IPostService
    {
        int CountByCategoryId(int id);
        IEnumerable<Post> GetByCategoryId(int id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Post> GetByCategoryId(int id)
        {
            return postRepository.GetByCategoryId(id);
        }

        public int CountByCategoryId(int id)
        {
            return postRepository.CountByCategoryId(id);
        }
    }
}
