using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AskIt.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AskIt.Api.Features.Question
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IMediator _mediator;

        public QuestionController(IMediator mediator, ILogger<QuestionController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

         [HttpGet]
        public async Task<IEnumerable<QuestionModel>> Get(QuestionQueryCommand command)
        {
            var questions = await _mediator.Send(command);
            return questions;
        }

        [HttpPost]
        public async Task<IActionResult> Post(QuestionCreateCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);
                return Ok(new { Id = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
