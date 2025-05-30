using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizAppApi.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        [Column("QuestionId")]
        public Guid QuestionId { get; set; }

        [Column("QuizId")]
        public Guid QuizId { get; set; }

        [ForeignKey("QuizId")]
        public Quiz? Quiz { get; set; }

        [Column("Content")]
        public string Content { get; set; } = string.Empty;

        
        public List<AnswerOption> AnswerOptions { get; set; } = new List<AnswerOption>();

    }
}
