using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    [Table("UserAnswers")]
    public class UserAnswer
    {
        [Key]
        [Column("UserAnswerId")]
        public Guid UserAnswerId { get; set; }

        [Column("SessionId")]
        public Guid SessionId { get; set; }

        [ForeignKey("SessionId")]
        public UserQuizSession? UserQuizSession { get; set; }

        [Column("QuestionId")]
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question? Question { get; set; }

        [Column("AnswerOptionId")]
        public Guid AnswerOptionId { get; set; }

        [ForeignKey("AnswerOptionId")]
        public AnswerOption? AnswerOption { get; set; }

        [Column("IsCorrect")]
        public bool IsCorrect { get; set; }
    }
}
