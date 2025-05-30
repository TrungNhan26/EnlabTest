using System;
using System.Collections.Generic;

namespace QuizAppApi.DTOs.Request
{
    public class QuizRequestDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<AnswerSubmitDTO> SubmittedAnswers { get; set; } = new List<AnswerSubmitDTO>();
    }


}
