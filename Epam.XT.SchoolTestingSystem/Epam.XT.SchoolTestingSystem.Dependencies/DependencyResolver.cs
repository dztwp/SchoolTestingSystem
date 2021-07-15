using Epam.XT.SchoolTestingSystem.BLL;
using Epam.XT.SchoolTestingSystem.BLL.Interfaces;
using Epam.XT.SchoolTestingSystem.DAL;
using Epam.XT.SchoolTestingSystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DependencyResolver();
                }
                return _instance;
            }
        }
        public IUserDAL userDAL => new UserDAL();
        public IUserBLL userBLL => new UserBLL(userDAL);

        public ITestDAL testDAL => new TestDAL();

        public ITestBLL testBLL => new TestBLL(testDAL);

        //public IUserDAO userDAO => new UserJsonDAO();
        //public IAwardDAO awardDAO => new AwardJsonDAO();

        //public IUserBLL userBLL => new UserBLL(userDAO);
        //public IAwardBLL awardBLL => new AwardBLL(awardDAO);

    }
}
