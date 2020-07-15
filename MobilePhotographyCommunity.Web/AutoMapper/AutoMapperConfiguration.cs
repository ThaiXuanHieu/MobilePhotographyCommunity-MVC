using AutoMapper;
using MobilePhotographyCommunity.Common;
using MobilePhotographyCommunity.Data.DomainModel;
using MobilePhotographyCommunity.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobilePhotographyCommunity.Web.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<Comment, CommentViewModel>();
            CreateMap<Like, LikeViewModel>();
        }
    }
}