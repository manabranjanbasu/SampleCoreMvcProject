using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PairingTest.API.Core.Entities;
using PairingTest.API.Core.Interfaces;
using PairingTest.API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PairingTest.API.Infrastructure.Data
{
    public class PairingTestRepository : IRepository
    {
        private readonly PairingTestDBContext dbContext;
        public PairingTestRepository(PairingTestDBContext context)
        {
            this.dbContext = context;

            if (this.dbContext.Database.IsSqlServer())
            {
                this.dbContext.Database.Migrate();
            }
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            this.dbContext.Set<T>().Add(entity);
            this.dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            this.dbContext.Set<T>().Remove(entity);
            this.dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }

        public async Task<List<Question>> GetAllQuestions(long categoryId)
        {
            List<Question> lstQuestion = await this.dbContext.Question
                .Where(p=>p.CategoryId == categoryId)
                .Include(p=>p.QuestionOption)
                .Include(p => p.QuestionCategory)
                .ToListAsync<Question>();
            return lstQuestion;
        }

        public async Task<string> CalculateScore(List<UserAnswer> userAnswer, long categoryId)
        {
            int totalQuestionCount = await this.dbContext.Question.CountAsync(p => p.CategoryId.Equals(categoryId));
            int correctAnswerCount = 0;

            foreach(var answer in userAnswer)
            {
                int correct = await this.dbContext.QuestionOption.Where(
                    p => p.QuestionOptionQuestion.CategoryId.Equals(categoryId)
                    && p.QuestionID == Convert.ToInt64(answer.QuestionId)
                    && p.Id == Convert.ToInt64(answer.SelectedAnswerId) 
                    && p.IsCorrectAnswer                    
                    ).CountAsync();
                if (correct > 0)
                    correctAnswerCount++;
            }
            int CorrectAnswerPercentage = ((correctAnswerCount * 100 )/ totalQuestionCount) ;
            return $"Your Total Score is {CorrectAnswerPercentage} %";
        }
    }
}
