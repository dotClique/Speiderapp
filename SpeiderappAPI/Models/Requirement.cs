using System;
using System.Collections.Generic;
using SpeiderappAPI.Models.Interfaces;

namespace SpeiderappAPI.Models
{
    public class Requirement : IUpdatable, IArchivable, ISoftDeletable
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
        public string RequirementType { get; set; } = null!;
        public virtual ICollection<Resource> Resources { get; set; } = null!;
        public virtual ICollection<RequirementPrerequisite> RequiredBy { get; set; } = null!;
        public virtual ICollection<RequirementPrerequisite> Requiring { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public override string ToString()
        {
            return $"[Requirement#{this.RequirementID} by {this.Author.FirstName}]\"{this.Description}\"";
        }
    }
}
