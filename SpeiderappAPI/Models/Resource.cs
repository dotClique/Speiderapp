using System;
using SpeiderappAPI.Models.Interfaces;

namespace SpeiderappAPI.Models
{
    public class Resource : IUpdatable, ISoftDeletable
    {
        public Resource(long requirementID, string name, string description, string location)
        {
            RequirementID = requirementID;
            Name = name;
            Description = description;
            Location = location;
        }

        public long ResourceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public long RequirementID { get; set; }
        public virtual Requirement Requirement { get; set; } = null!;
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
