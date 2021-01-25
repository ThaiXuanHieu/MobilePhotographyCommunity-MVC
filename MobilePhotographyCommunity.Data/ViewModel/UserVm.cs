using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhotographyCommunity.Data.ViewModel
{
    public class UserVm
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Avatar { get; set; }
        
        public bool? IsLocked { get; set; }
    }
}
