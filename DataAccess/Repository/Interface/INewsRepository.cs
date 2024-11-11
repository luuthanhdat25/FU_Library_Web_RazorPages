using FU_Library_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface INewsRepository
    {
        public abstract Task AddNewsAsyns(News news);
        public abstract Task<IEnumerable<News>> GetAllNewsAsyns(); 
        public abstract Task<News> GetNewsAsyns(Guid id);
    }
}
