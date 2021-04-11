using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace SpeiderappAPI.Models
{
    public class Tag
    {
        public Tag(long id, string value, long categoryId)
        {
            Id = id;
            CategoryId = categoryId;
            Value = value;
        }

        public long Id { get; init; }
        public string Value { get; set; }
        public long CategoryId { get; set; }
        public Category Category { get; set; }
        public  List<TaggedWith> TaggedWiths { get; set; }
    }
}
