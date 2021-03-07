using PairingTest.API.Core.Entities;
using PairingTest.API.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Core.Services
{
    public class ScoreCalculationService : IScoreCalculation
    {
        private IRepository repository;
        public ScoreCalculationService(IRepository repos)
        {
            this.repository = repos;
        }
        public async Task<string> CalculateScore(List<UserAnswer> userAnswer, long categoryId)
        {
            return await this.repository.CalculateScore(userAnswer, categoryId);
        }
    }
}
