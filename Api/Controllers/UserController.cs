using System;
using System.Collections.Generic;
using Domain;
using Domain.SubDomains.Authentication.Contracts.Handlers;
using Domain.SubDomains.Authentication.Contracts.Repositories;
using Domain.SubDomains.Authentication.Entities;
using Domains.Authentication.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class UserController : ControllerBase
    {        
        private readonly IUserAuthRepository _repository;
        private readonly IUserAuthHandler _handler;        
        public UserController(IUserAuthRepository repository, IUserAuthHandler handler)
        {            
            _repository = repository;
            _handler = handler;            
        }
       

        [HttpPost]
        [Authorize(Roles="Admin")]
        public CommandResult RegisterAdmin(UserRegisterAdminCommand command)
        {
            CommandResult result = _handler.RegisterAdmin(command, User.Identity.Name);
            return result;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<UserAuth> GetInactivesFirstAccess()
        {
            var users = _repository.GetInactivesFirstAccess();
            return users;
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public CommandResult ActivateFirstAccess(UserActivateCommand command)
        {            
            CommandResult result = _handler.ActivateFirstAccess(command, User.Identity.Name);
            return result;
        }
       
        [HttpPost]
        [Authorize(Roles="Admin")]
        public CommandResult UpdateRoleActive(UserUpdateRoleActiveCommand command)
        {
            CommandResult result = _handler.UpdateRoleActive(command, User.Identity.Name);            
            return result;
        }


        [HttpDelete("{id}")]
        [Authorize(Roles="Admin")]
        public CommandResult Delete(Guid id)
        {
            CommandResult result = _handler.Delete(id, User.Identity.Name);            
            return result;
        }


        [HttpGet]
        [Authorize(Roles="Admin")]
        public IEnumerable<UserAuth> GetAll()
        {
            var users = _repository.GetAll();
            return users;
        }

        [HttpGet("{id}")]       
        public UserAuth GetById(Guid id)
        {
            var user = _repository.GetById(id);
            return user;
        }

        [HttpGet("{name}")]       
        public UserAuth GetByName(string name)
        {
            var user = _repository.GetByName(name);
            return user;
        }



        [HttpPost]       
        public CommandResult UpdatePassword(UserUpdatePasswordCommand command)
        {
            CommandResult result = _handler.UpdatePassword(command, User.Identity.Name);           
            return result;
        }


        [HttpGet("{filter}")]
        [Authorize(Roles="Admin")]
        public IEnumerable<UserAuth> Search(string filter = "")
        {            
            if (filter == "empty") filter = "";
            var result = _repository.Search(filter);
            return result;
        }

        

    }
}