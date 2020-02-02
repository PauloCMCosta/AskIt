using System;
using System.Threading;
using System.Threading.Tasks;
using AskIt.Api.Models;
using AskIt.Api.Infrastructure;
using MediatR;
using AutoMapper;

namespace AskIt.Api.Features.Question
{
    public class CommandHandler :
        IRequestHandler<QuestionCreateCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IQuestionRepository _QuestionRepository;

        public CommandHandler(IMapper mapper, IMediator mediator, IQuestionRepository QuestionRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _QuestionRepository = QuestionRepository;
        }

        public async Task<string> Handle(QuestionCreateCommand request, CancellationToken cancellationToken)
        {
            new QuestionCreationValidator().Validate(request);

            var question = _mapper.Map<QuestionModel>(request);
            question.Id = Guid.NewGuid().ToString("N");

            await _QuestionRepository.Save(question);

            return await Task.FromResult(question.Id);
        }
    }
}