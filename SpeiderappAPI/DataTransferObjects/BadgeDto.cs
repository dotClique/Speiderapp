using System.Collections.Generic;

namespace SpeiderappAPI.DataTransferObjects
{
    public class BadgeDto : RequirementDto
    {
        public string Title { get; set; } = null!;
        public string Image { get; set; } = null!;
        public ICollection<BadgeTagDto> TaggedWiths { get; set; } = null!;
    }
}
