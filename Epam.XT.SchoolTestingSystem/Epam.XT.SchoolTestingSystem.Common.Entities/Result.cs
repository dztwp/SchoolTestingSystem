using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Common.Entities
{
    public class Result
    {
        public Result(Guid userId, Guid testId,string testName)
        {
            UserId = userId;
            TestId = testId;
            TestName = testName;
        }
        public Guid UserId { get; set; }
        public Guid TestId { get; set; }
        public int NumberOfRightAnswers { get; set; }
        public int QuantityOfQuestions { get; set; }
        public string TestName { get; set; }
    }
}
