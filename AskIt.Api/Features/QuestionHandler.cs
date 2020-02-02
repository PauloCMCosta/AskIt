using System;
using System.Threading;
using System.Threading.Tasks;
using AskIt.Api.Models;
using AskIt.Api.Infrastructure;
using MediatR;

namespace AskIt.Api.Features
{
    public class QuestionHandler :
        IRequestHandler<QuestionCreateCommand, Question>
    {
        private readonly IMediator _mediator;
        private readonly IQuestionRepository _QuestionRepository;

        public QuestionHandler(IMediator mediator, IQuestionRepository QuestionRepository)
        {
            _mediator = mediator;
            _QuestionRepository = QuestionRepository;
        }

        public async Task<Question> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
        { 
            var question = new Question{ 
                Id =  Guid.NewGuid().ToString("N"), 
                Title = request.Title
            };
            await _QuestionRepository.Save(question);

            return await Task.FromResult(question);
        }
    }
}