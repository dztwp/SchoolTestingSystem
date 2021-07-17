﻿using Epam.XT.SchoolTestingSystem.Common.Entities;
using System;
using System.Collections.Generic;

namespace Epam.XT.SchoolTestingSystem.BLL.Interfaces
{
    public interface ITestBLL
    {
        IEnumerable<string> GetAllTestsDescriptions();
        bool IsTestDone(Guid id);
        Test GetTestById(Guid id);
        bool CreateTest(Test test);
        bool isTestAlreadyExist(string name);
        Test GetTestParamsByDescription(string descriptions);
        Test GetTestByDescription(string description);
        bool BindingTestToUser(Guid userId, Guid testId, int quontityOfRightAnswers, int quontityOfQuestions);
        int[] GetTestResultByUserId(Guid userId, Guid testId);
        IEnumerable<Result> GetUsersResults(Guid userId);
    }
}
