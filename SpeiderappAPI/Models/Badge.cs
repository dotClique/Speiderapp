using System;
using System.Collections.Generic;

namespace SpeiderappAPI.Models
{
    public class Badge : Requirement
    {
        public Badge(string title, string image, string description, DateTime publishTime) : base(description, publishTime)
        {
            Title = title;
            Image = image;
        }

        public string Title { get; set; }
        public string Image { get; set; }
        public virtual ICollection<TaggedWith>? TaggedWiths { get; set; }
    }
}
