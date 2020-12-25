using System;

namespace Domains.Authentication.Commands
{
    public class UserActivateCommand
    {
        public Guid Id { get; set; }               
        public string Role { get; set; }       
    }
}