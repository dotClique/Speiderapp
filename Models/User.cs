namespace SpeiderappAPI.Models
{
    public class User
    {

        public User(long id, string email, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public long Id { get; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
