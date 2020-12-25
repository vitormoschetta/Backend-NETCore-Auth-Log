using System;
using Domain.SubDomains.Authentication.Commands;
using Domains.Authentication.Commands;

namespace Domain.SubDomains.Authentication.Contracts.Handlers
{
    public interface IUserAuthHandler
    {
        CommandResult Register(UserRegisterCommand command);
        CommandResult RegisterAdmin(UserRegisterAdminCommand command, string userIdentity);
        CommandResult ActivateFirstAccess(UserActivateCommand command, string userIdentity);
        CommandResultToken Login(UserLoginCommand command);
        CommandResult UpdateRoleActive(UserUpdateRoleActiveCommand command, string userIdentity);
        CommandResult UpdatePassword(UserUpdatePasswordCommand command, string userIdentity);
        CommandResult Delete(Guid id, string userIdentity);
    }
}