using AskIt.Api.Models;
using AutoMapper;

namespace AskIt.Api.Features.Question
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<QuestionModel, QuestionCreateCommand>().ReverseMap();
        }
    }
}