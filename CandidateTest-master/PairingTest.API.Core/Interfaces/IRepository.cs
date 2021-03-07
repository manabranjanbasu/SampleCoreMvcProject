using PairingTest.API.Core.Entities;
using PairingTest.API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Core.Interfaces
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        Task<List<Question>> GetAllQuestions(long categoryId);
        Task<string> CalculateScore(List<UserAnswer> userAnswer, long categoryId);
    }
}
