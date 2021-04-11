namespace SpeiderappAPI.Models
{
    public class TaggedWith
    {
        public TaggedWith(long badgeId, long tagId)
        {
            BadgeId = badgeId;
            TagId = tagId;
        }

        public long BadgeId { get; set; }
        public Badge Badge { get; set; }
        public long TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
