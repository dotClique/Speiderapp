using System;
using SpeiderappPWA.Models;

namespace SpeiderappPWA.Models
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
