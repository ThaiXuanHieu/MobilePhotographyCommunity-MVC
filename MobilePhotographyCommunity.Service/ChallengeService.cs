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
    public interface IChallengeService
    {
        IEnumerable<Challenge> GetAll();
    }

    public class ChallengeService : IChallengeService
    {
        private readonly IChallengeRepository challengeRepository;
        private readonly IUnitOfWork unitOfWork;

        public ChallengeService(IChallengeRepository challengeRepository, IUnitOfWork unitOfWork)
        {
            this.challengeRepository = challengeRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Challenge> GetAll()
        {
            return challengeRepository.GetAll();
        }
    }
}
