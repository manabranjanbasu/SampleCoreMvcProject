using PairingTest.WebCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.WebInfrastructure.Interfaces
{
    public interface IQuestionnaireQueryService
    {
        Task<QuestionnaireServiceModel> GetAllQuestionnaire();
    }
}
