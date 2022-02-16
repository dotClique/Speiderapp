using SpeiderappPWA.Models;

namespace SpeiderappPWA.Models
{
    public class Resource
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
    }
}
