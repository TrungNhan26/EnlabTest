namespace QuizAppApi.DTOs.Request
{
    public class AnswerSubmitDTO
    {
        public Guid SessionId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid AnswerId { get; set; }
    }
    
}
    