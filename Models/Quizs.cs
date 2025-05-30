using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    [Table("Quizzes")]
    public class Quiz
    {
        [Key]
        [Column("QuizId")]
        public Guid QuizId { get; set; }

        [Column("Title")]
        public string? Title { get; set; }

        public List<Question>? Questions { get; set; }
    }
}
