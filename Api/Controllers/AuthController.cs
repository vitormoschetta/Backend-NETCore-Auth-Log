using Api.Services;
using Domain.SubDomains.Authentication.Commands;
using Domain.SubDomains.Authentication.Contracts.Handlers;
using Domain.SubDomains.Authentication.Entities;
using Domains.Authentication.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;        
        private readonly IUserAuthHandler _handler;        
        public AuthController(TokenService tokenService, IUserAuthHandler handler)
        {
            _tokenService = tokenService;            
            _handler = handler;            
        }

        [HttpPost]
        public CommandResultToken Login(UserLoginCommand command)
        {
            CommandResultToken result = _handler.Login(command);
            if (result.Success)            
                 result.Token = _tokenService.GenerateToken((UserAuth)result.Object);                          
               
            return result;
        }


    }
}