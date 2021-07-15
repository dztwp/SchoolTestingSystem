using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT.SchoolTestingSystem.Common.Entities;

namespace Epam.XT.SchoolTestingSystem.DAL.Interfaces
{
    public interface ITestDAL
    {
        bool IsTestDone(Guid id);
        Test GetTestById(Guid id);
        bool CreateTest(Test test);
    }
}
