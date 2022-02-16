using System;

namespace SpeiderappAPI.Models.Interfaces
{
    public interface ISoftDeletable
    {
        public DateTime? DeletedAt { get; set; }
    }
}
