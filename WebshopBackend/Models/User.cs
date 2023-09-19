namespace WebshopBackend.models
{
    public class User
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
