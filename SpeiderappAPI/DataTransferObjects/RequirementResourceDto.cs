namespace SpeiderappAPI.DataTransferObjects
{
    public class RequirementResourceDto
    {
        public long ResourceID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
    }
}
