using System.Linq;
using Microsoft.EntityFrameworkCore;
using SampleExam.Domain;
using SampleExam.Common;

namespace SampleExam.Infrastructure.Data
{
    public class SampleExamContext : DbContext
    {

        public SampleExamContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamTag> ExamTags { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExam> UserExams { get; set; }
        public DbSet<UserExamQuestion> UserExamQuestions { get; set; }
        public DbSet<UserExamQuestionAnswr> UserExamQuestionAnswers { get; set; }
        public DbSet<UserExamResult> UserExamResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();

            modelBuilder.Entity<Gender>().Property(e => e.Id)
            .ValueGeneratedNever()
            .HasAnnotation("DatabaseGenerated",
             System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            modelBuilder.Entity<Gender>().HasData(SeedData.Genders.Male, SeedData.Genders.Female);
            modelBuilder.Entity<QuestionType>().HasData(SeedData.QuestionTypes.Radio, SeedData.QuestionTypes.Checkbox);

            modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique().HasFilter("\"IsDeleted\" = false");
            modelBuilder.Entity<User>().Property(e => e.Firstname).IsRequired().HasMaxLength(Constants.USER_FIRSTNAME_LEN);
            modelBuilder.Entity<User>().Property(e => e.Lastname).IsRequired().HasMaxLength(Constants.USER_LASTNAME_LEN);
            modelBuilder.Entity<User>().Property(e => e.Middlename).HasMaxLength(Constants.USER_MIDDLENAME_LEN);
            modelBuilder.Entity<User>().Property(e => e.Dob).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Email).IsRequired().HasMaxLength(Constants.USER_EMAIL_LEN);
            modelBuilder.Entity<User>().Property(e => e.Password).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.IsEmailConfirmed).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<User>().Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<User>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.UpdatedAt).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.DeletedAt).IsRequired(false);
            modelBuilder.Entity<User>().HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<RefreshToken>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<RefreshToken>().Property(e => e.Token).IsRequired().HasMaxLength(Constants.REFRESH_TOKEN_LEN);

            modelBuilder.Entity<Exam>().Property(e => e.Title).IsRequired().HasMaxLength(Constants.EXAM_TITLE_LEN);
            modelBuilder.Entity<Exam>().Property(e => e.Description).IsRequired().HasMaxLength(Constants.EXAM_DESCRIPTIION_LEN);
            modelBuilder.Entity<Exam>().Property(e => e.IsPrivate).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Exam>().Property(e => e.IsPublished).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Exam>().Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<Exam>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<Exam>().Property(e => e.UpdatedAt).IsRequired();
            modelBuilder.Entity<Exam>().Property(e => e.DeletedAt).IsRequired(false);
            modelBuilder.Entity<Exam>().HasQueryFilter(e => !e.IsDeleted);

            modelBuilder.Entity<AnswerOption>().Property(e => e.Text).IsRequired().HasMaxLength(Constants.ANSWEROPTION_TEXT_LEN);
            modelBuilder.Entity<AnswerOption>().Property(e => e.IsRight).IsRequired();
            modelBuilder.Entity<AnswerOption>().Property(e => e.CreatedAt).IsRequired();

            modelBuilder.Entity<Tag>().Property(e => e.TagId).IsRequired().HasMaxLength(Constants.TAG_TEXT_LEN);
            modelBuilder.Entity<Tag>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<Tag>().HasKey(e => e.TagId);


            modelBuilder.Entity<ExamTag>().HasKey(e => new { e.ExamId, e.TagId });
            modelBuilder.Entity<ExamTag>().HasOne(e => e.Exam).WithMany(e => e.ExamTags)
                .HasForeignKey(e => e.ExamId);
            modelBuilder.Entity<ExamTag>().HasOne(e => e.Tag).WithMany(e => e.ExamTags)
                .HasForeignKey(e => e.TagId);
            modelBuilder.Entity<ExamTag>().Property(e => e.CreatedAt).IsRequired();

            modelBuilder.Entity<UserExam>().HasOne(e => e.User).WithMany(e => e.UserExams)
                .HasForeignKey(e => e.UserId);
            modelBuilder.Entity<UserExam>().HasOne(e => e.Exam).WithMany(e => e.UserExams)
                .HasForeignKey(e => e.ExamId);
            modelBuilder.Entity<UserExam>().Property(e => e.StartedtedAt).IsRequired();


            modelBuilder.Entity<Question>().Property(e => e.Text).IsRequired().HasMaxLength(Constants.QUESTION_TEXT_LEN);
            modelBuilder.Entity<Question>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<Question>().Property(e => e.UpdatedAt).IsRequired();

            modelBuilder.Entity<QuestionType>().Property(e => e.Name).IsRequired().HasMaxLength(Constants.QUESTION_TYPE);

            modelBuilder.Entity<UserExamQuestion>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<UserExamQuestion>().Property(e => e.UpdatedAt).IsRequired();
            modelBuilder.Entity<UserExamQuestion>().HasKey(e => new { e.UserExamId, e.QuestionId });
            modelBuilder.Entity<UserExamQuestion>().Property(e => e.HasRightAnswer).IsRequired().HasDefaultValue(false);

            //UserExamQuestionAnswr
            modelBuilder.Entity<UserExamQuestionAnswr>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<UserExamQuestionAnswr>().Property(e => e.UpdatedAt).IsRequired();
            modelBuilder.Entity<UserExamQuestionAnswr>().HasKey(e => new { e.UserExamId, e.QuestionId, e.AnswerOptionId });

            modelBuilder.Entity<UserExamResult>().HasKey(e => e.UserExamId);
            modelBuilder.Entity<UserExamResult>().Property(e => e.IsPassed).IsRequired().HasDefaultValue(false);
            modelBuilder.Entity<UserExamResult>().Property(e => e.CreatedAt).IsRequired();
            modelBuilder.Entity<UserExamResult>().Property(e => e.UpdatedAt).IsRequired();
            modelBuilder.Entity<UserExamResult>().HasOne(e => e.UserExam)
            .WithOne(e => e.UserExamResult).HasForeignKey<UserExamResult>(e => e.UserExamId);


            //disable cascade delete
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))//.Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}