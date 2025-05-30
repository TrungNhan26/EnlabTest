using Microsoft.EntityFrameworkCore;
using QuizAppApi.Models;  // Namespace chứa các class Model bạn đã tạo

namespace QuizAppApi.Data
{
    public class QuizDbContext : DbContext
    {
        // Constructor nhận options và chuyển cho base DbContext
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) {}

        // Định nghĩa các DbSet tương ứng với các bảng trong database
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<UserQuizSession> UserQuizSessions { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
