using Microsoft.EntityFrameworkCore;
using PairingTest.API.Core.Entities;
using PairingTest.API.Infrastructure.DBMapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PairingTest.API.Infrastructure.Data
{
    public class PairingTestDBContext : DbContext
    {
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionOption> QuestionOption { get; set; }

        public PairingTestDBContext(DbContextOptions<PairingTestDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
               new { Id = (long)1, CategoryName = "Geography Questions" }
            );

            modelBuilder.Entity<Question>().HasData(
               new { Id = (long)1, QuestionnaireTitle = "What is the capital of Cuba?", CategoryId =(long)1 },
               new { Id = (long)2, QuestionnaireTitle = "What is the capital of France?", CategoryId = (long)1 },
               new { Id = (long)3, QuestionnaireTitle = "What is the capital of Poland?", CategoryId = (long)1 },
               new { Id = (long)4, QuestionnaireTitle = "What is the capital of Germany?", CategoryId = (long)1 }
            );

            modelBuilder.Entity<QuestionOption>().HasData(
               new { Id = (long)1, OptionText = "Havana", IsCorrectAnswer = true, QuestionID =(long)1 },
               new { Id = (long)2, OptionText = "Paris", IsCorrectAnswer = false, QuestionID = (long)1 },
               new { Id = (long)3, OptionText = "Warsaw", IsCorrectAnswer = false, QuestionID = (long)1 },
               new { Id = (long)4, OptionText = "Berlin", IsCorrectAnswer = false, QuestionID = (long)1 }
            );

            modelBuilder.Entity<QuestionOption>().HasData(
               new { Id = (long)5, OptionText = "Havana", IsCorrectAnswer = false, QuestionID = (long)2 },
               new { Id = (long)6, OptionText = "Paris", IsCorrectAnswer = true, QuestionID = (long)2 },
               new { Id = (long)7, OptionText = "Warsaw", IsCorrectAnswer = false, QuestionID = (long)2 },
               new { Id = (long)8, OptionText = "Berlin", IsCorrectAnswer = false, QuestionID = (long)2 }
            );
            modelBuilder.Entity<QuestionOption>().HasData(
               new { Id = (long)9, OptionText = "Havana", IsCorrectAnswer = false, QuestionID = (long)3 },
               new { Id = (long)10, OptionText = "Paris", IsCorrectAnswer = false, QuestionID = (long)3 },
               new { Id = (long)11, OptionText = "Warsaw", IsCorrectAnswer = true, QuestionID = (long)3 },
               new { Id = (long)12, OptionText = "Berlin", IsCorrectAnswer = false, QuestionID = (long)3 }
            );
            modelBuilder.Entity<QuestionOption>().HasData(
               new { Id = (long)13, OptionText = "Havana", IsCorrectAnswer = false, QuestionID = (long)4 },
               new { Id = (long)14, OptionText = "Paris", IsCorrectAnswer = false, QuestionID = (long)4 },
               new { Id = (long)15, OptionText = "Warsaw", IsCorrectAnswer = false, QuestionID = (long)4 },
               new { Id = (long)16, OptionText = "Berlin", IsCorrectAnswer = true, QuestionID = (long)4 }
            );

            modelBuilder.Entity<Question>().HasOne<Category>(c => c.QuestionCategory).WithMany(qc => qc.Questions).HasForeignKey(c => c.CategoryId).IsRequired();
            
            new QuestionMap(modelBuilder.Entity<Question>());
            new QuestionOptionMap(modelBuilder.Entity<QuestionOption>());
            new CategoryMap(modelBuilder.Entity<Category>());
        }
    }
}
