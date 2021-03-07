using PairingTest.Web.Core.Models;
using PairingTest.WebCore.Interfaces;
using PairingTest.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.WebCore.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private readonly IQuestionnaireQueryService questionnaireQueryService;
        public QuestionnaireService(IQuestionnaireQueryService _questionnaireQueryService)
        {
            questionnaireQueryService = _questionnaireQueryService;
        }
        public async Task<List<QuestionnaireServiceModel>> GetAllQuestionnaire(long categoryId)
        {
            return await questionnaireQueryService.GetAllQuestionnaire(categoryId);
        }
        public async Task<string> CalculateScore(List<UserSelection> lstUserSelection, long categoryId)
        {
            return await questionnaireQueryService.CalculateScore(lstUserSelection, categoryId);
        }
    }
}
