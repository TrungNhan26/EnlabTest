namespace QuizAppApi.DTOs
{
    public class QuizDTO
    {
        public Guid QuizId { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<QuestionDTO> Questions { get; set; } = new();
    }
}
