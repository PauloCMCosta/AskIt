using System.Collections.Generic;
using AskIt.Api.Models;
using MediatR;

namespace AskIt.Api.Features.Question
{
    public class QuestionCreateCommand: IRequest<string>
    {
        public string Title { get; set; }
        public QuestionType QuestionType { get; set; }
        public IList<ChoiceModel> Choices { get; set; }
    }
}