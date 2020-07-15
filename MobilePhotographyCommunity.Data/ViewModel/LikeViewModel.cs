using MobilePhotographyCommunity.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class LikeViewModel
    {
        public int LikeId { get; set; }

        public int? PostId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public Post Post { get; set; }

        public User User { get; set; }
    }
}
