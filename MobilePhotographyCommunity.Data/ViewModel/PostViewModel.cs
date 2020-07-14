using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class PostViewModel
    {
        public int PostId { get; set; }

        public int? CategoryId { get; set; }

        public string Caption { get; set; }

        public string Image { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public Category Category { get; set; }
        
        public IEnumerable<Comment> Comments { get; set; }
        
        public IEnumerable<Like> Likes { get; set; }
    }
}
