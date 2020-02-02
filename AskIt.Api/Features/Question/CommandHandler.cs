using System;
using System.Threading;
using System.Threading.Tasks;
using AskIt.Api.Models;
using AskIt.Api.Infrastructure;
using MediatR;

namespace AskIt.Api.Features.Question
{
    public class CommandHandler :
        IRequestHandler<QuestionCreateCommand, QuestionModel>
    {
        private readonly IMediator _mediator;
        private readonly IQuestionRepository _QuestionRepository;

        public CommandHandler(IMediator mediator, IQuestionRepository QuestionRepository)
        {
            _mediator = mediator;
            _QuestionRepository = QuestionRepository;
        }

        public async Task<QuestionModel> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
        { 
            var question = new QuestionModel{ 
                Id =  Guid.NewGuid().ToString("N"), 
                Title = request.Title
            };
            await _QuestionRepository.Save(question);

            return await Task.FromResult(question);
        }
    }
}