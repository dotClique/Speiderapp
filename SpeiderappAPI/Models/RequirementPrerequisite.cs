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
        public virtual Requirement? Requirer { get; set; }
        public virtual Requirement? Requiree { get; set; }
        public bool IsAdvisory { get; set; }
    }
}
