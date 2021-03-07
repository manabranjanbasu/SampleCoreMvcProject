using Moq;
using NUnit.Framework;
using PairingTest.API.Core.Entities;
using PairingTest.API.Core.Interfaces;
using PairingTest.API.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.QuestionServiceWebApi.Service
{
    [TestFixture]
    public class QuestionnaireServiceTest
    {
        private Mock<IRepository> _repository;
        private IQuestionnaireService _questionnaireService;
        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IRepository>();

            List<Question> lstQuestion = new List<Question>() { new Question() { QuestionnaireTitle = "Test", CategoryId = It.IsAny<long>() } };

            _repository.Setup(qs => qs.GetAllQuestions(It.IsAny<long>()))
                .Returns(Task.FromResult(lstQuestion));

            _questionnaireService = new QuestionnaireService(_repository.Object);
        }
        [Test]
        public async Task QuestionnaireServiceGetAllQuestionsWithOptions()
        {
            //Arrange
            var expectedTitle = "Test";

            //Act
            var result = await _questionnaireService.GetAllQuestionsWithOptions(1);

            //Assert
            Assert.That(result[0].QuestionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}
