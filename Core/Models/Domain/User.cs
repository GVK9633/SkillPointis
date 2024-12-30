namespace Core.Models.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool ActiveUser { get; set; }
        public string ConfirmationToken  { get; set; }
    }
}
