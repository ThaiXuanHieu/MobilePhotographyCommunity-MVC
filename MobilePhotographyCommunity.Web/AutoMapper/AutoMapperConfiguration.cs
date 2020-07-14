using AutoMapper;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhotographyCommunity.Web.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<UserSignupModel, User>();
            });
        }
    }
}