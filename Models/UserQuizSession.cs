using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    [Table("UserQuizSessions")]
    public class UserQuizSession
    {
        [Key]
        [Column("SessionId")]
        public Guid SessionId { get; set; }

        [Column("UserId")]
        public Guid? UserId { get; set; }  // Nullable nếu người dùng không đăng nhập

        [Column("QuizId")]
        public Guid QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz? Quiz { get; set; }  // Navigation property đến Quiz

        [Column("StartTime")]
        public DateTime StartTime { get; set; }

        [Column("EndTime")]
        public DateTime? EndTime { get; set; }

        [Column("Passed")]
        public bool Passed { get; set; }

        public List<UserAnswer>? UserAnswers { get; set; }
    }
}
