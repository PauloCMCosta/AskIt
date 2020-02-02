using AskIt.Api.Models;
using MediatR;

namespace AskIt.Api.Features
{
    public class QuestionCreateCommand: IRequest<Question>
    {
        public string Title { get; set; }
    }
}