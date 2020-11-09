using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class UserProfileVm
    {
        public User Users { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}
