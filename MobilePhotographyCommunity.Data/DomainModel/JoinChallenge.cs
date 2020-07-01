namespace MobilePhotographyCommunity.Data.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JoinChallenge")]
    public partial class JoinChallenge
    {
        public int JoinChallengeId { get; set; }

        public int? ChallengeId { get; set; }

        public int? UserId { get; set; }

        public int? PostId { get; set; }

        public int? DeviceId { get; set; }

        public virtual Challenge Challenge { get; set; }
    }
}
