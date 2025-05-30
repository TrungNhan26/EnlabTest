namespace QuizAppApi.DTOs
{
    public class UserAnswerDTO
    {
        public Guid UserAnswerId { get; set; }
        public QuestionDTO Question { get; set; } = new();
        public AnswerOptionDTO AnswerOption { get; set; } = new();
        public bool IsCorrect { get; set; }
    }
}
