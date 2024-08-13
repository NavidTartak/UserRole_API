using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserRole.Domain.Models;
using UserRole.Domain.Services.Interfaces;
using UserRole.Framework.Models;

namespace UserRole.Domain.Services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            this._context = context;    
        }
        public async Task<OperationResult<User>> GetUsers(CancellationToken cancellationToken = default)
        {
            OperationResult<User> Op = new("GetUsers");
            try
            {
                var list = await _context.Users.Include(x => x.Role).ToListAsync(cancellationToken: cancellationToken);
                if(list == null || !list.Any())
                {
                    return Op.Succeed("دریافت اطلاعات با موفقیت انجام شد ، اطلاعاتی برای نمایش وجود ندارد",HttpStatusCode.NoContent);
                }
                return Op.Succeed("دریافت اطلاعات با موفقیت انجام شد", list);
            }
            catch (Exception ex)
            {
                return Op.Failed("دریافت اطلاعات با مشکل مواجه شده است",ex.Message,HttpStatusCode.InternalServerError);
            }
        }

    }
}
