using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set;  }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        

    }
}
