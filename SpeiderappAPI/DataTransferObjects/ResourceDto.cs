namespace SpeiderappAPI.DataTransferObjects
{
    public class ResourceDto
    {
        public long ResourceID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public long RequirementID { get; set; }
    }
}
