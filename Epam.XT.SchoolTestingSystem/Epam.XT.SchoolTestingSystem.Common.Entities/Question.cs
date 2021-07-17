using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Common.Entities
{
    public class Question
    {
        public Question(string description,int numberOfQuestion, int numberOfRightAnswer, string[] answers)
        {
            Id = Guid.NewGuid();
            Description = description;
            NumberOfQuestion = numberOfQuestion;
            NumberOfRightAnswer = numberOfRightAnswer;
            Answers = answers;
            IsRight = false;
        }
        public Question(Guid id,string description, int numberOfQuestion, int numberOfRightAnswer)
        {
            Id = id;
            Description = description;
            NumberOfQuestion = numberOfQuestion;
            NumberOfRightAnswer = numberOfRightAnswer;
            IsRight = false;
        }


        public Guid Id { get; set; }
        public string Description { get; set; }
        public bool IsRight { get; set; }
        public int NumberOfRightAnswer { get; set; }
        public int NumberOfQuestion { get; set; }
        public string[] Answers { get; set; }



    }
}
