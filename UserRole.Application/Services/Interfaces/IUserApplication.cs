using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRole.Application.Contracts.DTOs.User;
using UserRole.Framework.Models;

namespace UserRole.Application.Services.Interfaces
{
    public interface IUserApplication
    {
        Task<OperationResult<Response_UserListDTO>> GetUsers(CancellationToken cancellationToken = default);
    }
}
