namespace QuizAppApi.DTOs
{

    public class QuestionDTO
    {
        public Guid QuestionId { get; set; }
        public string Content { get; set; } = string.Empty;
        public List<AnswerOptionDTO> AnswerOptions { get; set; } = new();
    }
}
