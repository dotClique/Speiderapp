using System;
using System.Collections.Generic;
using SpeiderappAPI.Models.Interfaces;

namespace SpeiderappAPI.Models
{
    public class Tag : IUpdatable, ISoftDeletable
    {
        public Tag(long tagID, string value, long categoryID)
        {
            TagID = tagID;
            CategoryID = categoryID;
            Value = value;
        }

        public long TagID { get; init; }
        public string Value { get; set; }
        public long CategoryID { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<TaggedWith> TaggedWiths { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
