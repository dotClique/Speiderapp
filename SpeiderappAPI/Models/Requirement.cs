using System;
using System.Collections.Generic;

namespace SpeiderappAPI.Models
{
    public class Requirement
    {
        public Requirement(string description, DateTime publishTime) : this(description, null!, publishTime)
        {
        }

        public Requirement(string description, User author, DateTime publishTime)
        {
            Description = description;
            Author = author;
            PublishTime = publishTime;
        }

        public long RequirementID { get; set; }
        public string Description { get; set; }
        public long AuthorID { get; set; }
        public virtual User Author { get; set; }
        public DateTime PublishTime { get; init; }
        public string? Discriminator { get; set; }
        public virtual ICollection<Resource>? Resources { get; set; }

        public virtual ICollection<RequirementPrerequisite>? RequiredBy { get; set; }
        public virtual ICollection<RequirementPrerequisite>? Requiring { get; set; }
    }
}
