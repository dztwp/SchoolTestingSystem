using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.XT.SchoolTestingSystem.Common.Entities;
using Epam.XT.SchoolTestingSystem.DAL.Interfaces;

namespace Epam.XT.SchoolTestingSystem.DAL
{
    public class TestDAL : ITestDAL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool CreateTest(Test test)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_AddTest";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", test.Id);
                command.Parameters.AddWithValue("@timeToComplete", test.TimeToPass);
                command.Parameters.AddWithValue("@description", test.Description);

                _connection.Open();
                command.ExecuteNonQuery();
            }
            if (AddQuestionToTest(test))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool AddQuestionToTest(Test test)
        {
            Question[] questionArr = test.QuestionArray;
            var _connection = new SqlConnection(_connectionString);
            for (int i = 0; i < questionArr.Length; i++)
            {
                var stProc = "TestingSystem_AddQuestion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", questionArr[i].Id);
                command.Parameters.AddWithValue("@numberOfQuestion", questionArr[i].NumberOfQuestion);
                command.Parameters.AddWithValue("@numberOfRightAnswer", questionArr[i].NumberOfRightAnswer);
                command.Parameters.AddWithValue("@IdTest", test.Id);

                _connection.Open();
                command.ExecuteNonQuery();
                _connection.Close();

                if (!AddAnswersToQuestion(questionArr[i], test.Id))
                {
                    //ToDO Exception
                }       
            }
            return true;

        }

        private bool AddAnswersToQuestion(Question question, Guid testId)
        {
            string[] answersArr = question.Answers;
            var _connection = new SqlConnection(_connectionString);

            var stProc = "TestingSystem_AddAnswersForQuestion";
            var command = new SqlCommand(stProc, _connection)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.AddWithValue("@Id", new Guid());
            command.Parameters.AddWithValue("@answer1", answersArr[0]);
            command.Parameters.AddWithValue("@answer2", answersArr[1]);
            command.Parameters.AddWithValue("@answer3", answersArr[2]);
            command.Parameters.AddWithValue("@answer4", answersArr[3]);
            command.Parameters.AddWithValue("@questionId", question.Id);

            _connection.Open();
            command.ExecuteNonQuery();
            _connection.Close();

            return true;

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
