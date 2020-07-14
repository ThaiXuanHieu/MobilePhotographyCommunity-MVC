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
    public interface ICommentService
    {
        Comment GetById(int id);
        IEnumerable<Comment> GetByPostId(int id);
    }

    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;
        private readonly IUnitOfWork unitOfWork;

        public CommentService(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
        {
            this.commentRepository = commentRepository;
            this.unitOfWork = unitOfWork;
        }

        public Comment GetById(int id)
        {
            return commentRepository.GetById(id);
        }

        public IEnumerable<Comment> GetByPostId(int id)
        {
            return commentRepository.GetByPostId(id);
        }
    }
}
