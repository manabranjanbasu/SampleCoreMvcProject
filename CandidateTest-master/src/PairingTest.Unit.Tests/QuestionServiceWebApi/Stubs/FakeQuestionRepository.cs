using PairingTest.WebApi;
using PairingTest.WebApi.Interfaces;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Stubs
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }
        public Questionnaire GetQuestionnaire()
        {
            return ExpectedQuestions;
        }
    }
}