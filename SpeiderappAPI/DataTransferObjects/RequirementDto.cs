using System;
using System.Collections.Generic;

namespace SpeiderappAPI.DataTransferObjects
{
    public class RequirementDto
    {
        public long RequirementID { get; set; }
        public string Description { get; set; }
        public long AuthorID { get; set; }
        public DateTime PublishTime { get; set; }
        public string Discriminator { get; set; }
        public ICollection<RequirementResourceDto> Resources { get; set; }
        public ICollection<RequirementRequiredByDto> RequiredBy { get; set; }
        public ICollection<RequirementRequiringDto> Requiring { get; set; }
    }
}
