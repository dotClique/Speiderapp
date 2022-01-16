using System.Collections.Generic;

namespace SpeiderappAPI.DataTransferObjects
{
    public class UserDto
    {
        public long UserID { get; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
