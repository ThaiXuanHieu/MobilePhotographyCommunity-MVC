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
    public interface ILikeService
    {
        Like GetById(int id);
        IEnumerable<Like> GetByPostId(int id);
        void Update(Like like);
        void Add(Like like);
        void Delete(Like like);
    }

    public class LikeService : ILikeService
    {
        private readonly ILikeRepository likeRepository;
        private readonly IUnitOfWork unitOfWork;

        public LikeService(ILikeRepository likeRepository, IUnitOfWork unitOfWork)
        {
            this.likeRepository = likeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Like like)
        {
            likeRepository.Add(like);
        }

        public void Delete(Like like)
        {
            likeRepository.Delete(like);
        }

        public Like GetById(int id)
        {
            return likeRepository.GetById(id);
        }

        public IEnumerable<Like> GetByPostId(int id)
        {
            return likeRepository.GetByPostId(id);
        }

        public void Update(Like like)
        {
            likeRepository.Update(like);
        }
    }
}
