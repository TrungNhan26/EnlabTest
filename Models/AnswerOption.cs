using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    [Table("AnswerOptions")]  // Tên bảng trong database
    public class AnswerOption
    {
        [Key]                    // Khóa chính
        [Column("AnswerOptionId")] 
        public Guid AnswerOptionId { get; set; }

        [Column("QuestionId")]
        public Guid QuestionId { get; set; }

        [ForeignKey("QuestionId")]  // Khóa ngoại
        public Question? Question { get; set; }

        [Column("AnswerText")]
        public string? AnswerText { get; set; }

        [Column("IsCorrect")]
        public bool IsCorrect { get; set; }
    }
}