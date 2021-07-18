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

        public bool BindingTestToUser(Guid userId, Guid testId, int quontityOfRightAnswers, int quontityOfQuestions)
        {
            return _testDAL.BindingTestToUser(userId, testId, quontityOfRightAnswers,quontityOfQuestions);
        }

        public bool CreateTest(Test test)
        {
            return _testDAL.CreateTest(test);
        }

        public bool DeleteTest(Guid testId)
        {
            return _testDAL.DeleteTest(testId);
        }

        public IEnumerable<string> GetAllTestsDescriptions()
        {
            return _testDAL.GetAllTestsDescriptions();
        }

        public Test GetTestByDescription(string description)
        {
            return _testDAL.GetTestByDescription(description);
        }

        public Test GetTestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Test GetTestParamsByDescription(string descriptions)
        {
            return _testDAL.GetTestParamsByDescription(descriptions);
        }

        public int[] GetTestResultByUserId(Guid userId, Guid testId)
        {
            return _testDAL.GetTestResultByUserId(userId, testId);
        }

        public IEnumerable<Result> GetUsersResults(Guid userId)
        {
            return _testDAL.GetUsersResults(userId);
        }

        public bool IsTestAlreadyDone(Guid userId, Guid testId)
        {
            return _testDAL.IsTestAlreadyDone(userId,testId);
        }

        public bool isTestAlreadyExist(string name)
        {
            return _testDAL.isTestAlreadyExist(name);
        }

        public bool UpdateTest(Test test)
        {
            return _testDAL.UpdateTest(test);
        }
    }
}
