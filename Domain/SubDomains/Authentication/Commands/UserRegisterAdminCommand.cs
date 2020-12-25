namespace Domains.Authentication.Commands
{
    public class UserRegisterAdminCommand
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
    }
}