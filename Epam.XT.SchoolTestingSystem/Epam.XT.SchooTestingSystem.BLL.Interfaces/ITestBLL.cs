using Epam.XT.SchoolTestingSystem.Common.Entities;
using System;

namespace Epam.XT.SchoolTestingSystem.BLL.Interfaces
{
    public interface ITestBLL
    {
        bool IsTestDone(Guid id);
        Test GetTestById(Guid id);
        bool CreateTest(Test test);
    }
}
