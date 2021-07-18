using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Common.Entities
{
    public class Test
    {
        public Test(Guid id, string description,int numberOfQuestions,int timeToPass)
        {
            Id = id;
            Description = description;
            NumberOfQuestions = numberOfQuestions;
            TimeToPass = timeToPass;
        }
        public Test(Guid id, string description, int numberOfQuestions, int timeToPass,Question[]questionArray)
        {
            Id = id;
            Description = description;
            NumberOfQuestions = numberOfQuestions;
            TimeToPass = timeToPass;
            QuestionArray = questionArray;
        }
        public Test(string description, int timeToPass,Question[] questionArray, int numberOfQuestions)
        {
            Id = Guid.NewGuid();
            Description = description;
            TimeToPass = timeToPass;
            IsDone = false;
            QuestionArray = questionArray;
            NumberOfQuestions = numberOfQuestions;
        }
        public Test(Guid id,string description, int timeToPass, Question[] questionArray, int numberOfQuestions)
        {
            Id = id;
            Description = description;
            TimeToPass = timeToPass;
            IsDone = false;
            QuestionArray = questionArray;
            NumberOfQuestions = numberOfQuestions;
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int TimeToPass { get; set; }
        public Question[] QuestionArray { get; set; }

        public int NumberOfQuestions { get; set; }
        public bool IsDone { get; set; }


    }
}
