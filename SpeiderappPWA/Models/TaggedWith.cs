namespace SpeiderappPWA.Models
{
    public class TaggedWith
    {
        public TaggedWith(long badgeID, long tagID)
        {
            BadgeID = badgeID;
            TagID = tagID;
        }

        public long BadgeID { get; set; }
        public virtual Badge Badge { get; set; } = null!;
        public long TagID { get; set; }
        public virtual Tag Tag { get; set; } = null!;
    }
}
