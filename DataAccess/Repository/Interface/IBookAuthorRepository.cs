using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IBookAuthorRepository : IGenericRepository<BookAuthors>
    {
        //Task<BookAuthors> GetByName(string name);
    }
}
