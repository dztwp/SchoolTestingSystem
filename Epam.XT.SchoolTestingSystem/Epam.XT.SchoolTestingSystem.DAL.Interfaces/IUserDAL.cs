using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT.SchoolTestingSystem.Common.Entities;

namespace Epam.XT.SchoolTestingSystem.DAL.Interfaces
{
    public interface IUserDAL
    {
        bool AddUser(User user);
        User GetUserByLogin(string login);


        bool IsUserRegistered(string login, string pass);
        bool IsLoginExist(string login);

        bool IsUserInRole(string login, string role);

        string[] GetUserRoles(string login);

        IEnumerable<Test> GetUserTests(string login);
    }
}
