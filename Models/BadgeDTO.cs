namespace SpeiderappAPI.Models
{
    public class BadgeDTO
    {

        public BadgeDTO() { }
        public BadgeDTO(Badge badge)
        {
            this.Id = badge.Id;
            this.Name = badge.Name;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
