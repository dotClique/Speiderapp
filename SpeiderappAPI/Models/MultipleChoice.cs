using System;

namespace SpeiderappAPI.Models
{
    public class MultipleChoice : Requirement
    {
        public MultipleChoice(string description, DateTime publishTime, int count) : base(description, publishTime)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}
