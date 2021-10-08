using System.Collections.Generic;

namespace SpeiderappAPI.Models
{
    public class Tag
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
    }
}
