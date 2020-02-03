using System;
using System.Threading;
using System.Threading.Tasks;
using AskIt.Api.Models;
using AskIt.Api.Infrastructure;
using MediatR;
using AutoMapper;
using System.Collections.Generic;

namespace AskIt.Api.Features.Question
{
    public class CommandHandler :
        IRequestHandler<QuestionCreateCommand, string>,
        IRequestHandler<QuestionQueryCommand, IEnumerable<QuestionModel>>
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

        public async Task<IEnumerable<QuestionModel>> Handle(QuestionQueryCommand request, CancellationToken cancellationToken)
        {
           return await _QuestionRepository.Get();
        }
    }
}