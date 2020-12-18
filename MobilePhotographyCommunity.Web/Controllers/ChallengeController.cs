using MobilePhotographyCommunity.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilePhotographyCommunity.Web.Controllers
{
    public class ChallengeController : BaseController
    {
        private readonly IChallengeService challengeService;
        public ChallengeController(IChallengeService challengeService)
        {
            this.challengeService = challengeService;
        }
        // GET: Challenge
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ChallengePartial()
        {
            var challenges = challengeService.GetAll();
            return PartialView("_ChallengePartial", challenges);
        }
    }
}