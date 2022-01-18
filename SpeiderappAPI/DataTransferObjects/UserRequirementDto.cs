using System;

namespace SpeiderappAPI.DataTransferObjects
{
    public class UserRequirementDto
    {
        public long RequirementID { get; set; }
        public string Description { get; set; }
        public DateTime PublishTime { get; set; }
    }
}
