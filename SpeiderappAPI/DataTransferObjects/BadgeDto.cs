using System.Collections.Generic;

namespace SpeiderappAPI.DataTransferObjects
{
    public class BadgeDto : RequirementDto
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<BadgeTagDto> TaggedWiths { get; set; }
    }
}
