using DataAccess.Repository.Interface;
using FU_Library_Web;
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

    }
}
