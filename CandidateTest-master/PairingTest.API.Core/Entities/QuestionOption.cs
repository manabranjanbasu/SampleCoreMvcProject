using PairingTest.API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PairingTest.API.Core.Entities
{
    public class QuestionOption : BaseEntity
    {
        [Required]
        public long QuestionID { get; set; }
        public Question QuestionOptionQuestion { get; set; }
        [Required]
        public string OptionText { get; set; }

        public bool IsCorrectAnswer { get; set; }
    }
}
