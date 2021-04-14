using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SpeiderappAPI.Models
{
    public class Badge
    {
        public Badge(long id, string name, string image, string type, string description, string author, int rootNode, string createdAt, bool isComplete, string secret)
        {
            Id = id;
            Name = name;
            Image = image;
            Type = type;
            Description = description;
            Author = author;
            RootNode = rootNode;
            CreatedAt = createdAt;
            IsComplete = isComplete;
            Secret = secret;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int RootNode { get; set; }
        public string CreatedAt { get; set; }
        public List<TaggedWith> TaggedWiths { get; set; }
        public bool IsComplete { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public string Secret { get; set; }

    }
}
