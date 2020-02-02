using AskIt.Api.Models;
using MediatR;

namespace AskIt.Api.Features.Question
{
    public class QuestionCreateCommand: IRequest<QuestionModel>
    {
        public string Title { get; set; }
    }
}