using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace PairingTest.API.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        [Required]
        [Key]
        public long Id { get; set; }
    }
}
