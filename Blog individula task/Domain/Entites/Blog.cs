using System;
using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entites;

public class Blog : BaseDomainEntity
    {
        public int UserID { get; set; }
        // public User User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int? TagId { get; set; } 
        // public Tag Tag { get; set; }
        // public ICollection<BlogRating> BlogRatings { get; set; }
        // public ICollection<Comment> Comments { get; set; }
        // public ICollection<Like> Likes { get; set; }
        // public ICollection<Share> Shares { get; set; }
    }

