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
        void Add(Post post);
        void Update(Post post);
        void Delete(int postId);
        int CountByCategoryId(int id);
        IEnumerable<Post> GetByCategoryId(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPost();
        Post GetById(int postId);
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

        public IEnumerable<Post> GetAll()
        {
            return postRepository.GetAll();
        }

        public void Add(Post post)
        {
            postRepository.Add(post);
        }

        public IEnumerable<Post> GetAllPost()
        {
            return postRepository.GetAllPost();
        }

        public Post GetById(int postId)
        {
            return postRepository.GetById(postId);
        }

        public void Update(Post post)
        {
            postRepository.Update(post);
        }

        public void Delete(int postId)
        {
            postRepository.Delete(postId);
        }
    }
}
