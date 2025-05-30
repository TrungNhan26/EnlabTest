using QuizAppApi.DTOs.Request;
using QuizAppApi.DTOs.Response;
using QuizAppApi.DTOs;

namespace QuizAppApi.Services
{
    public interface IQuizService
    {
        // Lấy danh sách câu hỏi của 1 quiz
        Task<List<QuestionDTO>> GetQuestionsByQuizIdAsync(Guid quizId);

        //Kiểm tra đáp án 
        Task<bool> ValidateAnswerAsync(Guid questionId, Guid answerId);

        // Lưu đáp án của người dùng
        Task<UserAnswerDTO> SubmitUserAnswerAsync(AnswerSubmitDTO dto);

        // Tính điểm và kết quả cuối cùng của bài quiz
        Task<QuizResultDTO> CalculateResultBySessionAsync(Guid sessionId);

    }
}
