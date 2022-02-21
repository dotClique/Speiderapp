using System;
using System.Collections.Generic;

namespace SpeiderappAPI.DataTransferObjects
{
    public class RequirementDto
    {
        public long RequirementID { get; set; }
        public string Description { get; set; } = null!;
        public long AuthorID { get; set; }
        public DateTime PublishTime { get; set; }
        public string RequirementType { get; set; } = null!;
        public ICollection<RequirementResourceDto> Resources { get; set; } = null!;
        public ICollection<RequirementRequiredByDto> RequiredBy { get; set; } = null!;
        public ICollection<RequirementRequiringDto> Requiring { get; set; } = null!;
    }
}
