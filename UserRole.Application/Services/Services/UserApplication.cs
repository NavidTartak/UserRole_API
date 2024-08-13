using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRole.Application.Contracts.DTOs.User;
using UserRole.Application.Services.Interfaces;
using UserRole.Domain.Services.Interfaces;
using UserRole.Framework.Models;

namespace UserRole.Application.Services.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;
        public UserApplication(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<OperationResult<Response_UserListDTO>> GetUsers(CancellationToken cancellationToken = default)
        {
            var operation = await _userRepository.GetUsers(cancellationToken);
            var Op = new OperationResult<Response_UserListDTO>("GetUsers");
            if (!operation.Success)
            {
                return Op.Failed(operation.Message, operation.ExMessage, operation.Status);
            }
            if (operation.List == null || !operation.List.Any())
            {
                return Op.Succeed(operation.Message, operation.Status);
            }
            return Op.Succeed(operation.Message, operation.List.Select(x => new Response_UserListDTO
            {
                RoleId = x.RoleId,
                RoleName = x.Role.RoleName,
                UserId = x.UserId,
                Username = x.Username
            }).ToList());
        }
    }
}
