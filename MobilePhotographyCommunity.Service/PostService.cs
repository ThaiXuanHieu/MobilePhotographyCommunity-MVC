using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.Infrastructure;
using MobilePhotographyCommunity.Data.Repositories;
using MobilePhotographyCommunity.Data.ViewModel;
using System;
using System.Collections.Generic;

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
        IEnumerable<PostViewModel> GetAllPostPaging(int? pageIndex, int pageSize);
        Post GetById(int postId);
        IEnumerable<Post> GetByUserId(int id);
    }

    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly ICommentRepository commentRepository;
        private readonly ILikeRepository likeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork, ICommentRepository commentRepository, ILikeRepository likeRepository,
            IUserRepository userRepository)
        {
            this.postRepository = postRepository;
            this.unitOfWork = unitOfWork;
            this.commentRepository = commentRepository;
            this.likeRepository = likeRepository;
            this.userRepository = userRepository;
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

        public IEnumerable<Post> GetByUserId(int id)
        {
            return postRepository.GetByUserId(id);
        }

        public IEnumerable<PostViewModel> GetAllPostPaging(int? pageIndex, int pageSize)
        {
            var postVms = new List<PostViewModel>();
            var posts = postRepository.GetAllPostPaging(pageIndex, pageSize);
            foreach(var item in posts)
            {
                var postVm = new PostViewModel();
                postVm.PostId = item.PostId;
                postVm.Caption = item.Caption;
                postVm.CategoryId = item.CategoryId;
                postVm.CreatedBy = item.CreatedBy;
                postVm.CreatedTime = item.CreatedTime;
                postVm.Comments = commentRepository.GetByPostId(item.PostId);
                postVm.Likes = likeRepository.GetByPostId(item.PostId);
                postVm.User = userRepository.GetById(Convert.ToInt32(item.CreatedBy));

                postVms.Add(postVm);
            }

            return postVms;
        }
    }
}
