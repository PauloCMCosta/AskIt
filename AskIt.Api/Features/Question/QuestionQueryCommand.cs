using System.Collections.Generic;
using AskIt.Api.Models;
using MediatR;

namespace AskIt.Api.Features.Question
{
    public class QuestionQueryCommand : IRequest<IEnumerable<QuestionModel>>
    {
    }
}