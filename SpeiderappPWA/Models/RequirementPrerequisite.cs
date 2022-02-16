using SpeiderappPWA.Models;

namespace SpeiderappPWA.Models
{
    public class RequirementPrerequisite
    {
        public RequirementPrerequisite(bool isAdvisory)
        {
            IsAdvisory = isAdvisory;
        }

        public long RequirerID { get; set; }
        public long RequireeID { get; set; }
        public virtual Requirement Requirer { get; set; } = null!;
        public virtual Requirement Requiree { get; set; } = null!;
        public bool IsAdvisory { get; set; }
    }
}
