using PairingTest.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Core.Interfaces
{
    public interface IQuestionnaireService
    {
        Task<List<Question>> GetAllQuestionsWithOptions(long categoryId);
    }
}
