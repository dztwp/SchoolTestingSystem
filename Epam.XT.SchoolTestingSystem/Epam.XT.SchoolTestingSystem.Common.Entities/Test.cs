using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.XT.SchoolTestingSystem.Common.Entities
{
    public class Test
    {
        public Test(Guid id, string description)
        {
            Id = id;
            Description = description;
        }
        public Test(string description, int timeToPass,Question[] questionArray)
        {
            Id = Guid.NewGuid();
            Description = description;
            TimeToPass = timeToPass;
            IsDone = false;
            QuestionArray = questionArray;
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public int TimeToPass { get; set; }
        public Question[] QuestionArray { get; set; }

        public bool IsDone { get; set; }


    }
}
