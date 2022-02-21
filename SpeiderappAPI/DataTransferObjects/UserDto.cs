namespace SpeiderappAPI.DataTransferObjects
{
    public class UserDto
    {
        public long UserID { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
    }
}
