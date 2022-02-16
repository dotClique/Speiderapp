using System;
using System.Collections.Generic;

namespace SpeiderappPWA.Models
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
        public virtual ICollection<TaggedWith> TaggedWiths { get; set; } = null!;
        public bool Completed { get; set; } // TODO: Remove when ready

        public override string ToString()
        {
            return
                $" RequirementID: {RequirementID} Title: {Title}, Image: {Image}, Description: {Description}, PublishTime: {PublishTime}, Completed: {Completed}, TaggedWiths: {TaggedWiths}";
        }
    }
}
