using PairingTest.API.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PairingTest.API.Core.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }
        public List<Question> Questions { get; set; }
    }
}
