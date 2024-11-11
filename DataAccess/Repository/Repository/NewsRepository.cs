using DataAccess.Repository.Interface;
using FU_Library_Web;
using FU_Library_Web.Migrations;
using FU_Library_Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NewsRepository : INewsRepository
    {

        private readonly DatabaseContext _context;

        public NewsRepository()
        {
            /*_context = new DatabaseContext();*/
        }

        public NewsRepository(DatabaseContext context)
        {
            _context = context;
        }

         public async Task AddNewsAsyns(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<News>> GetAllNewsAsyns()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<News> GetNewsAsyns(Guid id)
        {
            return await _context.News.FindAsync(id);
        }
    }
}
