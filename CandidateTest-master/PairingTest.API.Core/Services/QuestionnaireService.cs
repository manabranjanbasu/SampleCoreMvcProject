using PairingTest.API.Core.Entities;
using PairingTest.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Core.Services
{
    public class QuestionnaireService : IQuestionnaireService
    {
        private IRepository repository;
        public QuestionnaireService(IRepository repos)
        {
            this.repository = repos;
        }
        public async Task<List<Question>> GetAllQuestionsWithOptions(long categoryId)
        {
            return await this.repository.GetAllQuestions(categoryId);
        }
    }
}
