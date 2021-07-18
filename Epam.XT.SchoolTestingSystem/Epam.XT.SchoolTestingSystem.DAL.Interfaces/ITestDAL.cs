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
        IEnumerable<string> GetAllTestsDescriptions();
        IEnumerable<Result> GetUsersResults(Guid userId);
        bool isTestAlreadyExist(string name);
        bool IsTestAlreadyDone(Guid userId, Guid testId);
        Test GetTestParamsByDescription(string descriptions);
        Test GetTestByDescription(string description);
        bool CreateTest(Test test);
        bool DeleteTest(Guid testId);
        bool UpdateTest(Test test);
        int[]GetTestResultByUserId(Guid userId,Guid testId);

        bool BindingTestToUser(Guid userId, Guid testId, int quontityOfRightAnswers, int quontityOfQuestions);
    }
}
