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

namespace PairingTest.Unit.Tests.Web.Service
{
    [TestFixture]
    public class QuestionnaireServiceTests
    {
        
        private IQuestionnaireService _questionnaireService;
        private Mock<IQuestionnaireQueryService> _questionnaireQueryService;
        [SetUp]
        public void SetUp()
        {
            _questionnaireQueryService = new Mock<IQuestionnaireQueryService>();
            List<QuestionnaireServiceModel> lstQuestionnaireServiceModel = new List<QuestionnaireServiceModel>();
            QuestionnaireServiceModel qSvcModel = new QuestionnaireServiceModel();
            qSvcModel.questionnaireTitle = "Test";
            lstQuestionnaireServiceModel.Add(qSvcModel);

            _questionnaireQueryService.Setup(qs => qs.GetAllQuestionnaire(1))
                .Returns(Task.FromResult(lstQuestionnaireServiceModel));
            _questionnaireService = new QuestionnaireService(_questionnaireQueryService.Object);
        }
        [Test]
        public async Task ShouldGetAllQuestionnaire()
        {
            //Arrange
            var expectedTitle = "Test";

            //Act
            var result =await _questionnaireService.GetAllQuestionnaire(1);

            //Assert
            Assert.That(result[0].questionnaireTitle, Is.EqualTo(expectedTitle));
        }
    }
}
