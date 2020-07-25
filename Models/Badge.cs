using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SpeiderappAPI.Models
{
    public class Badge
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int RootNode { get; set; }
        public string Created_at { get; set; }
        public bool IsComplete { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public string Secret { get; set; }

        public BadgeDTO toDTO() => new BadgeDTO(this);
    }
}
