using System;
using System.Collections.Generic;

namespace SpeiderappAPI.Models
{
    public class Requirement
    {
        public Requirement(string description, DateTime publishTime)
        {
            Description = description;
            PublishTime = publishTime;
        }

        public long RequirementID { get; set; }
        public string Description { get; set; }

        public long AuthorID { get; set; }
        public virtual User Author { get; set; } = null!;
        public DateTime PublishTime { get; init; }
        public string RequirementType { get; set; }
        public long Version { get; set; } // To be incremented with every edit
        public DateTime UpdatedAt { get; set; }
        public DateTime? ArchivedAt { get; set; } // If not null, the instance is considered Archived
        public DateTime? DeletedAt { get; set; } // If not null, the instance is considered Deleted
        public virtual ICollection<Resource> Resources { get; set; } = null!;
        public virtual ICollection<RequirementPrerequisite> RequiredBy { get; set; } = null!;
        public virtual ICollection<RequirementPrerequisite> Requiring { get; set; } = null!;

        public override string ToString()
        {
            return $"[Requirement#{this.RequirementID} by {this.Author.FirstName}]\"{this.Description}\"";
        }
    }
}
