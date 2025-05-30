namespace QuizAppApi.DTOs
{
    public class UserQuizSessionDTO
    {
        public Guid SessionId { get; set; }
        public Guid UserId { get; set; }
        public QuizDTO Quiz { get; set; } = new();
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Passed { get; set; }
        public List<UserAnswerDTO> UserAnswers { get; set; } = new();
    }
}
