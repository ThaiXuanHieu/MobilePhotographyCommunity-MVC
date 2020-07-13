namespace MobilePhotographyCommunity.Data.DomainModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FriendRelationship")]
    public partial class FriendRelationship
    {
        [Key]
        public int FRId { get; set; }

        public int? UserOne { get; set; }

        public int? UserTwo { get; set; }

        public int? StatusId { get; set; }

        public int? ActionUser { get; set; }

        public virtual StatusFriend StatusFriend { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
