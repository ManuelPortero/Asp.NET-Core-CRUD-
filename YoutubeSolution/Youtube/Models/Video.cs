using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Youtube.Models
{
    public class Video : BaseEntity
    {
        [Required]
        public String Title { get; set; }
        public String Description { get; set; }
        [Required]
        public String Url { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public List<Tag> Tags { get; set; }

    }
}
