using System;
using System.Linq;

namespace SpeiderappAPI.Models.Interfaces
{
    public interface IArchivable
    {
        public DateTime? ArchivedAt { get; set; }
    }
}
