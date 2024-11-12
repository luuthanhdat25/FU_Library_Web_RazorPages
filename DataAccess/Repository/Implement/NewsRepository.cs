using DataAccess.Repository.Interface;
using FU_Library_Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Implement
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
