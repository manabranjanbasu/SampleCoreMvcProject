using PairingTest.Web.Core.Models;
using PairingTest.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.WebCore.Interfaces
{
    public interface IQuestionnaireQueryService
    {
        Task<List<QuestionnaireServiceModel>> GetAllQuestionnaire(long categoryId);
        Task<string> CalculateScore(List<UserSelection> lstUserSelection, long categoryId);
    }
}
