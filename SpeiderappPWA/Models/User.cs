using System.Collections.Generic;

namespace SpeiderappPWA.Models
{
    public class User
    {
        public User(long userID, string email, string firstName, string lastName)
        {
            UserID = userID;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public long UserID { get; init; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
