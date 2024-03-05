using Business.Abstarct;
using DataAccess.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                Name = registerDTO.Name,
                Email = registerDTO.Email,
                Password = registerDTO.Password
            };

            _userDal.Add(user);
            return user;
        }

        public User Login(LoginDTO loginDTO)
        {
            return _userDal.Get(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
        }

        public User GetUserByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<User> GetAllUsers()
        {
            return _userDal.GetAll();
        }
    }

}
