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
                command.Parameters.AddWithValue("@numberOfQuestions", test.NumberOfQuestions);

                _connection.Open();
                return command.ExecuteNonQuery() > 0 && AddQuestionToTest(test);

            }

        }
        private bool AddQuestionToTest(Test test)
        {
            Question[] questionArr = test.QuestionArray;
            var isSuccess = true;
            var _connection = new SqlConnection(_connectionString);
            for (int i = 0; i < questionArr.Length; i++)
            {
                var stProc = "TestingSystem_AddQuestion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", questionArr[i].Id);
                command.Parameters.AddWithValue("@description", questionArr[i].Description);
                command.Parameters.AddWithValue("@numberOfQuestion", questionArr[i].NumberOfQuestion);
                command.Parameters.AddWithValue("@numberOfRightAnswer", questionArr[i].NumberOfRightAnswer);
                command.Parameters.AddWithValue("@IdTest", test.Id);

                _connection.Open();
                isSuccess = command.ExecuteNonQuery() > 0 ? true : false;
                _connection.Close();

                if (!isSuccess||!AddAnswersToQuestion(questionArr[i], test.Id))
                {
                    return false;
                }
            }
            return true;

        }

        private bool AddAnswersToQuestion(Question question, Guid testId)
        {
            string[] answersArr = question.Answers;
            using (var _connection = new SqlConnection(_connectionString))
            {

                var stProc = "TestingSystem_AddAnswersForQuestion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@answer1", answersArr[0]);
                command.Parameters.AddWithValue("@answer2", answersArr[1]);
                command.Parameters.AddWithValue("@answer3", answersArr[2]);
                command.Parameters.AddWithValue("@answer4", answersArr[3]);
                command.Parameters.AddWithValue("@questionId", question.Id);

                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }

        }

        public Test GetTestById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Test> GetAllTests()
        {
            throw new NotImplementedException();
        }

        public bool isTestAlreadyExist(string name)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_IsTestExist";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@description", name);
                _connection.Open();
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public Test GetTestParamsByDescription(string descriptions)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                Test test = null;
                var stProc = "TestingSystem_GetTestParamsByDescription";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@description", descriptions);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    test = new Test(Guid.Parse(reader["Id"].ToString()),
                        reader["Name"].ToString(),
                        int.Parse(reader["NumberOfQuestions"].ToString()),
                        int.Parse(reader["TimeToComplete"].ToString()));
                }
                return test;
            }
        }

        public IEnumerable<string> GetAllTestsDescriptions()
        {
            List<string> testsDescriptions = new List<string>();
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_GetAllTestsDescriptions";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    testsDescriptions.Add(reader["Name"].ToString());
                }
                return testsDescriptions;
            }
        }

        public Test GetTestByDescription(string description)
        {
            var _connection = new SqlConnection(_connectionString);
            Guid id = default;
            string name = default;
            int numberOfQuestions = default;
            int timeToComplete = default;
            using (_connection)
            {
                var stProc = "TestingSystem_GetTestByDescription";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@description", description);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    id = Guid.Parse(reader["Id"].ToString());
                    name = reader["Name"].ToString();
                    numberOfQuestions = int.Parse(reader["NumberOfQuestions"].ToString());
                    timeToComplete = int.Parse(reader["TimeToComplete"].ToString());
                }
            }
            return new Test(id, name, numberOfQuestions, timeToComplete, GetQuestionsById(id, numberOfQuestions));
        }
        private Question[] GetQuestionsById(Guid TestId, int numberOfQuestions)
        {
            Question[] arrOfQuestions = new Question[numberOfQuestions];
            var _connection = new SqlConnection(_connectionString);
            int counter = 0;
            using (_connection)
            {
                var stProc = "TestingSystem_GetQuestionsById";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", TestId);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    arrOfQuestions[counter] = new Question(
                        Guid.Parse(reader["Id"].ToString()),
                        reader["Description"].ToString(),
                        int.Parse(reader["NumberOfQuestion"].ToString()),
                        int.Parse(reader["NumberOfRightAnswer"].ToString()));
                    counter++;
                }
            }
            for (int i = 0; i < arrOfQuestions.Length; i++)
            {
                arrOfQuestions[i].Answers = GetAnswersByQuestionID(arrOfQuestions[i].Id);
            }
            return arrOfQuestions;
        }
        private string[] GetAnswersByQuestionID(Guid questionId)
        {
            string[] arrOfQuestions = new string[4];
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_GetAnswersByQuestionID";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", questionId);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    arrOfQuestions[0] = reader["Answer1"].ToString();
                    arrOfQuestions[1] = reader["Answer2"].ToString();
                    arrOfQuestions[2] = reader["Answer3"].ToString();
                    arrOfQuestions[3] = reader["Answer4"].ToString();
                }
            }
            return arrOfQuestions;
        }

        public bool BindingTestToUser(Guid userId, Guid testId, int quontityOfRightAnswers, int quontityOfQuestions)
        {

            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_BindingTestToUser";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@testId", testId);
                command.Parameters.AddWithValue("@quontityOfRightAnswers", quontityOfRightAnswers);
                command.Parameters.AddWithValue("@quontityOfQuestions", quontityOfQuestions);

                _connection.Open();
                return command.ExecuteNonQuery() == 1;
            }

        }

        public int[] GetTestResultByUserId(Guid userId, Guid testId)
        {
            int[] arr = null;
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_GetTestResultByIds";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@testId", testId);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    arr = new int[] { int.Parse(reader["TestResult"].ToString()), int.Parse(reader["QuantityOfQuestions"].ToString()) };
                }
            }
            return arr;
        }

        public IEnumerable<Result> GetUsersResults(Guid userId)
        {
            List<Result> listOfTests = new List<Result>();
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_GetUsersResults";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    listOfTests.Add(new Result(
                        Guid.Parse(reader["IdUser"].ToString()),
                        Guid.Parse(reader["IdTest"].ToString()),
                        reader["Name"].ToString()));
                }
            }
            return listOfTests;
        }

        public bool IsTestAlreadyDone(Guid userId, Guid testId)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_IsTestDone";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@testId", testId);
                _connection.Open();
                return (int)command.ExecuteScalar() == 1;
            }
        }

        public bool DeleteTest(Guid testId)
        {
            var _connection = new SqlConnection(_connectionString);
            using (_connection)
            {
                var stProc = "TestingSystem_TestDeletion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", testId);
                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateTest(Test test)
        {
            var _connection = new SqlConnection(_connectionString);
            int numOfReturnedSting = 0;
            using (_connection)
            {
                var stProc = "TestingSystem_UpdateTest";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", test.Id);
                command.Parameters.AddWithValue("@timeToComplete", test.TimeToPass);
                command.Parameters.AddWithValue("@description", test.Description);
                command.Parameters.AddWithValue("@numberOfQuestions", test.NumberOfQuestions);

                _connection.Open();
                numOfReturnedSting = command.ExecuteNonQuery();
            }
            return numOfReturnedSting > 0 && UpdateQuestionOnTest(test);
        }

        private bool UpdateQuestionOnTest(Test test)
        {
            Question[] questionArr = test.QuestionArray;
            var _connection = new SqlConnection(_connectionString);
            var allIsRight = true;
            for (int i = 0; i < questionArr.Length; i++)
            {
                var stProc = "TestingSystem_UpdateQuestion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@id", questionArr[i].Id);
                command.Parameters.AddWithValue("@numberOfQuestion", questionArr[i].NumberOfQuestion);
                command.Parameters.AddWithValue("@numberOfRightAnswer", questionArr[i].NumberOfRightAnswer);
                command.Parameters.AddWithValue("@description", questionArr[i].Description);
                _connection.Open();
                if (!(command.ExecuteNonQuery() > 0))
                {
                    allIsRight = false;
                }
                _connection.Close();

                if (!allIsRight || !UpdateAnswersInQuestion(questionArr[i], test.Id))
                {
                    return false;
                }
            }
            return true;
        }

        private bool UpdateAnswersInQuestion(Question question, Guid id)
        {
            string[] answersArr = question.Answers;
            using (var _connection = new SqlConnection(_connectionString))
            {

                var stProc = "TestingSystem_UpdateAnswersForQuestion";
                var command = new SqlCommand(stProc, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@answer1", answersArr[0]);
                command.Parameters.AddWithValue("@answer2", answersArr[1]);
                command.Parameters.AddWithValue("@answer3", answersArr[2]);
                command.Parameters.AddWithValue("@answer4", answersArr[3]);
                command.Parameters.AddWithValue("@questionId", question.Id);

                _connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

    }
}
