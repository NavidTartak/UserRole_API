using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserRole.Domain.Models;
using UserRole.Framework.Models;

namespace UserRole.Domain.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<OperationResult<User>> GetUsers(CancellationToken cancellationToken = default);
    }
}
