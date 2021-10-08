using System.Collections.Generic;

namespace SpeiderappAPI.Models
{
    public class Category
    {
        public Category(long categoryID, string title)
        {
            CategoryID = categoryID;
            Title = title;

        }

        public long CategoryID { get; init; }
        public string Title { get; set; }
        public virtual ICollection<Tag> Tags { get; set; } = null!;
    }
}
