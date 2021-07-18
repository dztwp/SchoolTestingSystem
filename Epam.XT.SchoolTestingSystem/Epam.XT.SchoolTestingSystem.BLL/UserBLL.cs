using Epam.XT.SchoolTestingSystem.BLL.Interfaces;
using Epam.XT.SchoolTestingSystem.Common.Entities;
using Epam.XT.SchoolTestingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.BLL
{
    public class UserBLL : IUserBLL
    {
        IUserDAL _userDAL;
        public UserBLL(IUserDAL userDal)
        {
            _userDAL = userDal;
        }
        public bool AddUser(User user)
        {
            return _userDAL.AddUser(user);
        }

        public User GetUserByLogin(string login)
        {
            return _userDAL.GetUserByLogin(login);
        }

        public string[] GetUserRoles(string login)
        {
            return _userDAL.GetUserRoles(login);
        }

        public bool IsUserRegistered(string login, string pass)
        {
            return _userDAL.IsUserRegistered(login, pass);
        }

        public bool IsUserInRole(string login, string role)
        {
            return _userDAL.IsUserInRole(login, role);
        }

        public bool IsLoginExist(string login)
        {
            return _userDAL.IsLoginExist(login);
        }
    }
}
