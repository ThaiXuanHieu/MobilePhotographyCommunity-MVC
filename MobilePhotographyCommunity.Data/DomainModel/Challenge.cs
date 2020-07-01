namespace MobilePhotographyCommunity.Data.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Challenge")]
    public partial class Challenge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Challenge()
        {
            JoinChallenges = new HashSet<JoinChallenge>();
        }

        public int ChallengeId { get; set; }

        public string ChallengeName { get; set; }

        public string MetaTitle { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedTime { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JoinChallenge> JoinChallenges { get; set; }
    }
}
