using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IUserRepository : IGenericRepository<Users>
    {
        public Task<(bool IsValid, Users? Account)> ValidateUserAsync(string email, string password);
    }
}
