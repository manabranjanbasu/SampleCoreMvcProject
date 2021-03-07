using PairingTest.API.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Core.Interfaces
{
    public interface IScoreCalculation
    {
        Task<string> CalculateScore(List<UserAnswer> userAnswer, long categoryId);
    }
}
