namespace SpeiderappAPI.DataTransferObjects
{
    public class ResourceDto
    {
        public long ResourceID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public long RequirementID { get; set; }
    }
}
