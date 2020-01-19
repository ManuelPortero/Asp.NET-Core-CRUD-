using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Models
{
    public class Tag : BaseEntity
    {
       [Required]
        public string Name { get; set; }
    }
}
