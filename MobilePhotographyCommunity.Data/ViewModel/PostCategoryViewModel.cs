using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class PostCategoryViewModel
    {
        public IEnumerable<Post> Posts { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
