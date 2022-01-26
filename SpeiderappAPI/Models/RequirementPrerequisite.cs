namespace SpeiderappAPI.Models
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
        
        // This field represents that the Requiree "contributes to",
        // which means that it's not required, but it is part of the Requirer.
        public bool IsAdvisory { get; set; }
    }
}
