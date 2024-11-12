using DataAccess.Repository.Interface;
using FU_Library_Web;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Implement
{
    public class UserRepository : GenericRepository<Users>, IUserRepository
    {
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<(bool IsValid, Users? Account)> ValidateUserAsync(string email, string password)
        {
            var identityUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Password == password && u.Email == email);
            if (identityUser != null) return (true, identityUser);
            return (false, null);
        }
    }
}
