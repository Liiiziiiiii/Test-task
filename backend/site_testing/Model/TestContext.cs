using Microsoft.EntityFrameworkCore;
using test_site;

namespace site_testing.Model
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) :
    base(options)
        {
        }
        public DbSet<User> user { get; set; }

        public DbSet<Test> test { get; set; }
        public DbSet<Question> question { get; set; }
        public DbSet<Answer> answer { get; set; }
        public DbSet<CompletedTest> completedTest { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                .HasKey(a => new { a.QuestionId, a.QuestionIdQuestion, a.QuestionTestId });

            modelBuilder.Entity<Question>()
                .HasKey(q => q.IdQuestion);

            modelBuilder.Entity<Test>()
               .HasKey(t => t.Idtest);

            modelBuilder.Entity<User>()
               .HasKey(t => t.UserId);

            modelBuilder.Entity<CompletedTest>()
                .HasKey(ct => new { ct.IdCompletedTest });

            modelBuilder.Entity<CompletedTest>()
                .HasOne(ct => ct.Test)
                .WithMany(t => t.CompletedTests)
                .HasForeignKey(ct => ct.TestId);

            modelBuilder.Entity<CompletedTest>()
                .HasOne(ct => ct.User)
                .WithMany(u => u.CompletedTests)
                .HasForeignKey(ct => ct.UserId);

        }
    }
}
