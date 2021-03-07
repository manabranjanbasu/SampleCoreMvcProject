using PairingTest.API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PairingTest.API.Core.Entities
{
    public class Question : BaseEntity
    {
        [Required]
        public string QuestionnaireTitle { get; set; }
        public List<QuestionOption> QuestionOption { get; set; }
        public long CategoryId { get; set; }
        public Category QuestionCategory { get; set; }
    }
}
