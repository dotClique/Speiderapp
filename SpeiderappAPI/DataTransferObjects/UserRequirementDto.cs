using System;

namespace SpeiderappAPI.DataTransferObjects
{
    public class UserRequirementDto
    {
        public long RequirementID { get; set; }
        public string Description { get; set; } = null!;
        public DateTime PublishTime { get; set; }
    }
}
