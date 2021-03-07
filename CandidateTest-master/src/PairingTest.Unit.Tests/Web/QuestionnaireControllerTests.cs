using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using PairingTest.WebCore.Interfaces;
using PairingTest.WebCore.Models;
using PairingTest.WebCore.Services;
using PairingTest.WebInfrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        private Mock<IConfiguration> _config;
        private QuestionnaireController _questionnaireController;

        [SetUp]
        public void SetUp()
        {
            _config = new Mock<IConfiguration>();
            
            Mock<IQuestionnaireService> _questionnaireService = new Mock<IQuestionnaireService>();
            List<QuestionnaireServiceModel> lstQSvcModel = new List<QuestionnaireServiceModel>();
            QuestionnaireServiceModel QSvcModel = new QuestionnaireServiceModel();
            QSvcModel.questionnaireTitle = It.IsAny<string>();
            lstQSvcModel.Add(QSvcModel);
            _questionnaireService.Setup(qs => qs.GetAllQuestionnaire(1))
                .Returns(Task.FromResult(lstQSvcModel));
            var mockMapper = new Mock<IMapper>();
            _questionnaireController = new QuestionnaireController(_config.Object, _questionnaireService.Object, mockMapper.Object);
        }

        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "My expected quesitons";
            var mockModel = Mock.Of<QuestionnaireViewModel>(x => x.questionnaireTitle == "My expected quesitons");//Add Mock

            //Act
            //var result = (QuestionnaireViewModel)_questionnaireController.Index().ViewData.Model;
            var result = (QuestionnaireViewModel)_questionnaireController.Index(mockModel).Result.ViewData.Model;
            //var result = (QuestionnaireViewModel)_questionnaireController.Index(mockModel).ViewData.Model;

            //Assert
            Assert.That(result.questionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}