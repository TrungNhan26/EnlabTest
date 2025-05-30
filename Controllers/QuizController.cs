using Microsoft.AspNetCore.Mvc;
using QuizAppApi.DTOs;
using QuizAppApi.DTOs.Request;
using QuizAppApi.DTOs.Response;
using QuizAppApi.Services;

[ApiController]
[Route("api/[controller]")]
public class QuizController : ControllerBase
{
    private readonly IQuizService _quizService;

    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }

    // 1. Lấy danh sách câu hỏi và đáp án
    [HttpGet("questions")]
    public async Task<IActionResult> GetQuestions([FromQuery] Guid quizId)
    {
        var questions = await _quizService.GetQuestionsByQuizIdAsync(quizId);
        return Ok(questions);
    }
    // 2. Xác thực đáp án của người dùng
    [HttpPost("validate-answer")]
    public async Task<IActionResult> ValidateAnswer([FromBody] AnswerSubmitDTO dto)
    {
        // Gọi service lưu câu trả lời và kiểm tra đúng sai
        var userAnswerDto = await _quizService.SubmitUserAnswerAsync(dto);
        
        // Trả về kết quả đúng/sai cho client
        return Ok(new { isCorrect = userAnswerDto.IsCorrect });
    }
    // 3. Xem kết quả quiz
    [HttpGet("quiz-result")]
    public async Task<IActionResult> GetQuizResult([FromQuery] Guid sessionId)
    {
        try
        {
            var result = await _quizService.CalculateResultBySessionAsync(sessionId);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
