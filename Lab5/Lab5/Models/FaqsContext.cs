using Microsoft.EntityFrameworkCore;

namespace Lab5.Models
{
    public class FaqsContext : DbContext

    {
        public FaqsContext(DbContextOptions<FaqsContext> options)
            : base(options) { }

        public DbSet<FAQ> FAQs { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "cs", Name = "C#" },
                new Topic { TopicId = "js", Name = "Javascript" },
                new Topic { TopicId = "boot", Name = "Boostrap" }

                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "gen", Name = "General" },
                new Category { CategoryId = "hist", Name = "Histry" }
                //new Topic { CategoryId = "boot", Name = "Boostrap" }

                );


            modelBuilder.Entity<FAQ>().HasData(
                new FAQ
                {
                    Id = 1, 
                    Question = "General",
                    Answer = "General",
                    TopicID = "", 


                } 

                );
        }
    }
}
