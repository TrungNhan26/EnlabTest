using AutoMapper;
using QuizAppApi.Models;
using QuizAppApi.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Question, QuestionDTO>();
        CreateMap<AnswerOption, AnswerOptionDTO>();
        CreateMap<UserAnswer, UserAnswerDTO>();
        CreateMap<UserQuizSession, UserQuizSessionDTO>();
        CreateMap<Quiz, QuizDTO>();
    }
}
