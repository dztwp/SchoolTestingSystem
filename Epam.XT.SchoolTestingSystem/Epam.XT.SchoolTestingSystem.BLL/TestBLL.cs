using Epam.XT.SchoolTestingSystem.Common.Entities;
using Epam.XT.SchoolTestingSystem.DAL.Interfaces;
using Epam.XT.SchoolTestingSystem.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.BLL
{
    public class TestBLL : ITestBLL
    {
        ITestDAL _testDAL;
        public TestBLL(ITestDAL testDAL)
        {
            _testDAL = testDAL;
        }
        public bool CreateTest(Test test)
        {
            return _testDAL.CreateTest(test);
        }

        public Test GetTestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsTestDone(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
