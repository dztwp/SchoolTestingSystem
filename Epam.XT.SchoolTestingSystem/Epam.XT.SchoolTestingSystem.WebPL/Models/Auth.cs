using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Epam.XT.SchoolTestingSystem.BLL.Interfaces;
using Epam.XT.SchoolTestingSystem.Dependencies;


namespace Epam.XT.SchoolTestingSystem.WebPL.Models
{
    public class Auth
    {
        IUserBLL _userBLL = DependencyResolver.Instance.userBLL;
        
        public bool CanLogin(string login, string pass)
        {
            if (_userBLL.IsUserExist(login, HashCreator.GetHash(pass)))
                return true;
            else 
                return false;
        }
    }
}