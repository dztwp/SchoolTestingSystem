using Epam.XT.SchoolTestingSystem.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.BLL.Interfaces
{
    public interface IUserBLL
    {
        bool AddUser(User user);
        User GetUserByLogin(string login);
        string[] GetUserRoles(string login);
        bool IsUserExist(string login, string pass);
        bool IsUserInRole(string login, string role);
    }
}
