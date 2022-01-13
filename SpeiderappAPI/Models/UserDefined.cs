using System;

namespace SpeiderappAPI.Models
{
    public class UserDefined : Requirement
    {
        public UserDefined(string description, DateTime publishTime) : base(description, publishTime)
        {
        }
    }
}
