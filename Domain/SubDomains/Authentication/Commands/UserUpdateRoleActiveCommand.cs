using System;

namespace Domains.Authentication.Commands
{
    public class UserUpdateRoleActiveCommand
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }
    }
}