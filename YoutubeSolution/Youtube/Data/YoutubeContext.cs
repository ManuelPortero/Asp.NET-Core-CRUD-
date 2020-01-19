using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Youtube.Models;
namespace Youtube.Data
{
    public class YoutubeContext : DbContext
    {
        public YoutubeContext(DbContextOptions<YoutubeContext> options) : base(options)
        { }

        public DbSet<Tag> Tags { get; set;  }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new Author
            {
                CreatedDate = DateTime.Now,
                FirstName = "Daniel",
                LastName = "Garcia",
                Id = 1,
                Birthdate = DateTime.Now

            });
        }

    }
}
