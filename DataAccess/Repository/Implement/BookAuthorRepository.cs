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
    public class BookAuthorRepository : GenericRepository<BookAuthors>, IBookAuthorRepository
    {
        
        public BookAuthorRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        /*public async Task<BookAuthors> GetByName(string name)
        {
            //return await _dbContext.Set<T>().FindAsync(id);
            //return await Set<BookAuthors>().FirstOrDefaultAsync(it => it.FullName.Equals(name));
        }*/
    }
}
