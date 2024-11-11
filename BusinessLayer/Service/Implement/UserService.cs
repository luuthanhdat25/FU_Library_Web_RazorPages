using BusinessLayer.Dtos;
using BusinessLayer.Service.Interface;
using DataAccess.Repository.Interface;
using FU_Library_Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DatabaseContext _context;
        public UserService(IUserRepository userRepository, DatabaseContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<bool> Login(LoginDto user)
        {

            var findUser = await _userRepository.FindAsync(it => it.Email == user.Email && it.Password == user.Password);
            if(findUser != null)
            {
                return true;            
            }
            return false;
        }
    }
}
