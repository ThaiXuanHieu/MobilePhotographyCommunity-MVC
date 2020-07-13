namespace MobilePhotographyCommunity.Data.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusFriend")]
    public partial class StatusFriend
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusFriend()
        {
            FriendRelationships = new HashSet<FriendRelationship>();
        }

        [Key]
        public int StatusId { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; }

        public int? GroupStatus { get; set; }

        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FriendRelationship> FriendRelationships { get; set; }
    }
}
