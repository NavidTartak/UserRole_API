using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRole.Application.Contracts.DTOs.User;
using UserRole.Application.Services.Interfaces;
using UserRole.Framework.Models;

namespace UserRole.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserApplication _userApplication;
        public UserController(IUserApplication userApplication)
        {
            this._userApplication = userApplication;
        }
        [Authorize]
        [HttpGet("GetUsers")]
        public async Task<ActionResult<OperationResult<Response_UserListDTO>>> GetUsers(CancellationToken cancellationToken = default)
        {
            var operation = await _userApplication.GetUsers(cancellationToken);
            return operation.Success ? Ok(operation) : StatusCode((int)operation.Status, operation);
        }
        
    }
}
