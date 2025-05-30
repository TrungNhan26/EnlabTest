using QuizAppApi.DTOs;
using QuizAppApi.DTOs.Request;
using QuizAppApi.DTOs.Response;
using QuizAppApi.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace QuizAppApi.Services
{
    public class QuizService : IQuizService
    {
        private readonly QuizRepository _repository;
        private readonly IMapper _mapper;
        private readonly QuizDbContext _context;

        // Inject thêm QuizDbContext
        public QuizService(QuizRepository repository, IMapper mapper, QuizDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<QuestionDTO>> GetQuestionsByQuizIdAsync(Guid quizId)
        {
            var questions = await _repository.GetQuestionsByQuizIdAsync(quizId);
            var questionDtos = _mapper.Map<List<QuestionDTO>>(questions);
            return questionDtos;
        }

        public async Task<bool> ValidateAnswerAsync(Guid questionId, Guid answerId)
        {
            return await _repository.IsCorrectAnswerAsync(questionId, answerId);
        }

        public async Task<UserAnswerDTO> SubmitUserAnswerAsync(AnswerSubmitDTO dto)
        {
            var userAnswerEntity = await _repository.SaveUserAnswerAsync(dto);
            var userAnswerDto = _mapper.Map<UserAnswerDTO>(userAnswerEntity);
            return userAnswerDto;
        }

        public async Task<QuizResultDTO> CalculateResultBySessionAsync(Guid sessionId)
        {
            var userAnswers = await _repository.GetUserAnswersBySessionIdAsync(sessionId);
            if (userAnswers == null || userAnswers.Count == 0)
                throw new Exception("No answers found for this session");

            int correctCount = userAnswers.Count(ua => ua.IsCorrect == true);

            var session = await _repository.GetUserQuizSessionByIdAsync(sessionId);
            if (session == null)
                throw new Exception("Session not found");

            TimeSpan duration = (session.EndTime ?? DateTime.UtcNow) - session.StartTime;

            bool passed = correctCount >= 3;

            // Cập nhật trạng thái passed cho session
            session.Passed = passed;
            await _repository.UpdateUserQuizSessionAsync(session);

            return new QuizResultDTO
            {
                Duration = duration,
                CorrectCount = correctCount,
                Passed = passed
            };
        }

    }
}
