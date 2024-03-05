using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface IUserManager
    {
        User Register(RegisterDTO registerDTO);
        User Login(LoginDTO loginDTO);
        User GetUserByEmail(string email);

        List<User> GetAllUsers();
    }

}
