namespace QuizAppApi.DTOs.Response
{
    public class QuizResultDTO
    {
        public TimeSpan Duration { get; set; }
        public int CorrectCount { get; set; }
        public bool Passed { get; set; }
    }
}

