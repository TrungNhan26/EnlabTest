using QuizAppApi.Data;
using QuizAppApi.DTOs.Request;
using QuizAppApi.Models;
using Microsoft.EntityFrameworkCore;

public class QuizRepository
{
    private readonly QuizDbContext _context;

    public QuizRepository(QuizDbContext context)
    {
        _context = context;
    }

    // Lấy toàn bộ câu hỏi cùng đáp án
    public async Task<List<Question>> GetQuestionsByQuizIdAsync(Guid quizId)
    {
        return await _context.Questions
            .Where(q => q.QuizId == quizId)
            .Include(q => q.AnswerOptions)
            .ToListAsync();
    }

    // Trong QuizRepository.cs
    public async Task<bool> IsCorrectAnswerAsync(Guid questionId, Guid answerId)
    {
        // Tìm câu hỏi theo questionId
        var question = await _context.Questions
            .Include(q => q.AnswerOptions)
            .FirstOrDefaultAsync(q => q.QuestionId == questionId);
        if (question == null)
            return false;
        // Kiểm tra xem answerId có phải là đáp án đúng
        var answer = question.AnswerOptions.FirstOrDefault(a => a.AnswerOptionId == answerId);
        return answer != null && answer.IsCorrect;
    }

    public async Task<UserAnswer> SaveUserAnswerAsync(AnswerSubmitDTO dto)
    {
        var isCorrect = await IsCorrectAnswerAsync(dto.QuestionId, dto.AnswerId);

        var userAnswer = new UserAnswer
        {
            UserAnswerId = Guid.NewGuid(),
            SessionId = dto.SessionId,
            QuestionId = dto.QuestionId,
            AnswerOptionId = dto.AnswerId,
            IsCorrect = isCorrect
        };

        _context.UserAnswers.Add(userAnswer);
        await _context.SaveChangesAsync();

        return userAnswer;
    }

    public async Task<UserQuizSession?> GetUserQuizSessionByIdAsync(Guid sessionId)
    {
        return await _context.UserQuizSessions
            .FirstOrDefaultAsync(s => s.SessionId == sessionId);
    }

    public async Task<List<UserAnswer>> GetUserAnswersBySessionIdAsync(Guid sessionId)
    {
        return await _context.UserAnswers
            .Where(ua => ua.SessionId == sessionId)
            .ToListAsync();
    }

    public async Task UpdateUserQuizSessionAsync(UserQuizSession session)
    {
        _context.UserQuizSessions.Update(session);
        await _context.SaveChangesAsync();
    }



}
