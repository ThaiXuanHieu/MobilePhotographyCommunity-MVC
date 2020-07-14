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

        public Like GetById(int id)
        {
            return likeRepository.GetById(id);
        }

        public IEnumerable<Like> GetByPostId(int id)
        {
            return likeRepository.GetByPostId(id);
        }
    }
}
